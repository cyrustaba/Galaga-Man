using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PelletEater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerCollider = GameObject.FindObjectsOfType<PlayerCollsion>();
    }
    public static int ScoreP1= 0;
    public static int ScoreP2 = 0;
    public int currentScore = 0;
    public int lives;
    public static int destroyself;
    PlayerCollsion[] PlayerCollider;
    // Update is called once per frame
    void Update()
    {
        foreach (PlayerCollsion p in PlayerCollider)
        {
            lives = p.getLives();
        }
        ChangeLevel();
    }
    public void SetScore(int points)
    {
        ScoreP1 += points;
        currentScore = points;
        if(points == 250)
        {
            foreach (PlayerCollsion p in PlayerCollider)
            {
                p.SetInvFlag();
            }
            //PlayerCollider.SetInvFlag();
        }
    }
    public void SetScore2(int points)
    {
        ScoreP2 += points;

    }
    public int GetScore()
    {
        return ScoreP1;
    }
    public int GetScore2()
    {
        return ScoreP2;
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }
    public void ChangeLevel()
    {
        if((ScoreP1+ScoreP2) == 14300 && destroyself == 0) //14300
        {
            GameManager.Level = 2;
            int tmp1 = ScoreP1;
            int tmp2 = ScoreP2;
            ScoreP1 = ScoreP2;
            ScoreP2 = tmp1;
            destroyself = 1;
        }
        
    }
    public void Reset()
    {
        ScoreP1 = 0;
        ScoreP2 = 0;
    }
    public void SendToOblivion()
    {
        transform.position = new Vector3(-5000, 2, 0);
    }

}
