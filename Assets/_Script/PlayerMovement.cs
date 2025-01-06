using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 _moveInputVector;
    [SerializeField] float _movementSpeed;
    [SerializeField] GameObject _bomb;
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInputVector = context.ReadValue<Vector2>();
    }


    void Move()
    {
        Vector3 movement = new Vector3(_moveInputVector.x, 0f, _moveInputVector.y);

        transform.Translate(movement * _movementSpeed * Time.deltaTime, Space.World);
    }
    
    private void FixedUpdate()
    {
        Move();
    }

}
