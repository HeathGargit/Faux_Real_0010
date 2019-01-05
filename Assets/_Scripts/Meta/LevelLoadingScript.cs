/*---------------------------------------------------------
File Name: LevelLoadingScript.cs
Purpose: Cheap nasty script to change the level. for buttons in the UI to use.
Author: Heath Parkes (heath@gargit.games)
Modified: 2019-01-05
---------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadingScript : MonoBehaviour {

    public void LoadLevel(string levelname)
    {
        GameObject.FindGameObjectWithTag("MetaController").GetComponent<MetaController>().LoadLevel(levelname);
    }
}
