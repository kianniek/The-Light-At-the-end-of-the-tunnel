using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
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
    // Update is called once per frame
    void Update()
    {
    }

    private void Casper()
    {
        AllSoundsInactive();
        casperSounds.SetActive(true);
        clockTick.transform.position = player.transform.position;
    }

    private void Kian()
    {
        AllSoundsInactive();
        kianSounds.SetActive(true);
        clockTick.transform.position = player.transform.position;
    }

    private void Mike()
    {
        AllSoundsInactive();
        mikeSounds.SetActive(true);
    }

    private void Jamal()
    {
        AllSoundsInactive();
        jamalSounds.SetActive(true);
    }
    private void Dion()
    {
        AllSoundsInactive();
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
