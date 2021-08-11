using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FunctionTimer : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame

    
	
	
	
	private Action action;
    private float timer;
    private bool isDestroyed;
    public void Timer(Action action, float timer)
    {
        this.action = action;
        this.timer = timer;
        isDestroyed = false;
        CountDown();
    }
    public void CountDown()
    {
        if (!isDestroyed) { 
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                //trigger action
                action();
               DestroySelf();
            }
        }
    }
    public void DestroySelf()
    {
        isDestroyed = true;
    }
	
	
	
	
}
