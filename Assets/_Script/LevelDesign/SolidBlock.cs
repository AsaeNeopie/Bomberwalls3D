using System.Threading.Tasks;
using UnityEngine;

public class SolidBlock : MonoBehaviour,IDamageable
{
    Animator _animator;
    const string TriggerParameter = "Bump";
    int i = 0;
    // Start is called before the first frame update
    void Awake()
    {
        TryGetComponent(out _animator);
    }

    private void Start()
    {
        if (LevelManager.Instance.FreeSpaces.Contains(transform.position.XZ().round()))
        {
            LevelManager.Instance.FreeSpaces.Remove(transform.position.XZ().round());
        }
    }

    private void OnDestroy()
    {
        if (!LevelManager.Instance.FreeSpaces.Contains(transform.position.XZ().round()))
        {
            LevelManager.Instance.FreeSpaces.Add(transform.position.XZ().round());
        }
    }

    public async void OnDamageTaken(Vector3 origin)
    {
        i++;
        await Task.Delay(Mathf.RoundToInt(50*Vector3.Distance(origin,transform.position)));
       // _animator.SetFloat("speed", Vector3.Distance(origin, transform.position) );
        _animator.SetTrigger(TriggerParameter);
    }

    
}
