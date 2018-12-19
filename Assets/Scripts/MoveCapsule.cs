using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveCapsule : MonoBehaviour
{

    private float moveHorizontal;
    private float moveVertical;
    private bool gets_shoot;
    private Vector3 hit_direction;
    private Vector3 initial_position;

    //invisibilidad
    public float invisibility_lenght;
    private float invisibility_counter;
    public float flash_lenght;
    private float flash_counter;
    public MeshRenderer mesh_renderer;

    public Rigidbody rb;

    //velocidad, salto, gravedad y fuerza knockback
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float knockback_force;

    //Texto
    public Text health_points;
    public Text game_over;

    //¿muerto?
    private bool player_dead;
    private bool restart;

    public int health;

    //movimiento
    public Vector3 movement = Vector3.zero;
    public CharacterController characterController;


    public LocalNavMeshBuilder NAV;

    // Use this for initialization
    void Start()
    {
        health = 100;
        health_points.text = "Vida: " + health;
        gets_shoot = false;
        game_over.text = "";
        player_dead = false;
        // let the gameObject fall down
        //gameObject.transform.position = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_dead)
        {
            if (characterController.isGrounded)
            {
                moveHorizontal = Input.GetAxis("Horizontal");
                moveVertical = Input.GetAxis("Vertical");
                movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

                //Debug.Log("Rot: " + movement.ToString());
                if (movement != Vector3.zero)
                    transform.rotation = Quaternion.LookRotation(movement);


                movement = movement * speed;


                if (Input.GetKeyDown(KeyCode.Space))
                {
                    movement.y = jumpSpeed;
                }
            }
            else  // Here I independently allow for both X and Z movement. 
            {
                movement.x = Input.GetAxis("Horizontal") * speed;
                movement.z = Input.GetAxis("Vertical") * speed;
                transform.rotation = Quaternion.LookRotation(new Vector3(movement.x, 0.0f, movement.z));
                //movement = new Vector3(moveHorizontal, movement.y, moveVertical);

            }



            //aplica gravedad
            movement.y = movement.y - (gravity * Time.deltaTime);

            if (gets_shoot)
            {
                transform.position += hit_direction * knockback_force * Time.deltaTime;

                if (Vector3.Distance(transform.position, initial_position) > 4.0f)
                {
                    gets_shoot = false;
                }


            }
            else
                characterController.Move(movement * Time.deltaTime);

            if (invisibility_counter > 0)
            {
                invisibility_counter -= Time.deltaTime;
                flash_counter -= Time.deltaTime;
                if (flash_counter <= 0)
                {
                    flash_counter = flash_lenght;
                    mesh_renderer.enabled = !mesh_renderer.enabled;
                }
                if (invisibility_counter <= 0)
                {
                    mesh_renderer.enabled = true;
                }
            }
        }
        else
        {
            movement.y = movement.y - (gravity * Time.deltaTime);
            movement.x = 0.0f;
            movement.z = 0.0f;
            characterController.height = 1.0f;
            characterController.Move(movement * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(new Vector3(0.0f, 90.0f, 0.0f));
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    //void OnTriggerEnter(Collider other
    void OnCollisionEnter(Collision collision)

    {

        //if (cronometro < Time.timeSinceLevelLoad)
        if (invisibility_counter <= 0)
        {

            if (collision.gameObject.tag == "enemy")
            {

                Debug.Log("Siente el choque");
                //cronometro = Time.timeSinceLevelLoad + 3.0f; //crónometro

                initial_position = transform.position;
                hit_direction = collision.transform.position - transform.position;
                hit_direction = -hit_direction.normalized;

                Debug.Log("pop");
                gets_shoot = true;
                invisibility_counter = invisibility_lenght;
                flash_counter = flash_lenght;
                if (health > 5)
                {
                    health -= 5;
                    health_points.text = "Vida: " + health;
                    characterController.Move(-movement * Time.deltaTime);
                }
                else
                {
                    Debug.Log("RIP");
                    health_points.text = "Vida: 0";
                    game_over.text = "BOI YOU DEAD";
                    player_dead = true;
                }
            }
        }
    }
}