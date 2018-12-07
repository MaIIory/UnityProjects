using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void Awake()
    {
        HitPlatformController.PlatformCounter = 0;
    }

    public void LoadLevel(string levelName)
    {
        print("Following level will be loaded: " + levelName);
        SceneManager.LoadScene(levelName);
    }

    public void BrickDestroyed()
    {
        print("Platform counter: " + HitPlatformController.PlatformCounter);

        if (HitPlatformController.PlatformCounter <= 0)
            LoadNextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
