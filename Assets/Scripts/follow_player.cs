using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour {

    public GameObject player;

    private Vector3 camera_movement;

    // Use this for initialization
    void Start()
    {
        camera_movement = player.transform.position - transform.position;

        // Debug.Log(player.transform.position.y);

        //Debug.Log(transform.position.y);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //transform.LookAt(player.transform);
        transform.position = player.transform.position - camera_movement;

    }
}
