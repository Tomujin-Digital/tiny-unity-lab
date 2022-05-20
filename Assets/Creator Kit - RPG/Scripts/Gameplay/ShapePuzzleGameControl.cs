using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShapePuzzleGameControl : MonoBehaviour
{
    [SerializeField]
    private GameObject winText;

    void Update(){
      if(ShapePuzzle.solutionCount >= 10) SceneManager.LoadScene("StudyScene");
    }
}
