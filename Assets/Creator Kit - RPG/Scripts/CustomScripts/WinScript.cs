using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{

    private int pointsToWin;
    private int currentPoints;
    public GameObject myShapes;

    void Start()
    {
        pointsToWin = myShapes.transform.childCount;   
    }

  
    void Update()
    {
        if(currentPoints >= pointsToWin) {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void AddPoints() {
        currentPoints++;
    }
}
