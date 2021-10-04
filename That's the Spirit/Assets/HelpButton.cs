using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        FindObjectOfType<ActLoader>().LoadHelp();
    }
}
