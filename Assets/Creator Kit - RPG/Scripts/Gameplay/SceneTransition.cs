 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string ScreenName;
    public Transform PlayerPosition;
    // public VectorValue playerStorage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            // playerStorage.initialValue = PlayerPosition.position;
            SceneManager.LoadSceneAsync(ScreenName);
            
        }

    }

}
