using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletEater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public int ScoreP1 = 0;
	public int ScoreP2 = 0;
    // Update is called once per frame
    void Update()
    {
 
    }
    public void SetScore(int points)
    {
        ScoreP1 += points;
		
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
  
}
