using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public Animator animColorFade;
    public AnimationClip fadeColorAnimationClip;

    private Text _text;

    // Use this for initialization
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.fontSize = 47;
        _text.text = "\nNaciśnij 'Enter'\n aby rozpocząć przygodę.";

        if (Input.GetKeyDown(KeyCode.Return))
        {
            animColorFade.SetTrigger("fade");
            Invoke("LoadDelayed", fadeColorAnimationClip.length * .5f);
        }
    }

    public void LoadDelayed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
