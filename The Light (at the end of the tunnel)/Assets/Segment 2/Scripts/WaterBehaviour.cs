using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterBehaviour : MonoBehaviour
{

    private float timer;
    private bool isTriggered;

    [SerializeField] float deathScreenTime;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }

    void Start()
    {
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
            timer += Time.deltaTime;

        if(timer >= deathScreenTime && isTriggered)
            SceneManager.LoadScene("Casper");
    }
}
