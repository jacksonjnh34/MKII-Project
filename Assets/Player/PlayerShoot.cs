using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Rigidbody2D projectile;
    [Range(1, 1000)]
    public float projectileSpeed = 10f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

        if (isReloading)
        {
            return;
        }

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        
        if (Input.GetButtonDown("Fire1") && isReloading == false)
        {
            currentAmmo--;
            Rigidbody2D clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);

            clone.AddForce(transform.up * projectileSpeed);

            //This is just a check delete when done
            print(currentAmmo);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player hit wall");
    }
}
