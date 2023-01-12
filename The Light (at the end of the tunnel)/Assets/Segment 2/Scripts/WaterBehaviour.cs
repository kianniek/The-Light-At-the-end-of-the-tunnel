using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterBehaviour : MonoBehaviour
{
    private float timer;
    private bool isTriggered;
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;
    public bool reverseStart;
    public bool allowRespawn = true;

    [SerializeField] Transform player;
    [SerializeField] float deathScreenTime;
    [SerializeField] PipeRotation[] pipe;
    [SerializeField] PlatformBehaviour[] platform;
    [SerializeField] LevelTrigger levelTrigger;
    [SerializeField] ReverseTrigger reverseTrigger;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (allowRespawn)
            {
                isTriggered = true;
            }
            else
            {
                player.transform.position = spawnPosition;
                player.transform.rotation = spawnRotation;
            }
        }
    }

    void Start()
    {
        isTriggered = false;
        spawnPosition = player.transform.position;
        spawnRotation = player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
            timer += Time.deltaTime;

        if (timer >= deathScreenTime && isTriggered)
        {
            player.transform.position = spawnPosition;
            player.transform.rotation = spawnRotation;
            isTriggered = false;
            timer = 0;
            for (int i = 0; i < pipe.Length; i++)
                pipe[i].Reset();
            for (int i = 0; i < platform.Length; i++)
                platform[i].Reset();
            levelTrigger.Reset();
            reverseTrigger.Reset();
            if (reverseStart)
            {
                for (int i = 0; i < pipe.Length; i++)
                    pipe[i].reverseSegmentActive = true;
            }
        }
        //SceneManager.LoadScene("Casper");
    }
}
