using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCredits : MonoBehaviour
{
    [Header("Configurables")]
    [SerializeField] float endingDelay = 3f;
    [SerializeField] float textScrollSpeed = 1f;
    [SerializeField] float endingDuration = 88f;

    // Cached References
    ActLoader actLoader;

    // State Variables
    bool sceneReady = false;
    

    private void Start()
    {
        actLoader = GameObject.FindGameObjectWithTag("Act Loader").GetComponent<ActLoader>();
        StartCoroutine(StartScene());
    }

    private void Update()
    {
        if (sceneReady)
        {
            ScrollText();
        }
    }

    private IEnumerator StartScene()
    {
        yield return actLoader.Unfade();
        yield return new WaitForSeconds(endingDelay);
        sceneReady = true;
        yield return new WaitForSeconds(endingDuration);
        sceneReady = false;
        yield return new WaitForSeconds(endingDelay);
        actLoader.LoadTitleScreen();
    }

    private void ScrollText()
    {
        float deltaY = textScrollSpeed * Time.deltaTime;
        Vector3 deltaPos = new Vector3(0, deltaY, 0);
        transform.position = transform.position + deltaPos;
    }
}
