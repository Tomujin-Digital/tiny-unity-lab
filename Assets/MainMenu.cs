using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject videoPlayer;
    public int timeToStop;

    
    void Start()
    {
        videoPlayer.SetActive(false);        
    }


    public void PlayGame()
    {
        videoPlayer.SetActive(true);
        Destroy(videoPlayer, timeToStop);
        SceneManager.LoadScene("SchoolsMap"); 
    }
}
