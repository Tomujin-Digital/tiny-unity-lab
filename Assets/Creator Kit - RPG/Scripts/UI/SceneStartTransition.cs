using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartTransition : MonoBehaviour
{
    private Vector3 targetPosition = new Vector3(0, -10, 0);
    // Start is called before the first frame update
    void Start()
    {
        transform.position = targetPosition;

    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
