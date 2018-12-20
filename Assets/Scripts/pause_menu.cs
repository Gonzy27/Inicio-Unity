using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause_menu : MonoBehaviour
{
    private bool game_paused;
    public GameObject pause_menu_UI;

    // Use this for initialization
    void Start()
    {
        game_paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (game_paused)
            {

                Resume();

            }
            else
            {

                Time.timeScale = 0.0f;
                pause_menu_UI.SetActive(true);
                game_paused = true;

            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pause_menu_UI.SetActive(false);
        game_paused = false;
    }
}
