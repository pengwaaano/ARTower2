using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    public bool canShoot = true;

    public float gunCooldown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.anyKeyDown && canShoot)
        {
            Fire();
            Debug.Log("HOW DO I SHOT WEB");
            gunCooldown = Time.time + 0.12f;
            canShoot = false;
        }

        if (!canShoot && Time.time > gunCooldown) // once he can't shoot, and enough time passed
            canShoot = true;
		
	}

	void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

}
