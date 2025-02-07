using UnityEngine;

public class Blackhole : MonoBehaviour
{
    private Blackhole _linkedBlackhole;
    private bool _active;

    private void Awake()
    {
        _active = true;
    }

    public void LinkedBlackhole(Blackhole blackhole)
    {
        _linkedBlackhole = blackhole;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _active)
        {
            _linkedBlackhole._active = false;
            Rigidbody player = other.GetComponent<Rigidbody>();
            player.MovePosition(_linkedBlackhole.transform.localPosition);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _active = true;
        }
    }
}
