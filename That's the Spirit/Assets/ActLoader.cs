using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActLoader : MonoBehaviour
{
    //State Variables
    int nextScene = 0;
    int currentAct = 0;
    
    [Header("Configurable Settings")]
    [SerializeField] float fadeToBlackSpeed = 0.01f;
    [SerializeField] string[] endingScenes;
    [SerializeField] string[] acts;

    // Cached References
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if(FindObjectsOfType<ActLoader>().Length > 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                Destroy(FindObjectOfType<ActLoader>().gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
        currentAct = SceneManager.GetActiveScene().buildIndex;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.tag = "Act Loader";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
        }
    }


    public IEnumerator SetNextScene(int nextSceneNum)
    {
        nextScene = nextSceneNum;
        currentAct++;
        yield return StartCoroutine(FadeToBlack());
        Debug.Log("Fade Complete loading " + acts[currentAct]);
        SceneManager.LoadScene(acts[currentAct]); 
    }

    public IEnumerator LoadGame()
    {
        Debug.Log("Method Called");
        yield return StartCoroutine(FadeToBlack());
        SceneManager.LoadScene(acts[currentAct]);
    }

    public void LoadHelp()
    {
        SceneManager.LoadScene("Help");
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public IEnumerator LoadEnding(int endingSceneNum)
    {
        yield return StartCoroutine(FadeToBlack());
        Debug.Log("Loading " + endingSceneNum + " " + endingScenes[endingSceneNum]);
        SceneManager.LoadScene(endingScenes[endingSceneNum]);
    }

    private IEnumerator FadeToBlack()
    {
        Color temporary = spriteRenderer.color;
        while (temporary.a < 1.0)
        {
            temporary.a += 0.01f;
            spriteRenderer.color = temporary;
            yield return new WaitForSeconds(fadeToBlackSpeed);
        }
    }

    public IEnumerator Unfade()
    {
        Color temporary = spriteRenderer.color;
        while (temporary.a > 0)
        {
            temporary.a -= 0.01f;
            spriteRenderer.color = temporary;
            yield return new WaitForSeconds(fadeToBlackSpeed);
        }
    }

    public int GetNextScene()
    {
        return nextScene;
    }

}
