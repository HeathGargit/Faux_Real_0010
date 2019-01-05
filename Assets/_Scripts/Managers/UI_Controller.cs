/*---------------------------------------------------------
File Name: UI_Controller.cs
Purpose: Controls the UI to show different canvases (pause menu, HUD, etc).
Author: Heath Parkes (heath@gargit.games)
Modified: 2019-01-05
---------------------------------------------------------*/

using UnityEngine;

public class UI_Controller : MonoBehaviour {

    public Canvas m_PauseMenu;

	// Use this for initialization
	void Start ()
    {
        m_PauseMenu.gameObject.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowPauseMenu()
    {
        m_PauseMenu.gameObject.SetActive(true);
    }

    public void HidePauseMenu()
    {
        m_PauseMenu.gameObject.SetActive(false);
    }
}
