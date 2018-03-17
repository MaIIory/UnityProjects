using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {


    public static MusicPlayer Instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance)
            Destroy(gameObject);
        else
            Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
