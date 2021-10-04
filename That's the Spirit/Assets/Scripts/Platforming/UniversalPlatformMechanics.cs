using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalPlatformMechanics : MonoBehaviour
{
    [SerializeField] int actID;
    [SerializeField] int sceneID;

    [SerializeField] int currentAct;
    [SerializeField] int currentScene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAct == actID && currentScene == sceneID)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
