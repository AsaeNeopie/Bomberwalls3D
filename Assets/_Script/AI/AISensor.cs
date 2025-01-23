using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AISensor : MonoBehaviour
{
    

    [Header("References")]
    [SerializeField] PlayerBombing _bombing;
    [SerializeField] NavMeshAgent _navMeshAgent;
    [SerializeField] CharacterReference _characterReference;

    [Header("Parameters")]
    public float TickingBombDangerRadius;
    public LayerMask TickingBombsLayerMask;

    [Header("Game State Informations")]
    public CharacterReference NearestPlayer; //ok
    public BombPickup NearestBombPickUp; //ok
    public List<TickingBomb> TickingBombsNearby;
    public byte BombCount => _bombing.BombCount; //ok


    //notifiers
    public event Action OnNearestPlayerChanged; //ok
    public event Action OnNearestBombPickUpChanged; //ok
    public event Action OnNewTickingBombDetectedNearby;
    public event Action OnBombPickedUp; //ok


    public bool IsPointSafe(Vector3 p)
    {
        Collider[] hits = Physics.OverlapSphere(p, TickingBombDangerRadius, TickingBombsLayerMask);

        foreach (Collider c in hits)
        {
            if (c.gameObject.TryGetComponent<TickingBomb>(out TickingBomb bomb))
            {
                Vector3 offset = bomb.transform.position - transform.position;
                if (Physics.Raycast(p, offset, out RaycastHit hit, offset.magnitude) && hit.collider == bomb)
                {
                    return false;
                }
            }
        }

        return true;
    }



    private void Update()
    {
        CheckForNearestPlayer();
        CheckForNearestBombPickUp();
        CheckForTickingBombs();
    }

    void CheckForNearestPlayer()
    {

        bool changed = false;
        foreach (CharacterReference c in CharacterReference.Instances)
        {
            if (c == _characterReference) continue;
            if (
                (NearestPlayer == null || c.transform.position.SqrDistanceTo( transform.position)
                < NearestPlayer.transform.position.SqrDistanceTo(transform.position)))
            {
                changed |= true;
                NearestPlayer = c;
            }
        }
        if (changed) OnNearestPlayerChanged?.Invoke();
    }

    void CheckForNearestBombPickUp()
    {
        if (BombPickup.Instances.Count == 0)
        {
            NearestBombPickUp = null;
            return;
        }

        bool changed = false;
        foreach (BombPickup b in BombPickup.Instances)
        {
            if (b==NearestBombPickUp) continue;
            if (
                (NearestBombPickUp == null || !NearestBombPickUp.isActiveAndEnabled || b.transform.position.SqrDistanceTo(transform.position)
                < NearestBombPickUp.transform.position.SqrDistanceTo(transform.position)))
            {
                changed |= true;
                NearestBombPickUp = b;
                
            }
        }
        if (changed) OnNearestBombPickUpChanged?.Invoke();
    }

    void CheckForTickingBombs()
    {
        TickingBombsNearby.RemoveAll((TickingBomb t) => { return t == null|| ! t.gameObject.activeInHierarchy; });
        foreach (TickingBomb t in TickingBomb.Instances)
        {
            if (t.transform.position.SqrDistanceTo(transform.position) < TickingBombDangerRadius)
            {
                if (!TickingBombsNearby.Contains(t))
                {
                    TickingBombsNearby.Add(t);
                    OnNewTickingBombDetectedNearby?.Invoke();
                }
            }
            else
            {
                if (TickingBombsNearby.Contains(t))
                {
                    TickingBombsNearby.Remove(t);
                }
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        
    }

    private void OnEnable()
    {
        _bombing.OnBombPickedUp += () => OnBombPickedUp?.Invoke();
    }

    private void OnDisable()
    {
        _bombing.OnBombPickedUp -= () => OnBombPickedUp?.Invoke();
    }
}
