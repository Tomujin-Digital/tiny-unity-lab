using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapMovement : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        Vector2 newPosition = new Vector2(player.position.x, player.position.y);
        transform.position = new Vector3(newPosition.x,newPosition.y, -5);
    }
}
