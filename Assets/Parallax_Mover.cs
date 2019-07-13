using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Mover : MonoBehaviour
{
    // Start is called before the first frame update
    private float length, startpos;
    public Transform cam;
    public float parallax_effect;
    void Start()
    {
        startpos = transform.position.x;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.position.x * parallax_effect;
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    }
}
