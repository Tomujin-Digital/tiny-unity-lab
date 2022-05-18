using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public string transitionSceneName = "Hub";

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadNextScene();
        }

    }

    public void LoadNextScene()
    {

        StartCoroutine(LoadScenes(transitionSceneName));

    }

    IEnumerator LoadScenes(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);


        SceneManager.LoadScene(sceneName);
    }


    
}
