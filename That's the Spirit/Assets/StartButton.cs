using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        StartCoroutine(FindObjectOfType<ActLoader>().LoadGame());
    }
}
