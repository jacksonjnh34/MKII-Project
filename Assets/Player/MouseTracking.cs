using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracking : MonoBehaviour
{

    public Vector3 mousePosition;

    public Vector3 mouseDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
    }

    void faceMouse()
    {
        //sets our mouse position relative to its position in the game world
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Calculates the direction our character should be facing
        mouseDirection = new Vector3(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y,
            0
            ); 
        
        //sets the top of our character to always face the direction of our mouse
        transform.up = mouseDirection;
    }
}
