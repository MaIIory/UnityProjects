using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{

    public int min, max;
    private int _min, _max;
    private int guess;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        _min = min;
        _max = max;
        print("=============================================");
        print("Welcome to Number Wizard! Let's the magic begin!");
        print("Chose any number between " + _min + " and " + + _max);
        _max++;
        guess = _max / 2;
        print("Is your number is " + guess + "?");
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _max = guess;
            NextGuess();
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            print("I won!");
            StartGame();
        }

    }

    void NextGuess()
    {
        guess = (_min + _max) / 2;
        print("Is your number is " + guess + "?");
        print("Click up arrow = higher, down arrow = lower, Enter = equal");
    }
}
