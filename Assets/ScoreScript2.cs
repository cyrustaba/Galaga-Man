using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript2 : MonoBehaviour
{
    public static int scoreValue;
    //public static int livesValue;
    Text Score2;
    //Text Lives;
    // Start is called before the first frame update
    void Start()
    {
        Score2 = GetComponent<Text>();
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
        scoreValue = p.GetScore2();
        // livesValue = PlayerCollider.numLives;
        //Lives.text = "Lives: " + livesValue;
        if (GameManager.Level == 1)
        {
            Score2.text = "Score P2:" + p.GetScore2();
        }
        else
        {
            Score2.text = "Score P2:" + p.GetScore();
        }
    }
}
