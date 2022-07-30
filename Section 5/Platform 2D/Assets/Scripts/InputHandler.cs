using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpSpeed = 1f;

    private AnimationController animationController;
    private PlayerInput _playerInput;
    private InputAction _jumpAction;
    private Rigidbody2D _rb;

    private bool isGround;

    private float PlayerAxis = 0;



    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        animationController = GetComponent<AnimationController>();
        _jumpAction = _playerInput.actions["Jump"];
        _rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        transform.Translate(PlayerAxis * moveSpeed * Time.deltaTime, 0, 0);
    }

    void OnJump()
    {
        if (isGround)
        {
            _rb.AddForce(Vector2.up * jumpSpeed);
            animationController.JumpAnimation();
            Debug.Log("Jump");
            isGround = false;
        }
        
    }

    private void OnMove(InputValue value)
    {
        PlayerAxis = value.Get<float>();
    }

    public void SetIsGrounded(bool val)
    {
        isGround = val;
    }

    public float GetAxis()
    {
        return PlayerAxis;
    }

}
