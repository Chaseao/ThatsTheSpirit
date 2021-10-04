using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CharacterController2D controller;

    //Configurable Settings
    public float runSpeed = 40f;
    float horizontalMove = 0f;

    Vector2 offscreen = new Vector2(100, 0);

    [SerializeField] 
    float respawnDelay = 1f;

    //State Variables
    bool jump = false;
    bool platformerOn = true;

    Vector2 startingPos;

    GameObject JumpSound;

  
    

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (platformerOn)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
      

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;

               
            }
        }
    }

    public void enablePlatformer(bool enable)
    {
        platformerOn = enable;
    }

    public void ResetCharacter()
    {
        transform.position = startingPos;
        horizontalMove = 0;
    }

    public IEnumerator Die()
    {
        enablePlatformer(false);
        SendOffScreen();

        yield return new WaitForSeconds(respawnDelay);
        ResetCharacter();
        enablePlatformer(true);
    }

   

    public void SendOffScreen()
    {
        transform.position = offscreen;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    
}
