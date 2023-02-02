using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingsequence : MonoBehaviour
{
    public static bool endingBegin;
    [SerializeField] Light THELIGHT;
    [SerializeField] GameObject endcollider;
    [SerializeField] SoundManager shatter;
    [SerializeField] SoundManager flicky;
    [SerializeField] SoundManager clocky;
    [SerializeField] string EndingSceneName;
    [SerializeField] GameObject BlackScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        endcollider.SetActive(true);
        endingBegin = true;
        StartCoroutine(ending());

    }
    private void OnTriggerStay(Collider other)
    {

    }
    IEnumerator ending()
    {
        flicky.SetAndPlayMusic(0);
        THELIGHT.intensity += 5;
        yield return new WaitForSeconds(3);
        THELIGHT.intensity = 0;
        BlackScreen.SetActive(true);
        flicky.StopMusic();
        shatter.SetAndPlayMusic(0);
        clocky.SetAndPlayMusic(0);
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(EndingSceneName);
        endingBegin = false;
    }
}
