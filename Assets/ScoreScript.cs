using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue;
    //public static int livesValue;
    Text Score;
    //Text Lives;
    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<Text>();
       // Lives = GetComponent<Text>();
        //PlayerCollider = GameObject.FindObjectOfType<PlayerCollsion>();
        pelletEaters = GameObject.FindObjectsOfType<PelletEater>();
        p = GameObject.FindObjectOfType<PelletEater>(); //referencing pellet eater from
        p2 = GameObject.FindObjectOfType<PelletEater>(); //referencing pellet eater from
    }
    static PelletEater p;
    static PelletEater p2;
    PelletEater[] pelletEaters = { p, p2 };
    //PlayerCollsion PlayerCollider;
    // Update is called once per frame
    void Update()
    {
        scoreValue = p.GetScore();
        // livesValue = PlayerCollider.numLives;
        //Lives.text = "Lives: " + livesValue;
        if (GameManager.Level == 1)
        {
            Score.text = "Score P1: " + p.GetScore();
        }
        else
        {
            Score.text = "Score P1: " + p.GetScore2();
        }
    }
}
