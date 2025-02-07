using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private DividedProgressBar _oxygenBar;
    [SerializeField] private DividedProgressBar _gasBar;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private GameObject _deathScreen;

    public DividedProgressBar OxygenBar => _oxygenBar;
    public DividedProgressBar GasBar => _gasBar;

     
    public void SetTime(int seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60);
        seconds -= minutes * 60;

        string secondsString = seconds < 10 ? $"{seconds}" : $"{seconds}";
        string minutesString = minutes < 10 ? $"{minutes}" : $"{minutes}";

        _timerText.text = $"{minutesString} : {secondsString}";
    }

    public void ActiveDeathScreen(bool active)
    {
        _deathScreen.SetActive(active);
    }
}
