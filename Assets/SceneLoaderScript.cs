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

    void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
        GameObject.Find("LoaderTransition").SetActive(false);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
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
