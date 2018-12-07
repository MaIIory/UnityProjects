using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    private LevelManager _levelManager;

    public void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        _levelManager.LoadLevel("Lose");
    }
}
