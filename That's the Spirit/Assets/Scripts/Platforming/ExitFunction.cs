using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFunction : MonoBehaviour
{
    [SerializeField] int exitValue;
    LevelManager sceneManager;
    Player playerMovement;
    
    void Start()
    {
        sceneManager = FindObjectOfType<LevelManager>();
        playerMovement = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sceneManager.SetPlayerChoice(exitValue);
            playerMovement.enablePlatformer(false);
        }
    }
}
