using System.Collections.Generic;
using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainQuestRPG : MonoBehaviour
{
    GameModel model = Schedule.GetModel<GameModel>();

    private void Start() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && model.HasInventoryItem("Square") && model.HasInventoryItem("Triangle") && model.HasInventoryItem("Circle"))
        {
            SceneManager.LoadScene("PuzzleDraw");;
        }
    }
}
