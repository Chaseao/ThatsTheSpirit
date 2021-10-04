using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DaniTextController : MonoBehaviour
{
    [Header("Configurable Settings")]
    [SerializeField] float scrollSpeed;

    //Conditons
    bool sceneFinished = true;
    bool firstLineRead = false;

    // State variables
    string currentText;
    float baseScrollSpeed;

    //Cached References
    TextMeshPro text;
    LevelManager sceneManager;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        sceneManager = FindObjectOfType<LevelManager>();
        baseScrollSpeed = scrollSpeed;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            scrollSpeed = 0.005f;
        }
        else
        {
            scrollSpeed = baseScrollSpeed;
        }

    }

    public IEnumerator LoadSceneText(List<string> sceneScript)
    {
        sceneFinished = false;
        while (sceneFinished == false)
        {
            yield return StartCoroutine(loadNextScene(sceneScript));
        }
    }

    private IEnumerator loadNextScene(List<string> nextSceneText)
    {
        firstLineRead = true;

        foreach (string line in nextSceneText)
        {
            bool spacePushed = false;
            while (!(spacePushed || firstLineRead))
            {
                spacePushed = Input.GetKeyDown(KeyCode.Space);
                yield return null;
            }

            firstLineRead = false;

            yield return StartCoroutine(LoadNextLetter(line));
        }

        Debug.Log("Finished Scene");
        sceneFinished = true;
    }

    private IEnumerator LoadNextLetter(string endText)
    {
        currentText = "";
        foreach (char letter in endText)
        {
            yield return new WaitForSeconds(scrollSpeed);
            currentText += letter;
            text.text = currentText;
        }
    }
}
