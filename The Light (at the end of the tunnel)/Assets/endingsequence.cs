using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingsequence : MonoBehaviour
{
    [SerializeField] SoundManager shatter;
    [SerializeField] SoundManager flicky;
    [SerializeField] SoundManager clocky;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter()
    {

        StartCoroutine(ending());
    }
    IEnumerator ending()
    {
        flicky.SetAndPlayMusic(0);
        yield return new WaitForSeconds(3);
        flicky.StopMusic();
        shatter.SetAndPlayMusic(0);
        clocky.SetAndPlayMusic(0);
    }
}
