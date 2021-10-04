using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    //public AudioClip playerWalking;
    public AudioClip playerJumping;

    public AudioSource playerAud;

    public void Start()
    {
        playerAud = GetComponent<AudioSource>();

    }

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {

            //playerAud.UnPause();
            //playerAud.PlayOneShot(playerWalking);

            
        }
        else
        {
            //playerAud.Pause();
        }
        
        


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAud.UnPause();
            playerAud.PlayOneShot(playerJumping, 0.6F);

            
        }
       
  

    }

}

