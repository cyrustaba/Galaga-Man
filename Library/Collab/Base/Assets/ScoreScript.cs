using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue;
    Text Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<Text>();
        p = GameObject.FindObjectOfType<PelletEater>(); //referencing pellet eater from
    }
    PelletEater p;
    // Update is called once per frame
    void Update()
    {
        scoreValue = p.ScoreP1;
        Score.text = "Score: " + scoreValue;
    }
}
