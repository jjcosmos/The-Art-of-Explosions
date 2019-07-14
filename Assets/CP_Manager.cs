using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 currentCP_Position;
    public Torch[] CheckPoints;
    void Start()
    {
        currentCP_Position = CheckPoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
