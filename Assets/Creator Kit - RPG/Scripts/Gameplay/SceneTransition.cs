using System.Collections;
using System.Collections.Generic;
using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string ScreenName;
    public Vector2 PlayerPosition;
    public VectorValue playerStorage;
    public GameModel model = Schedule.GetModel<GameModel>();
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // playerStorage.initialValue = PlayerPosition;
            SceneManager.LoadSceneAsync(ScreenName);
        }
    }
    void Update() {
        
    }
    public void OnClick(string sceneName)
    {

        model.inventory.Clear();
        // model.wwwwwwwwdw(, model.GetInventoryCount);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
