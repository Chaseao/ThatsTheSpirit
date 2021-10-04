using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForDeath : MonoBehaviour
{
    Player player;
    private Animator playerAnim;

    private void Start()
    {
        player = GetComponent<Player>();
        playerAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Deadly"))
        {

            StartCoroutine(player.Die());

            
        }

       
    }

    public IEnumerator WaitASec(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
    }
}
