using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDestroyer : MonoBehaviour
{
    private Animator animator;
    private float animationDuration;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(animator != null) {
            AnimationClip clip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            animationDuration = clip.length;
            Destroy(gameObject, animationDuration);
        }
        else {
            Debug.LogError("Animator component not found!");
        }
    }
}
