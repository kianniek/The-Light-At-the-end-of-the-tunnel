using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTitle : MonoBehaviour
{
    public void ToTitleScreen(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
