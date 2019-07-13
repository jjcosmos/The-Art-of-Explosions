using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax_effector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform baseMover;
    [SerializeField] float moveFactor;
    Vector2 offset;
    void Start()
    {
        offset = baseMover.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ((Vector2)baseMover.position * moveFactor - offset);
    }
}
