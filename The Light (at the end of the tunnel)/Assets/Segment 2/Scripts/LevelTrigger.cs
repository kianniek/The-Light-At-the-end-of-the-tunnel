using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public bool levelActive = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        levelActive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        levelActive = false;
    }
}
