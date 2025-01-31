using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private ProgressBar _oxygenBar;
    [SerializeField] private ProgressBar _gasBar;
    [SerializeField] private TMP_Text _timerText;

    public ProgressBar OxygenBar => _oxygenBar;
    public ProgressBar GasBar => _gasBar;

     
    public void SetTime(int seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60);
        seconds -= minutes * 60;

        string secondsString = seconds < 10 ? $"{seconds}" : $"{seconds}";
        string minutesString = minutes < 10 ? $"{minutes}" : $"{minutes}";

        _timerText.text = $"{minutesString} : {secondsString}";
    }
}
