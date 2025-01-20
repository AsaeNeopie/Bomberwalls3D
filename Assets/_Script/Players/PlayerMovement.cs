using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController _characterController;

    [Header("Values")]
    [SerializeField] float _movementSpeed;
    public float MoveSpeed => _movementSpeed;
    [SerializeField] float _acceleration = 50;

    Vector2 _moveInputVector;
    public Vector3 Velocity { get; private set; }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInputVector = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// velocity += force
    /// </summary>
    /// <param name="Force"></param>
    public void AddForce(Vector3 Force)
    {
        Velocity += Force;
    }

    void Move()
    {
        Vector3 targetVelocity = new Vector3(_moveInputVector.x, 0f, _moveInputVector.y) * _movementSpeed;

        Velocity=Vector3.MoveTowards(Velocity, targetVelocity, _acceleration*Time.deltaTime);

        _characterController.Move(Velocity*Time.deltaTime);
    }
    
    private void FixedUpdate()
    {
        Move();
    }

}
