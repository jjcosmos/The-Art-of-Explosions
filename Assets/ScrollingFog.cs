using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingFog : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float currentscroll;
    Material _material;
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        currentscroll += speed * Time.deltaTime;
        _material.mainTextureOffset = new Vector2(currentscroll, Mathf.Sin(currentscroll * 30)/10);
    }
}
