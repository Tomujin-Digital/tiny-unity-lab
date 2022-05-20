using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePuzzle : MonoBehaviour
{
    [SerializeField]
    private Transform shapePalace;

    private Vector2 initialPosition;

    private float deltaX, deltaY;

    public static int solutionCount;

    private bool locked;

    void Start()
    {
        initialPosition = transform.position;
        shapePalace = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                  if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                  break;
                case TouchPhase.Ended:
                    if(Mathf.Abs(transform.position.x - shapePalace.position.x) <= 0.5f &&
                    Mathf.Abs(transform.position.y - shapePalace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(shapePalace.position.x, shapePalace.position.y);
                        solutionCount++;
                        print(solutionCount);
                        locked = true;
                    }
                    else transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    break;
            }
        }
        
    }
}
