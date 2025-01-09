using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController _characterController;
    
    [Header("Values")]
    [SerializeField] float _movementSpeed;
    [SerializeField] float _acceleration = 50;

    Vector2 _moveInputVector;
    Vector3 vel;

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInputVector = context.ReadValue<Vector2>();
    }




    void Move()
    {
        Vector3 targetVelocity = new Vector3(_moveInputVector.x, 0f, _moveInputVector.y) * _movementSpeed;

        vel=Vector3.MoveTowards(vel, targetVelocity, _acceleration*Time.deltaTime);

        _characterController.Move(vel*Time.deltaTime);
        
    }
    
    private void FixedUpdate()
    {
        Move();
    }

}
