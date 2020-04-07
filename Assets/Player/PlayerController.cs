using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Speed
    [Range(1, 10)]
    public float speed = 8f;

    //able to set player sprite in editor
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        //sets our stabilizer to have to same location as our player
        transform.position = player.transform.position;

        //tells us if we hit our movement keys or not (horizontal being AD or left right arrows and vertical being WS or up down arrows)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Actually moves the player (multiply speed by time in order to get acceleration)
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);

        //sets our player position to be our stabilizer position
        player.transform.position = transform.position;
        
        // the jank stabilizer code is because player movement is tied to rotation of our object, with mouse tracking it gets thrown off. We simply use an object we don't track rotation of and tie it to our player position to fix it.
    }
}
