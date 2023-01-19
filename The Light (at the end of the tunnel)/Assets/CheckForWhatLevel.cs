using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckForWhatLevel : MonoBehaviour
{
    [SerializeField] GameObject clockTick;
    [SerializeField] GameObject waterFlowSound;
    [SerializeField] Transform player;
    [Header("Dion")]
    [SerializeField] Collider dionCollider;
    [SerializeField] GameObject levelSwitchSound;
    [SerializeField] GameObject dionSounds;

    [Header("Jamal")]
    [SerializeField] Collider jamalCollider;
    [SerializeField] GameObject jamalSounds;

    [Header("Kian")]
    [SerializeField] Collider kianCollider;
    [SerializeField] GameObject kianSounds;

    [Header("Casper")]
    [SerializeField] Collider casperCollider;
    [SerializeField] GameObject casperSounds;

    [Header("Mike")]
    [SerializeField] Collider mikeCollider;
    [SerializeField] GameObject mikeSounds;
    // Start is called before the first frame update
    void Start()
    {
        AllSoundsInactive();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == dionCollider.name)
        {
            Dion();
        }
        if (other.name == jamalCollider.name)
        {
            Jamal();
        }
        if (other.name == mikeCollider.name)
        {
            Mike();
        }
        if (other.name == kianCollider.name)
        {
            Kian();
        }
        if (other.name == casperCollider.name)
        {
            Casper();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == dionCollider.name)
        {
            dionSounds.SetActive(false);
        }
        if (other.name == jamalCollider.name)
        {
            jamalSounds.SetActive(false);
        }
        if (other.name == mikeCollider.name)
        {
            mikeSounds.SetActive(false);
        }
        if (other.name == kianCollider.name)
        {
            kianSounds.SetActive(false);
        }
        if (other.name == casperCollider.name)
        {
            casperSounds.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void Casper()
    {
        casperSounds.SetActive(true);
        clockTick.transform.position = player.transform.position;
    }

    private void Kian()
    {
        kianSounds.SetActive(true);
        clockTick.transform.position = player.transform.position;
    }

    private void Mike()
    {
        mikeSounds.SetActive(true);
    }

    private void Jamal()
    {
        jamalSounds.SetActive(true);
    }
    private void Dion()
    {
        dionSounds.SetActive(true);
        levelSwitchSound.transform.position = player.transform.position;
    }
    private void AllSoundsInactive()
    {
        jamalSounds.SetActive(false);
        kianSounds.SetActive(false);
        mikeSounds.SetActive(false);
        dionSounds.SetActive(false);
        casperSounds.SetActive(false);
    }
}
