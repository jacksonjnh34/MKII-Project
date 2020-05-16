using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
    	if(collision.gameObject.tag.Equals("Edge"))
    	{
    		//Damage code here?
    	}
    	else
    	{
    		Destroy(gameObject);
    	}

    	Destroy(gameObject);
    	
    }
}
