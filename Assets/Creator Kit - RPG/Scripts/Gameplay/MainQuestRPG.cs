using System.Collections.Generic;
using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;

public class MainQuestRPG: MonoBehaviour
{
    GameModel model = Schedule.GetModel<GameModel>();

    private void Start() { }

    private void Update()
    {
        foreach(var i in model.InventoryItems)
        {
            if(model.GetInventoryCount(i) > 0)
            {
                Debug.Log(model.GetInventorySprite(i));
            }
        }
    }
}
