using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    public void Continue()
    {
        HandlePause.pauseOpen = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
