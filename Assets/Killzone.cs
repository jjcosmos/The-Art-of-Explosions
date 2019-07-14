using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{
    // Start is called before the first frame update
    bool loading;
    PlayerAnimation playeranim;
    void Start()
    {
        playeranim = FindObjectOfType<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!loading && collider2D.CompareTag("Player"))
        {
            FadeScreen.fadeOut();
            StartCoroutine(reloadLevel());
            loading = true;
            playeranim.Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (!loading && collision2D.collider.CompareTag("Player"))
        {
            FadeScreen.fadeOut();
            StartCoroutine(reloadLevel());
            loading = true;
            playeranim.Die();
        }
    }
    IEnumerator reloadLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
