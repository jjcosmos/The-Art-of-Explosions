using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 currentCP_Position;
    public static bool loadFromCP;
    public Torch[] CheckPoints;

    private void Awake()
    {
        if (currentCP_Position == null || currentCP_Position == Vector3.zero)
        {
            currentCP_Position = CheckPoints[0].transform.position;
        }
    }
    void Start()
    {

        if (currentCP_Position == null || currentCP_Position == Vector3.zero)
        {
            currentCP_Position = CheckPoints[0].transform.position;
        }
        else { loadFromCP = true; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
