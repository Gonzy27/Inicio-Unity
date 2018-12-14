using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

    public Rigidbody rb;

    public float speed;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.forward * speed * Time.deltaTime;;
        Destroy(gameObject, 5);
    }
	
	// Update is called once per frame
	void Update () {

    }

    

}
