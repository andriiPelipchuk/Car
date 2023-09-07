using System.Runtime.CompilerServices;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    [SerializeField] float _rotationSpeed = 5;
    [SerializeField] LayerMask _groundLayer; 

    private Rigidbody2D _rb;
    private bool _isGrounded;
    private float _horizontalInput;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {

        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 2f, _groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 2f, Color.red, 0.5f);
        Vector3 moveDirection = new Vector3(-_horizontalInput, 0) * _speed * Time.fixedDeltaTime;
        if (_isGrounded )
            transform.Translate(moveDirection);
        _rb.AddTorque(_horizontalInput * _rotationSpeed) ;

    }
}
