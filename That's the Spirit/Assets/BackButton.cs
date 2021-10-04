using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        FindObjectOfType<ActLoader>().LoadTitleScreen();
    }
}
