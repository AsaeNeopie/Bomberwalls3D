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


    public async void OnDamageTaken(Vector3 origin)
    {
        print(i);
        i++;
        await Task.Delay(Mathf.RoundToInt(50*Vector3.Distance(origin,transform.position)));
       // _animator.SetFloat("speed", Vector3.Distance(origin, transform.position) );
        _animator.SetTrigger(TriggerParameter);
    }

    
}
