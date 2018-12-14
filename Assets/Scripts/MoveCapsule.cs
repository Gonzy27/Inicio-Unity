using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCapsule : MonoBehaviour {

    private float moveHorizontal;
    private float moveVertical;
    public float speed;
    public Vector3 movement;

    public CharacterController characterController;

    public LocalNavMeshBuilder NAV;

    public float gravity;

    private float gravity_velocity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        gravity_velocity -= gravity * Time.deltaTime;
        characterController.Move(new Vector3(0.0f, gravity_velocity, 0.0f));

        if (characterController.isGrounded)
            gravity = 0;
   
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        movement =new Vector3(moveHorizontal,0.0f,moveVertical);
        characterController.Move(movement * speed * Time.deltaTime);

        //Debug.Log("Rot: " + movement.ToString());
        if(movement != Vector3.zero) 
            transform.rotation = Quaternion.LookRotation(movement);

        if (characterController.isGrounded)
        {
            Debug.Log("Piso");
        }
        if(Input.GetKeyDown(KeyCode.Space) ){
            characterController.Move(new Vector3(0.0f,5.0f,0.0f));
        }
    }
}
