using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUI : MonoBehaviour
{
    // Start is called before the first frame update
    public static Animator animator;
    static bool isTiming;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public static void setSaveUIFlag()
    {
        animator.SetBool("isUIShowing", true);
        isTiming = true;
    }

    private void Update()
    {
        if (isTiming)
        {
            StartCoroutine(dismissSave());
            isTiming = false;
        }
    }
    IEnumerator dismissSave()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("isUIShowing", false);
    }
}
