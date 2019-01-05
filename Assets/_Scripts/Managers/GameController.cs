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

    // Use this for initialization
    void Start()
    {
        m_GameState = GameState.Init;
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
        //Show the pause menu
        m_UI.ShowPauseMenu();
    }

    private void UnPauseGame()
    {
        //Hide the pause menu
        m_UI.HidePauseMenu();
    }
}
