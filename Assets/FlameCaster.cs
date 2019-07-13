using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCaster : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    int StateName;
    void Start()
    {
        StateName = Animator.StringToHash("CastFire");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.Play(StateName);
        }
    }
}
