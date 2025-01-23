using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int HP { get; private set; }
    [Min(1)][SerializeField] int _MaxHealth = 5;

    public event Action<int> OnHealthChanged;
    public event Action OnGameOver;

    PlayerMovement _mvt;

    private void Awake()
    {
        HP = _MaxHealth;
        TryGetComponent(out _mvt);
    }

    public void OnDamageTaken(Vector3 Source)
    {
        //feedbacks
        if(PostProcessController.instance!=null) PostProcessController.instance.ChromaticAberrationFlash.play();
        if (PostProcessController.instance != null) PostProcessController.instance.PlayImpactFrameAnimation();
        if (TimeManager.instance != null) TimeManager.instance.PlayTimeDilatationAnimation();
        if (PoolManager.Instance.VfxHitPool!=null) PoolManager.Instance.VfxHitPool.PullObjectFromPool(transform.position);
        
        Source.y = transform.position.y;
        if(_mvt!=null)_mvt.AddForce((transform.position-Source).normalized * 14);

        HP--;

        //notifier
        OnHealthChanged?.Invoke(HP);
        
        //Gameover
        if (HP==0 ) GameOver();
    }

    void GameOver()
    {
        OnGameOver?.Invoke();

        if (PoolManager.Instance.VFXDeathPool != null) PoolManager.Instance.VFXDeathPool.PullObjectFromPool(transform.position);
        Destroy(gameObject);
    }
}
