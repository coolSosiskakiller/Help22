using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
