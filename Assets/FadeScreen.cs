using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public static Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isFadingOut", false);
    }

    // Update is called once per frame
    public static void fadeOut()
    {
        animator.SetBool("isFadingOut", true);
    }
}
