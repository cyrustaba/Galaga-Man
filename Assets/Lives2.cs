using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives2 : MonoBehaviour
{
    // public static int scoreValue;
    public static int livesValue;
    //Text Score;
    Text Live2;
	Text GameOver;
	FunctionTimer ft;
    // Start is called before the first frame update
    void Start()
    {
        //  Score = GetComponent<Text>();
        Live2 = GetComponent<Text>();
		GameOver = GetComponent<Text>();
		p = GameObject.FindObjectOfType<PelletEater>(); //referencing pellet eater from
        
		PlayerCollider = GameObject.FindObjectsOfType<PlayerCollsion>();
        
		p1 = GameObject.FindObjectOfType<PlayerCollsion>();
        p2 = GameObject.FindObjectOfType<PlayerCollsion>();
        p3 = GameObject.FindObjectOfType<PlayerMover>();
    }
    // PelletEater p;
    static PlayerCollsion p1;
    static PlayerCollsion p2;
    PlayerCollsion[] PlayerCollider = { p1, p2 };
    PelletEater p;
    PlayerMover p3;
    // Update is called once per frame
    void Update()
    {
        // scoreValue = p.ScoreP1;
        livesValue = p2.numLivesP1;
        if (p.lives < 1)
        {
            p3.SendToOblivion();
        }
        if (livesValue < 1)
        {
            p2.SendToOblivion();
        }
        if (livesValue >0  || p.lives >0) 
			Live2.text = "Lives P2: " + livesValue + "    P1: " + p.lives;
		else  {
			waiter();
            //StartCoroutine(waiter());

        }
        //SceneManager.LoadScene("Menu");
        //SceneManager.LoadScene(1);
        // Score.text = "Score: " + scoreValue;
    }
	


    

//stop scene, fix lives, KIND OF fix scene 2
public void waiter()
{
    // doing something
	GameOver.text = "Game Over. Press M for Menu.";
    // waits 5 seconds
	Time.timeScale = 0;
	//p2.setActive(false);
    //yield return new WaitForSeconds(5);
	// do something else
	if (Input.GetKeyDown(KeyCode.M))
	{
		Time.timeScale = 1;
        p.Reset();
		SceneManager.LoadScene("Menu");
	}
}

private IEnumerator stop()
{
	yield return new WaitForSeconds(5);
	Time.timeScale = 1;
}	
}
