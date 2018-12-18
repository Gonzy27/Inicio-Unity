using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FireController : MonoBehaviour {

    public GameObject bullet;
    public float fireRate;

    private float nextFire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject new_bullet = (GameObject)Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
            new_bullet.SetActive(true);

            //new_bullet.GetComponent<BulletFire>().fireAngle(transform.parent.gameObject.GetComponent<MoveCapsule>().movement);

        }

    }

}
