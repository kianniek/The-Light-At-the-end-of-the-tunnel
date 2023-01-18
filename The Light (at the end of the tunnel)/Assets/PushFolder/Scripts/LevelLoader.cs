using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loading;
    public GameObject titleScreen;

    public Slider slider;

    //Give this function a index and that scene is starting to load
    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    //Loading the scene
    IEnumerator LoadAsynchronously(string sceneName)
    {
        if (titleScreen)
        {
            titleScreen.SetActive(false);
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        loading.SetActive(true);

        //Go loading if operation isn't done
        while (!operation.isDone)
        {
            //Instead of 0 to 9 it becomes 0 to 1
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            yield return null;
        }
    }
}
