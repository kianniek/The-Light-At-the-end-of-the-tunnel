using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showPrompt : MonoBehaviour
{
    [SerializeField] GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UI.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UI.SetActive(false);

        }
    }
}
