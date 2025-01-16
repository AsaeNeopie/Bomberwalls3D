using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    //void OnDamageTaken();
    void OnDamageTaken(Vector3 origin);

}
