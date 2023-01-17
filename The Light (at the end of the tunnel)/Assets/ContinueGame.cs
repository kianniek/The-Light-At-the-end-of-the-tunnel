using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{
    public void Continue(int screenIndex)
    {
        SceneManager.LoadScene(screenIndex);
    }
}
