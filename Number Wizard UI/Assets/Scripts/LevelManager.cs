using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string levelName)
    {
        print("Following level will be loaded: " + levelName);
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        print("The game is going to quit");
        Application.Quit();
    }
}
