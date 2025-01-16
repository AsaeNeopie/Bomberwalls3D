using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensor : MonoBehaviour
{
    

    [Header("References")]
    [SerializeField] PlayerBombing _bombing;

    [Header("Parameters")]
    public float TickingBombDangerRadius;

    [Header("Game State Informations")]
    public Transform NearestPlayer;
    public Transform NearestDroppedBomb;
    public byte TickingBombsNearby;
    public byte BombPickUpsNearby;
    public byte BombCount;

    //notifiers
    public event Action OnNearestPlayerChanged;
    public event Action OnNearestBombPickUpChanged;
    public event Action OnNewDangerousBombDetected;
    public event Action OnNewBombPickUpDetected;
    public event Action OnBombPickedUp;

    private void OnEnable()
    {
        _bombing.OnBombPickedUp += () => OnBombPickedUp?.Invoke();
    }

    private void OnDisable()
    {
        _bombing.OnBombPickedUp -= () => OnBombPickedUp?.Invoke();
    }
}
