using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _leftJoystick;
    [SerializeField] private Joystick _rightJoystick;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody _rigidbody;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (Vector3.Distance(_rigidbody.position, Vector3.zero) >= 5000)
        {
            _rigidbody.MovePosition(_rigidbody.position - _rigidbody.position.normalized * 0.1f);
            return;
        }

        if (_leftJoystick.Up.Active) 
            _rigidbody.MovePosition(_rigidbody.position + Vector3.forward * Time.fixedDeltaTime * _moveSpeed);

        if (_leftJoystick.Down.Active)
            _rigidbody.MovePosition(_rigidbody.position + Vector3.back * Time.fixedDeltaTime * _moveSpeed);

        if (_leftJoystick.Left.Active)
            _rigidbody.MovePosition(_rigidbody.position + Vector3.left * Time.fixedDeltaTime * _moveSpeed);

        if (_leftJoystick.Right.Active)
            _rigidbody.MovePosition(_rigidbody.position + Vector3.right * Time.fixedDeltaTime * _moveSpeed);


        if (_rightJoystick.Up.Active)
            _rigidbody.MovePosition(_rigidbody.position + Vector3.up * _rotationSpeed * Time.fixedDeltaTime);

        if (_rightJoystick.Down.Active)
            _rigidbody.MovePosition(_rigidbody.position + Vector3.down * _rotationSpeed * Time.fixedDeltaTime);

        if (_rightJoystick.Left.Active)
            _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, -_rotationSpeed * Time.fixedDeltaTime, 0));

        if (_rightJoystick.Right.Active)
            _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, _rotationSpeed * Time.fixedDeltaTime, 0));
    }
}
