using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlatformController : MonoBehaviour
{

    static public int PlatformCounter = 0;

    public int PlatformLifePoint;
    public Sprite[] HitSprites;
    public AudioClip BrickDamagedSound;
    public AudioClip BrickDestroyedSound;

    private int _damagedLvl = 0;
    private bool _breakable;
    private LevelManager _levelManager;

    public void Start()
    {
        if (tag == "Breakable")
            _breakable = true;

        _levelManager = FindObjectOfType<LevelManager>();

        if (_breakable)
            PlatformCounter++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(_breakable)
            HandleHit();
    }

    private void HandleHit()
    {
        PlatformLifePoint--;
        _damagedLvl++;

        if (PlatformLifePoint > 0)
        {
            switch (_damagedLvl)
            {
                case 1:
                    GetComponent<SpriteRenderer>().sprite = HitSprites[0];
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().sprite = HitSprites[1];
                    break;
                default:
                    break;
            }
            AudioSource.PlayClipAtPoint(BrickDamagedSound, transform.position);

        }
        else if (PlatformLifePoint <= 0)
        {
            PlatformCounter--;
            _levelManager.BrickDestroyed();
            AudioSource.PlayClipAtPoint(BrickDestroyedSound, transform.position);
            GameObject.Destroy(gameObject);
        }
    }

}
