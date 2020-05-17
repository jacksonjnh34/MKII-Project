using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Speed
    [Range(1, 10)]
    public float speed = 8f;
    public float sprintSpeed = 16f;
    private float dodgeSpeed = 16f;
    private float dodgeDistance = 20f;
    private float dodgeCooldown = 1.5f;
    public Vector3 mouseDir;
    private float currentTime;
    private float oldTime;
    private float angle;
    private float dodgeY;
    private float dodgeX;
    private Vector3 dodgeV;
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRate = 1f;
    public float staminaRecovery = 1f;
    public bool isStaminaDepleted = false;

    //able to set player sprite in editor
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Current Time
        currentTime = Time.time;
        //Last Time Dodged
        oldTime = Time.time;
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	MouseTracking mouseTracking = player.GetComponent<MouseTracking>();
        mouseDir = mouseTracking.mouseDirection;
        movement();

        //This return statement might be dangerous so sry if that causes problems later. maybe fix somehow?
        if (isStaminaDepleted)
        {
            return;
        }

        if (currentStamina <= 0)
        {
            StartCoroutine(Stamina());
            return;
        }
    }

    void movement()
    {
        //sets our stabilizer to have to same location as our player
        transform.position = player.transform.position;

        //tells us if we hit our movement keys or not (horizontal being AD or left right arrows and vertical being WS or up down arrows)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool moveSprint = Input.GetKey("left shift");
        bool moveDodge = Input.GetKey("space");

        //Actually moves the player (multiply speed by time in order to get acceleration)
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);

        //Sprint
        if (moveSprint == true && isStaminaDepleted == false)
        {
            Vector2 sprint = new Vector2(moveHorizontal, moveVertical);
            transform.Translate(sprint * sprintSpeed * Time.deltaTime);
            maxStamina -= staminaRate;
        }

        //Dodgeroll
        if (moveDodge == true)
        {
            // Obtain the current time.
            currentTime = Time.time;

            if ((currentTime - oldTime) >= dodgeCooldown)
            {
                oldTime = Time.time;
                angle = Mathf.Atan2(mouseDir.y, mouseDir.x);
                dodgeY = dodgeDistance * Mathf.Sin(angle);
                dodgeX = dodgeDistance * Mathf.Cos(angle);
                dodgeV = new Vector3(dodgeX, dodgeY, 0);
                transform.Translate(dodgeV * dodgeSpeed * 0.02f);
                print(angle);
                print(dodgeY);
                print(dodgeX);
            }
        }

        //sets our player position to be our stabilizer position
        player.transform.position = transform.position;
        
        // the jank stabilizer code is because player movement is tied to rotation of our object, with mouse tracking it gets thrown off. We simply use an object we don't track rotation of and tie it to our player position to fix it.
    }

    IEnumerator Stamina()
    {
        isStaminaDepleted = true;
        Debug.Log("Recovering...");

        yield return new WaitForSeconds(staminaRecovery);

        currentStamina = maxStamina;
        isStaminaDepleted = false;
    }
}
