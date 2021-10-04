using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerChoiceController : MonoBehaviour
{
    [Header("Configurable Settings")]
    [SerializeField] float scrollSpeed;

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

    public IEnumerator LoadOptionsText(string endText)
    {
        currentText = "";
        foreach (char letter in endText)
        {
            yield return new WaitForSeconds(scrollSpeed);
            currentText += letter;
            text.text = currentText;
        }
    }

    public void ClearOptions()
    {
        text.text = "";
    }
}
