using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnim;

    public void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    //Sorry for the if statements. such sloppy code ;-;
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            playerAnim.SetBool("isWalking", true);

        }
        else
        {
            playerAnim.SetBool("isWalking", false);

        }


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAnim.SetTrigger("Jump");

        }
        else
        {
            playerAnim.SetBool("isJumping", false);
        }

    }


}
