using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballCaster : MonoBehaviour
{
    // Start is called before the first frame update
    public bool HasFireballOut = false;
    public bool canCast;
    public PlayerAnimation playerAnim;
    public Fireball currentFireball;
    public Queue fireballs;
    [SerializeField] Fireball[] fireballArray;
    [SerializeField] float fireballspeed;
    [SerializeField] float verticalOffset;
    [SerializeField] float horizontalOffset;

    void Start()
    {
        fireballs = new Queue();
        foreach (Fireball fire in fireballArray)
        {
            fireballs.Enqueue(fire);
            Debug.Log("Enqueue " + fire.name);
            fire.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") )
        {
            if (!HasFireballOut && fireballs.Count > 0)
            {
                spawnFireball(playerAnim.facingRight);
            }
            else
            {
                if(currentFireball != null && currentFireball.canDetonate)
                    currentFireball.Detonate();
            }
        }
    }

    private void spawnFireball(bool isFacingRight)
    {
        Fireball castedFireball = (Fireball)fireballs.Dequeue();
        Debug.Log("Dequeue'd " + castedFireball.name);
        
        castedFireball.gameObject.SetActive(true);
        currentFireball = castedFireball;

        if (isFacingRight)
        {
            castedFireball.transform.position = (Vector2)playerAnim.transform.position + new Vector2(horizontalOffset, verticalOffset);
            castedFireball.transform.localScale = Vector2.one;
            castedFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(fireballspeed, 0);
        }
        else
        {
            castedFireball.transform.position = (Vector2)playerAnim.transform.position + new Vector2(-horizontalOffset, verticalOffset);
            castedFireball.transform.localScale = new Vector2(-1, 1);
            castedFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-fireballspeed, 0);
        }

        HasFireballOut = true;
    }
}
