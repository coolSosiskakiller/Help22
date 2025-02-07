using UnityEngine;
using UnityEngine.UI;
[RequireComponent (typeof(PlayerView))]
public class Player1 : MonoBehaviour
{
    [SerializeField] private Button _useButton;

    private const float OXYGEN_MAXIMUM = 120f;
    private const float GAS_MAXIMUM = 12f;

    private PlayerView _playerView;
    private PlayerMovement _playerMovement;

    private bool _isAlive;
    private float _oxygen;
    private float _gas;
    private float _timer;

    private void Awake()
    {
        _playerView = GetComponent<PlayerView> ();
        _playerMovement = GetComponent <PlayerMovement> ();

        _isAlive = true;
        _oxygen = OXYGEN_MAXIMUM;
        _gas = GAS_MAXIMUM;

        _playerView.GasBar.SetProgress(_gas / GAS_MAXIMUM);
        _playerView.OxygenBar.SetProgress(_oxygen / OXYGEN_MAXIMUM);

        _useButton.gameObject.SetActive(false);

        _playerView.ActiveDeathScreen(false);
    }

    private void Update()
    {
        if (_isAlive)
        {
            _oxygen -= Time.deltaTime;
            _oxygen = Mathf.Clamp(_oxygen, 0, OXYGEN_MAXIMUM);
            _playerView.OxygenBar.SetProgress(_oxygen / OXYGEN_MAXIMUM);
            if (_playerMovement.Moving >= PlayerMovement.State.Move)
            {
                _gas -= Time.deltaTime / 10f * (int)_playerMovement.Moving;
                _gas = Mathf.Clamp(_gas, 0, GAS_MAXIMUM);
                _playerView.GasBar.SetProgress(_gas / GAS_MAXIMUM);
            }
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
        _playerMovement.Active = false;
        _playerView.ActiveDeathScreen(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            _useButton.gameObject.SetActive(true);
            _useButton.onClick.RemoveAllListeners();
            _useButton.onClick.AddListener(() => OnClickUse(other.gameObject, 2, 0));
        }

        if (other.CompareTag("Oxygen"))
        {
            _useButton.gameObject.SetActive(true);
            _useButton.onClick.RemoveAllListeners();
            _useButton.onClick.AddListener(() => OnClickUse(other.gameObject, 0, 20));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _useButton.gameObject.SetActive(false);
    }

    private void OnClickUse(GameObject gameObject, int gas, int oxygen)
    {
        _useButton.gameObject.SetActive(false);
        Destroy(gameObject);
        _gas += gas;
        _oxygen += oxygen;

        _playerView.OxygenBar.SetProgress(_oxygen / OXYGEN_MAXIMUM);
        _playerView.GasBar.SetProgress(_gas / GAS_MAXIMUM);
    }
}
