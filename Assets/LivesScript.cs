using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesScript : MonoBehaviour
{
   // public static int scoreValue;
    public static int livesValue;
    //Text Score;
    Text Lives;
    // Start is called before the first frame update
    void Start()
    {
      //  Score = GetComponent<Text>();
        Lives = GetComponent<Text>();
      //  p = GameObject.FindObjectOfType<PelletEater>(); //referencing pellet eater from
        PlayerCollider = GameObject.FindObjectsOfType<PlayerCollsion>();
        p1 = GameObject.FindObjectOfType<PlayerCollsion>();
        p2 = GameObject.FindObjectOfType<PlayerCollsion>();
    }
    // PelletEater p;
    static PlayerCollsion p1;
    static PlayerCollsion p2;
    PlayerCollsion[] PlayerCollider = { p1, p2 };
    //PlayerCollsion PlayerCollider;
    // Update is called once per frame
    void Update()
    {
       // scoreValue = p.ScoreP1;
        livesValue = p1.numLivesP1;
        //Lives.text = "Lives P1: " + livesValue;
       // Score.text = "Score: " + scoreValue;
    }
}
