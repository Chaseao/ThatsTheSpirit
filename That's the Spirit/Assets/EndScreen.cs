using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [Header("Configurables")]
    [SerializeField] float endingDelay = 3f;
    [SerializeField] int creditSceneIndex = 3;

    // Cached References
    ActLoader actLoader;

    private void Start()
    {
        StartCoroutine(LoadEnding());
    }

    private IEnumerator LoadEnding()
    {
        actLoader = GameObject.FindGameObjectWithTag("Act Loader").GetComponent<ActLoader>();
        yield return StartCoroutine(actLoader.Unfade());
        yield return new WaitForSeconds(endingDelay);
        StartCoroutine(actLoader.LoadEnding(creditSceneIndex));
    }
}
