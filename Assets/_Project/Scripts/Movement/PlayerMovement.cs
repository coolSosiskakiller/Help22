using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public static readonly float MAP_RADIUS = 100;
    public enum State 
    {
        Stay = 0, Move = 1, Nitro = 3
    }


    [SerializeField] private Joystick _leftJoystick;
    [SerializeField] private Joystick _rightJoystick;

    [SerializeField] private InputButton _nitroButton;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    public bool Active;
    private Rigidbody _rigidbody;
    public State Moving {  get; private set; }

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Active = true;
    }



    public void Update()
    {
        Moving = State.Stay;
        if (_leftJoystick.AnyPressed | _rightJoystick.AnyPressed)
        {
            Moving = State.Move;
            if (_nitroButton.Active)
            {
                Moving = State.Nitro;
            }
        }
    }

    public void FixedUpdate()
    {
        if (Active)
        {
            if (Vector3.Distance(_rigidbody.position, Vector3.zero) >= MAP_RADIUS)
            {
                _rigidbody.MovePosition(_rigidbody.position - _rigidbody.position.normalized * 0.1f);
                return;
            }

            float moveSpeed = Moving == State.Nitro ? 2 * _moveSpeed : _moveSpeed;
            float rotationSpeed = Moving == State.Nitro ? 2 * _rotationSpeed : _rotationSpeed;

            if (_leftJoystick.Up.Active)
                _rigidbody.AddForce(_rigidbody.transform.forward * Time.fixedDeltaTime * moveSpeed);

            if (_leftJoystick.Down.Active)
                _rigidbody.AddForce(- _rigidbody.transform.forward * Time.fixedDeltaTime * moveSpeed);

            if (_leftJoystick.Left.Active)
                _rigidbody.AddForce(_rigidbody.transform.right * Time.fixedDeltaTime * moveSpeed);

            if (_leftJoystick.Right.Active)
                _rigidbody.AddForce(- _rigidbody.transform.right * Time.fixedDeltaTime * moveSpeed);


            if (_rightJoystick.Up.Active)
                _rigidbody.AddForce(_rigidbody.transform.up * moveSpeed * Time.fixedDeltaTime);

            if (_rightJoystick.Down.Active)
                _rigidbody.AddForce(- _rigidbody.transform.up * moveSpeed * Time.fixedDeltaTime);

            if (_rightJoystick.Left.Active)
                _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, -rotationSpeed * Time.fixedDeltaTime, 0));

            if (_rightJoystick.Right.Active)
                _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, rotationSpeed * Time.fixedDeltaTime, 0));
        }

        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
