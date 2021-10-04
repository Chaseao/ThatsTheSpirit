using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    int[] possibleNextScenes = new int[5];
    [SerializeField] TextAsset sceneDialogue;
    [SerializeField] TextAsset sceneChoices;
    [SerializeField] GameObject sceneLayout;
    [SerializeField] bool hasChoices;
    [SerializeField] bool loadsNewScene;
    [SerializeField] bool isEndingLevel;

    public List<string> GetSceneInfo()
    {
        int skipper = 0;
        List<string> sceneText = new List<string>();
        foreach (string line in sceneDialogue.text.Split('\n'))
        {
            if (skipper != 0)
            {
                sceneText.Add(line);
            }

            else
            {
                skipper = 1;
            }
        }

        return sceneText;
    }

    public int GetNextScene(int userInput)
    {
        return possibleNextScenes[userInput];
    }

    public int GetDaniImageIndex()
    {
        Debug.Log("Looking In Player Script");
        setupPossibleNextScenes();
        Debug.Log("Setup Possible Next Scenes done: " + possibleNextScenes[4]);
        return possibleNextScenes[4];
    }

    private void setupPossibleNextScenes()
    {
        string firstLine = sceneDialogue.text.Split('\n')[0];
        Debug.Log("Got the first Line: " + firstLine);
        int counter = 0;
        foreach (string num in firstLine.Split(' '))
        {
            Debug.Log("Num Got: " + num);
            possibleNextScenes[counter] = int.Parse(num);
            counter++;
        }
    }

    public string GetPlayerOptions()
    {
        return sceneChoices.text;
    }

    public GameObject GetSceneLayout()
    {
        return sceneLayout;
    }

    public bool CheckIfHasChoices()
    {
        return hasChoices;
    }

    public bool SceneloadNewScene()
    {
        return loadsNewScene;
    }

    public bool GetIsEndingScene()
    {
        return isEndingLevel;
    }
}

