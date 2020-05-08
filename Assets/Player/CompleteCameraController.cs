using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteCameraController : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    private Vector3 oldMouseDir;

    private Vector3 newMouseDir;

    private Vector3 mouseOffset;

    private Vector3 calculatedTransform;

    private float xClamp = 5.0f;

    private float yClamp = 2.0f;

    // Use this for initialization
    void Start()
    {

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        oldMouseDir = player.GetComponent<MouseTracking>().mouseDirection;

    }

    void Update()
    {
        mouseOffset = player.GetComponent<MouseTracking>().mouseDirection - oldMouseDir;

        oldMouseDir = player.GetComponent<MouseTracking>().mouseDirection;

        mouseOffset = mouseOffset / 2;

        //offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {

        calculatedTransform = player.transform.position + offset + mouseOffset;

        calculatedTransform.x = Mathf.Clamp(calculatedTransform.x, player.transform.position.x - xClamp, player.transform.position.x + xClamp);
        calculatedTransform.y = Mathf.Clamp(calculatedTransform.y, player.transform.position.y - yClamp, player.transform.position.y + yClamp);
        calculatedTransform.z = -20;


        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = calculatedTransform;
    }
}
