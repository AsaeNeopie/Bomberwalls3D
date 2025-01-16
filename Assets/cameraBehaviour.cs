using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{

    Vector3 _basePosition;

    [Header("SubtlePanning")]
    [SerializeField] float _maxPanningRadius;
    [SerializeField] float _panningMultiplier;
    [SerializeField] float _panningSmoothTime = .02f;

    private void Awake()
    {
        _basePosition = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 Panning = Vector3.zero;
        foreach(PlayerReference player in GameManager.Instance.AlivePlayers)
        {
            Panning+= player.transform.position-_basePosition;
        }
        Panning /= GameManager.Instance.AlivePlayers.Count;

        Panning = Vector3.ClampMagnitude( _panningMultiplier* Panning,_maxPanningRadius);

        Vector3 vel = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, _basePosition + Panning, ref vel, _panningSmoothTime);
        Panning.z = 0;
    }
}
