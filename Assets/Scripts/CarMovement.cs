using System;
using System.Collections;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public delegate void OnPlayerDied();
    public static event OnPlayerDied PlayerDied;

    [SerializeField] float _speed = 25;
    [SerializeField] float _rotationSpeed = 150;
    [SerializeField] LayerMask _groundLayer; 
    [SerializeField] Vector3 _carStartPos; 

    private Rigidbody2D _rb;
    private bool _isGrounded;
    public bool _inverted;
    private float _horizontalInput;
    private float _distanceToGround = 2.5f;
    private float _second = 1;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        CheckInverted();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void BasicPosition()
    {
        _speed = 25;
        _rotationSpeed = 150;
        transform.position = _carStartPos;
        transform.rotation = Quaternion.identity;
    }
    public void SetZeroSpeed()
    {
        _speed = 0;
        _rotationSpeed = 0;
    }
    private void CheckInverted()
    {
        if(transform.rotation.eulerAngles.z > 120 && transform.rotation.eulerAngles.z < 250)
            _inverted = true;
        else _inverted = false;
    }

    private void Move()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _distanceToGround, _groundLayer);

        if (_isGrounded && _inverted)
            StartCoroutine(SecureStatusInvertedCar());
        else
            StopCoroutine(SecureStatusInvertedCar());

        Vector3 moveDirection = new Vector3(_horizontalInput, 0) * _speed * Time.fixedDeltaTime;
        if (_isGrounded )
            _rb.velocity = moveDirection * _speed; 
        _rb.AddTorque(_horizontalInput * _rotationSpeed) ;

    }

    private IEnumerator SecureStatusInvertedCar() 
    {
        yield return new WaitForSeconds(_second); 
        PlayerDied?.Invoke();

    }
}
