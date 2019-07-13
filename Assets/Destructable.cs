using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particles;
    public SpriteRenderer rend;
    public Collider2D col;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHit()
    {
        StartCoroutine(waitForASecPlz());
    }

    private IEnumerator waitForASecPlz()
    {
        yield return new WaitForSeconds(.15f);
        Debug.Log("Ow Am hit");
        particles.Play();
        col.enabled = false;
        rend.enabled = false;
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
