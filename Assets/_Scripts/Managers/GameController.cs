/*---------------------------------------------------------
File Name: GameController.cs
Purpose: Controls the game, including gameplay states and player input.
Author: Heath Parkes (heath@gargit.games)
Modified: 2019-01-05
---------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    //Game State Tracking Stuff
    enum GameState
    {
        Init, Playing, Paused, EndGame, Reset
    }
    GameState m_GameState;

    //References to UI
    public UI_Controller m_UI;

    //Refernce to the player for pausing and unpausing
    public GameObject m_Player;

    // Use this for initialization
    void Start()
    {
        //set the game state to iitialising
        m_GameState = GameState.Init;

        //hide and lock the mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_GameState)
        {
            case GameState.Init:
                m_GameState = GameState.Playing;
                break;
            case GameState.Playing:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PauseGame();
                }
                break;
            case GameState.Paused:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    UnPauseGame();
                }
                break;
            default:
                break;
        }

    }

    private void PauseGame()
    {
        // Pause the game state
        m_GameState = GameState.Paused;

        //Show the pause menu
        m_UI.ShowPauseMenu();
        //Show the cursor
        Cursor.visible = true;
        //Unlock the mouse
        Cursor.lockState = CursorLockMode.None;

        //set the time scale to stop
        Time.timeScale = 0.0f;

        //stop the players mouse look movement - player movement is handled by timescale and doesn't need to be stopped manually.
        m_Player.GetComponent<MouseLook>().Pause();
    }

    private void UnPauseGame()
    {
        // Pause the game state
        m_GameState = GameState.Playing;

        //Hide the pause menu
        m_UI.HidePauseMenu();
        //hide the cursor
        Cursor.visible = false;
        //Lock the mouse
        Cursor.lockState = CursorLockMode.Locked;

        //set the time scale to move again
        Time.timeScale = 1.0f;

        //start the mouselook again
        m_Player.GetComponent<MouseLook>().UnPause();
    }
}
