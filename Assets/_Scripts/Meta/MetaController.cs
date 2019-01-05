/*---------------------------------------------------------
File Name: MetaController.cs
Purpose: Controls the meta parts of the game, such as level loading and logins and stuff.
Author: Heath Parkes (heath@gargit.games)
Modified: 2019-01-05
---------------------------------------------------------*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaController : MonoBehaviour {

    private void Awake()
    {
        //Singleton Control to make sure this object available from all scenes and isn't reset, etc.
        int singletonCount = FindObjectsOfType<MetaController>().Length;
        if (singletonCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
}
