using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canDetonate;
    public fireballCaster caster;
    bool collided;
    public Animator animator;
    public Collider2D collider2D;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        collider2D.enabled = true;
        collided = false;
        canDetonate = true;
        animator.SetBool("isFlying", true);
        animator.SetBool("isDead", false);
        animator.SetBool("isExploding", false);
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public void Detonate()
    {
        collider2D.enabled = false;
        HitDestructablesInRange();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().isKinematic = true;
        caster.currentFireball = null;
        animator.SetBool("isFlying", false);
        animator.SetBool("isDead", false);
        animator.SetBool("isExploding", true);
        StartCoroutine(Deactivate(1.5f));
        canDetonate = false;
        
        

    }

    private void HitDestructablesInRange()
    {
        
        Collider2D[] hits = new Collider2D[] { };
        hits = Physics2D.OverlapCircleAll(transform.position, .8f);
        foreach (Collider2D hitCollider in hits)
        {
            if (hitCollider.GetComponent<Destructable>())
            {
                hitCollider.GetComponent<Destructable>().GetHit();
                Debug.Log("Hit " + hitCollider.name);
            }

            else if (hitCollider.GetComponent<Rigidbody2D>())
            {
                hitCollider.GetComponent<Rigidbody2D>().AddForce((Vector3.Normalize(hitCollider.transform.position - transform.position)) * 250);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (!collided)
        {
            collider2D.enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            caster.currentFireball = null;
            canDetonate = false;
            StartCoroutine(Deactivate(1f));
            collided = true;
            animator.SetBool("isFlying", false);
            animator.SetBool("isDead", true);
        }
    }

    IEnumerator Deactivate(float seconds)
    {
        caster.HasFireballOut = false;
        
        yield return new WaitForSeconds(seconds);
        
        SetInactive();
    }

    private void SetInactive()
    {
        caster.fireballs.Enqueue(this as Fireball);
        this.gameObject.SetActive(false);
    }
}
