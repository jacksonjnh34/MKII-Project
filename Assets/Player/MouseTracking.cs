using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracking : MonoBehaviour
{
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
        Vector2 mouse_pos = Input.mousePosition;
        mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);

        //Calculates the direction our character should be facing
        Vector2 direction = new Vector2(
            mouse_pos.x - transform.position.x,
            mouse_pos.y - transform.position.y
            );
        
        //sets the top of our character to always face the direction of our mouse
        transform.up = direction;
    }
}
