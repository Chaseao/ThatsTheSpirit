using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ambiance : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType<ambiance>().Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "End Credits")
        {
            Destroy(gameObject);
        }
    }
}
