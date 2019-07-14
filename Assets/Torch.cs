using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isTriggered;
    public Animator animator;
    public bool isStartOfLevel;
    void Start()
    {
        //CP_Manager.currentCP_Position.position = transform.position;
        animator.SetBool("isTriggered", isTriggered);
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered)
        {
            CP_Manager.currentCP_Position = transform.position;
        }

        Debug.Log("Checkpoint");
        isTriggered = true;
        animator.SetBool("isTriggered", isTriggered);
        
    }
}
