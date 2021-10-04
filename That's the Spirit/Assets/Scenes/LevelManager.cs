using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //State Variables
    private int currentScene = -1;
    private int choiceNumber = 0;
    bool nextSceneReady = true;
    bool choiceRecieved = false;
    bool sceneStarting = true;
    bool sceneFinished = false;

    // Configruable Settings
    [SerializeField] Sprite[] daniImagesForAct;

    // Cached References
    Scene[] scenes;
    DaniTextController textController;
    PlayerChoiceController playerChoiceController;
    GameObject loadedScene;
    GameObject player;
    [SerializeField] GameObject playerObject;
    ActLoader actLoader;


    private void Start()
    {
        textController = FindObjectOfType<DaniTextController>();
        playerChoiceController = FindObjectOfType<PlayerChoiceController>();
        actLoader = GameObject.FindGameObjectWithTag("Act Loader").GetComponent<ActLoader>();
    }

    private void Update()
    {
        if (nextSceneReady)
        {
            Debug.Log("Scene preparation beginning");
            nextSceneReady = false;
            StartCoroutine(PrepareNextScene());
        }
    }

    public IEnumerator PrepareNextScene()
    {
        if (currentScene != -1)
        {
            ClearScene();
        }
        ClearPlayerOptions();
        SetCurrentScene();
        if (!sceneFinished)
        {
            Debug.Log("About to set dani");
            SetDaniImage();
            if (sceneStarting)
            {
                Debug.Log("Starting Scene");
                yield return StartCoroutine(actLoader.Unfade());
                Debug.Log("Finished Loading");
                sceneStarting = false;
            }
            yield return StartCoroutine(LoadText());

            if (scenes[currentScene].CheckIfHasChoices())
            {
                Debug.Log("Asking For Choices" + currentScene);
                yield return StartCoroutine(GetPlayerChoice());
            }
            else
            {
                Debug.Log("Not Asking For Choices : Scene " + currentScene);
                choiceNumber = 0;
                //yield return StartCoroutine(CheckForSpaceBar());
            }

            nextSceneReady = true;
        }
    }

    private IEnumerator LoadText()
    {
        yield return textController.LoadSceneText(GetNextScene(choiceNumber));
    }

    public void SetPlayerChoice(int playerChoice)
    {
        choiceRecieved = true;
        choiceNumber = playerChoice;
    }

    private IEnumerator GetPlayerChoice()
    {
        yield return StartCoroutine(DisplayPlayerChoices());
        LoadScene();
        choiceRecieved = false;
        while (!choiceRecieved)
        {
            yield return null;
        }
    }

    private void ClearPlayerOptions()
    {
        playerChoiceController.ClearOptions();
    }

    private void LoadScene()
    {
        loadedScene = Instantiate(scenes[currentScene].GetSceneLayout());
        player = Instantiate(playerObject);
    }

    private void ClearScene()
    {
        Destroy(player);
        Destroy(loadedScene);
    }

    private IEnumerator DisplayPlayerChoices()
    {
        string playerOptions = scenes[currentScene].GetPlayerOptions();
        yield return playerChoiceController.LoadOptionsText(playerOptions);
    }

    private void SetCurrentScene()
    {
        bool loadsNewScene = false;
        bool isEndingScene = false;

        scenes = GetComponents<Scene>();
        if (currentScene != -1)
        {
            loadsNewScene = scenes[currentScene].SceneloadNewScene();
            isEndingScene = scenes[currentScene].GetIsEndingScene();
            Debug.Log("LOADING ENDING");
            currentScene = scenes[currentScene].GetNextScene(choiceNumber);
        }
        else
        {
            currentScene = actLoader.GetNextScene();
        }
        if (loadsNewScene)
        {
            if (isEndingScene)
            {
                Debug.Log("STILL LOADING SCENE " + currentScene);
                StartCoroutine(actLoader.LoadEnding(currentScene));
            }
            else 
            {
                StartCoroutine(actLoader.SetNextScene(currentScene));
            }
            sceneFinished = true;
            
        }
        
        Debug.Log("Current Scene: " + currentScene);
    }

    public List<string> GetNextScene(int optionNumber)
    {
        scenes = GetComponents<Scene>();

        if(currentScene == -1)
        {
            currentScene = 0;
            return scenes[0].GetSceneInfo();
        }

        return scenes[currentScene].GetSceneInfo();
    }

    public int GetCurrentScene()
    {
        return currentScene;
    }

    public void SetDaniImage()
    {
        GameObject dani = FindObjectOfType<daniEmptyScript>().gameObject;

        if (currentScene != -1)
        {
            Debug.Log("Getting Dani Index");
            int daniImageIndex = scenes[currentScene].GetDaniImageIndex();
            Debug.Log("Got Dani Index: " + daniImageIndex);
            dani.GetComponent<SpriteRenderer>().sprite = daniImagesForAct[daniImageIndex];
            Debug.Log("Dani Set");
        }
    }

    private IEnumerator CheckForSpaceBar()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    //==============================================TO BE ADDED
    public bool CheckIsChoiceNeeded()
    {
        bool choiceNeeded = false;
        return choiceNeeded;
    }
}
