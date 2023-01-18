using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePause : MonoBehaviour
{
    [SerializeField] CharacterInput playerInput;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] CutsceneBeginGame cutscene;
    public static bool pauseOpen;

    // Update is called once per frame
    void Update()
    {
        if (playerInput.isPauseButtonPressed() && !DeathManager.IsDying && !cutscene.startCutscene)
        {
            Pause();
        }
    }

    void Pause()
    {
        pauseOpen = true;
        Cursor.lockState = CursorLockMode.Confined;
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
