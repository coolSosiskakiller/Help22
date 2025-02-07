using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class UFO : MonoBehaviour
{
    [SerializeField] private float _height;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Player1 _target;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetTarget(Player1 target)
    {
        _target = target;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.MovePosition(transform.position);
    }

    private void FixedUpdate()
    {
        if (_target != null)
        {
            _rigidbody.MovePosition(Vector3.MoveTowards(_rigidbody.position, _target.transform.position + Vector3.up * _height, _speed * Time.fixedDeltaTime));

            if(Vector3.Distance(_rigidbody.position, _target.transform.position) <= _height + 1)
            {
                _target.Kill();
            }
        }
    }
}
