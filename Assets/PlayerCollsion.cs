using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsion : MonoBehaviour
{

    void Start()
    {
        mazeMover = GetComponent<MazeMover>();
        p = GetComponent<PelletEater>();
        functionTimer = GetComponent<FunctionTimer>();
        //en = GameObject.FindObjectOfType<Enemy>();

    }
    public void Update()
    {
        GameManager.Invincibility = inv_flag;
        CountDown();
    }
    public void CountDown()
    {
        if (start)
        {
            if (!isDestroyed)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    //trigger action
                    StopInvincibility();
                    inv_flag = 0;
                    DestroySelf();
                }
            }
        }
    }
    private void DestroySelf()
    {
        isDestroyed = true;
    }
    MazeMover mazeMover;
    PelletEater p;
    Vector2 newDir;
    FunctionTimer functionTimer;
    bool start = false; 
    public int myScore;
    public int numLivesP1 = 3;
    public int numLivesP2 = 3;
    public int inv_flag = 0; //invulnerability flag
    public float timer;
    private bool isDestroyed;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //myScore = p.GetCurrentScore();
        if (inv_flag == 0)
        {
            Debug.Log("hit detected");
            transform.position = new Vector3(-2, 2, 0);
            //transform.Translate(-2, 2, 0);
            mazeMover.StopMoving(); //go into mazemover and make targetPos to itself
            numLivesP1--; 
            if(numLivesP1 == 0)
            {
                //end game -----------------------------------------------------------
            }
            //newDir.x = -1;
            //newDir.y = 0;
            //mazeMover.SetDesiredDirection(newDir.normalized, true);
            return;
        }
        //if we get here that means a power up was collected
        //InvTime();
    }
    public void SetInvFlag()
    {
        inv_flag = 1;
        //Invincibility SPRITE EXECUTION GOES HERE ------------------------------------------------
        timer = 5f;
        isDestroyed = false;
        start = true;
     }
    public void StopInvincibility()
    {
        inv_flag = 0;
    }
    public int getLives()
    {
        return numLivesP1;
    }
    IEnumerator InvTime()
    {
        yield return new WaitForSeconds(10f);
        inv_flag = 0;
    }
    public void SendToOblivion()
    {
        transform.position = new Vector3(-5000, 2, 0);
    }
}
