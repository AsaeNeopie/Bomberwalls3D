using UnityEngine;

public class bombVisuals : MonoBehaviour
{
    [Header("References")]
    [SerializeField] MeshRenderer _renderer;


    [Header("Values")]
    [SerializeField] float _frequencyIncreaseRate = 1;
    [SerializeField] float _baseFrequency = 1;
    [SerializeField] float _redIntensity = 1;
    MaterialPropertyBlock _block;
    float _frequency = 1;
    float _startTime;
    void OnPulledFromPool()
    {
        _block = new();
        _startTime = Time.time;
    }



    // Update is called once per frame
    void Update()
    {
        if (_block == null) return;
        _frequency += Time.deltaTime * _frequencyIncreaseRate;
        _block.SetFloat("_FresnelIntensity", Mathf.Sin( (Time.time-_startTime)*Mathf.PI*2f*_frequency * _baseFrequency) * _redIntensity+.5f);
        _renderer.SetPropertyBlock(_block);
    }
}
