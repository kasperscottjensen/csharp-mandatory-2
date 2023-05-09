using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference movementControl;
    [SerializeField]
    private InputActionReference jumpControl;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float rotationSpeed = 4.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    [SerializeField]
    private AudioSource jumpSound;
    [SerializeField]
    private AudioSource movementSound;

    private Animator _animator;
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;

    private Transform _cameraMainTransform;

    
    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
        
    }
    
    private void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
        _cameraMainTransform = Camera.main.transform;
        _animator = GetComponent<Animator>();
        movementSound.enabled = false;

    }

    void Update()
    {
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = _cameraMainTransform.forward * move.z + _cameraMainTransform.right * move.x;
        move.y = 0f;
        _controller.Move(move * Time.deltaTime * playerSpeed);

        if (jumpControl.action.triggered && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            jumpSound.Play();
        }

        _playerVelocity.y += gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);

        if (movement != Vector2.zero)
        {
            movementSound.enabled = true;
            _animator.SetBool("isMoving", true);
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + _cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            _animator.SetBool("isMoving", false);
            movementSound.enabled = false;
        }
    }
    
}
