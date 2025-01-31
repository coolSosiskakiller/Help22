using UnityEngine;
[RequireComponent (typeof(PlayerView))]
public class Player1 : MonoBehaviour
{
    private const float OXYGEN_MAXIMUM = 120f;
    private const float GAS_MAXIMUM = 120;

    private PlayerView _playerView;

    private bool _isAlive;
    private float _oxygen;
    private float _gas;
    private float _timer;

    private void Awake()
    {
        _playerView = GetComponent<PlayerView> ();

        _isAlive = true;
        _oxygen = OXYGEN_MAXIMUM;
        _gas = GAS_MAXIMUM;
    }

    private void Update()
    {
        if (_isAlive)
        {
            _oxygen -= Time.deltaTime;
            _oxygen = Mathf.Clamp(_oxygen, 0, OXYGEN_MAXIMUM);
            _playerView.OxygenBar.SetProgress(_oxygen / OXYGEN_MAXIMUM);

            _gas -= Time.deltaTime / 10f;
            _gas = Mathf.Clamp(_gas, 0, GAS_MAXIMUM);
            _playerView.GasBar.SetProgress(_oxygen / GAS_MAXIMUM);

            if (_gas <= 0 || _oxygen <= 0)
            {
                Kill();
            }

            _timer += Time.deltaTime;
            _playerView.SetTime(Mathf.RoundToInt(_timer));
        }
    }

    public void Kill()
    {
        _isAlive = false;
    }
}
