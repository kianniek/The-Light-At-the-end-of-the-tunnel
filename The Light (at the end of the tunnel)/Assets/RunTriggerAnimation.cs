using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTriggerAnimation : MonoBehaviour
{
    [SerializeField] string triggerName;
    Animator animator;
    [SerializeField] bool flipped;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        flipped = false;
    }
    public void PlayAnim()
    {
        flipped = true;
        if (flipped)
        {
            animator.SetBool(triggerName, true);
        }
    }
}
