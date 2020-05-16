using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    	//Deletes projectile after 5 seconds
        Destroy(gameObject, 5.0f);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
    	Debug.Log("OnCollisionEnter2D");
    	if(collision.gameObject.tag.Equals("Edge"))
    	{
    		Destroy(gameObject);
    	}
    	else
    	{
    		//Damage code here?
    	}

    	
    	
    }
}
