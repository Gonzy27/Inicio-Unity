using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_controller : MonoBehaviour {

    private int health;
    //private bool regenerate;

    public TextMesh health_points;

    public CharacterController characterController;

    public float velocity;

    public GameObject floor;

    // Use this for initialization
    void Start () {
        health = 100;
        health_points.text = health+"/100";
        //regenerate = false;
    }

    // Update is called once per frame
    void Update()
    {/**
        if (health == 100)
        {
            regenerate = false;
        }
        if (regenerate == true)
        {
            health += 1;
            heatlh_points.text = health + "/100";
        }
        */
        characterController.Move(new Vector3 (velocity * Time.deltaTime,0.0f,0.0f));
        //Debug.Log(transform.position.x);
        if (transform.position.x > 4.0f)
        { 
            velocity = -3.0f;
        }
        else if (transform.position.x < -4.0f)
        {
            velocity = 3.0f;
        }


    }
    void OnTriggerEnter(Collider other){

        if (other.gameObject.tag == "bullet")
        {
            Debug.Log("Bala");
            Destroy(other.gameObject);
            if (health > 10)
            {
                health -= 10;
                health_points.text = health + "/100";
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "Player")
        {
           // Debug.Log("Siente el choque");
     
        }
    }

    /**
    void OnTriggerExit(Collider other)
    {
        regenerate = true;
    }
    */
}
    
