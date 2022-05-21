using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string ScreenName;
    public Vector2 PlayerPosition;
    public VectorValue playerStorage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStorage.initialValue = PlayerPosition;
            SceneManager.LoadSceneAsync(ScreenName);
        }
    }
    public void OnClick(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
