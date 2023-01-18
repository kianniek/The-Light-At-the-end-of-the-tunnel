using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    [SerializeField]AudioClip deathSound;
    [SerializeField] AudioSource sourceDeath;
    public static Vector3 resetPosition;

    [SerializeField] MonoBehaviour[] scriptsToDisable;

    [SerializeField]
    private readonly int steps = 3;
    [SerializeField] CircleWipeController circleWipe;
    [SerializeField] Mover player;
    [SerializeField] SoundManager soundManager;
    public static bool IsDying;
    public void InitiateDeathDuration(float duration)
    {
        StartCoroutine(RespawnTransition(duration));
    }
    IEnumerator RespawnTransition(float duration)
    {
        IsDying = true;
        if (deathSound && sourceDeath)
        {
            sourceDeath.clip = deathSound;
            sourceDeath.Play();
            duration = sourceDeath.clip.length;
        }
        if (circleWipe == null)
        {
            circleWipe = GetComponent<CircleWipeController>();
        }

        if (circleWipe == null)
        {
            Debug.LogError("DeathManager requires a CircleWipeController to be set");
        }

        for (int i = 0; i < scriptsToDisable.Length; i++)
        {
            scriptsToDisable[i].enabled = false;
        }
        player.SetVelocity(Vector3.zero);
        yield return new WaitForSeconds(duration / steps);

        Vector2 ObjPosOnScreen = Camera.main.WorldToScreenPoint(transform.position);
        var x = (ObjPosOnScreen.x - Screen.width / 2f);
        var y = (ObjPosOnScreen.y - Screen.height / 2f);
        var offset = new Vector2(x / Screen.width, y / Screen.height);
        circleWipe.offset = offset;

        circleWipe.FadeOut();

        yield return new WaitForSeconds(circleWipe.fadeOutduration);

        if (resetPosition == Vector3.zero) { resetPosition = GameObject.FindWithTag("Respawn").transform.position; }
        transform.position = resetPosition;

        for (int i = 0; i < scriptsToDisable.Length; i++)
        {
            scriptsToDisable[i].enabled = true;
        }
        yield return new WaitForSeconds(circleWipe.fadeInduration);
        circleWipe.FadeIn();


        yield return new WaitForSeconds(duration / steps);


        soundManager.Reset();
        IsDying = false;
        yield return null;
    }
}
