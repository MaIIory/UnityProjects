using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{

    public int min, max;
    private int guess;
    public Text text;
    public int nbOfguesses;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        max++;
        guess = Random.Range(min, max);
        text.text = "My first guess is:\n" + guess;
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }

    void NextGuess()
    {
        nbOfguesses--;
        if (nbOfguesses <= 0)
            SceneManager.LoadScene("Win");
        guess = Random.Range(min, max);
        text.text = "My next guess is:\n" + guess;
    }
}
