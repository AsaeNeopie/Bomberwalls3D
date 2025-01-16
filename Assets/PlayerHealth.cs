using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    int _health;
    [Min(1)][SerializeField] int _MaxHealth;

    public event Action<int> OnHealthChanged;
    public event Action OnGameOver;

    PlayerMovement _mvt;

    private void Awake()
    {
        _health = _MaxHealth;
        TryGetComponent(out _mvt);
    }

    public void OnDamageTaken(Vector3 Source)
    {
        //feedbacks
        PostProcessController.instance.ChromaticAberrationFlash.play();
        TimeManager.instance.PlayTimeDilatationAnimation();
        if (PoolManager.Instance.VfxHitPool!=null) PoolManager.Instance.VfxHitPool.PullObjectFromPool(transform.position);

        _mvt.AddForce((transform.position-Source).normalized * 5);

        //notifier
        OnHealthChanged?.Invoke(_health);

        //Gameover
        _health--;
        if(_health==0 ) GameOver();
    }

    void GameOver()
    {
        OnGameOver?.Invoke();

        if (PoolManager.Instance.VFXDeathPool != null) PoolManager.Instance.VFXDeathPool.PullObjectFromPool(transform.position);
        Destroy(gameObject);
    }
}
