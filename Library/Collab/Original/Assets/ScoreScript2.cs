using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript2 : MonoBehaviour
{
    public static int scoreValue2;
    Text Score2;
    // Start is called before the first frame update
    void Start()
    {
        Score2 = GetComponent<Text>();
        p = GameObject.FindObjectOfType<PelletEater>(); //referencing pellet eater from
    }
    PelletEater p;
    // Update is called once per frame
    void Update()
    {
        scoreValue2 = p.ScoreP2;
        Score2.text = "Player 2: " + p.GetScore2();

    }
}
