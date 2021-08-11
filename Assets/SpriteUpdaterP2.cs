using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteUpdaterP2 : MonoBehaviour
{

    public Sprite LShip, UShip, RShip, DShip;

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey(KeyCode.A) ) 
        {
            GetComponent<SpriteRenderer>().sprite = LShip;
        }
        if( Input.GetKey(KeyCode.D) )
        {
            GetComponent<SpriteRenderer>().sprite = RShip;
        }
        if( Input.GetKey(KeyCode.W) )
        {
            GetComponent<SpriteRenderer>().sprite = UShip;
        }
        if( Input.GetKey(KeyCode.S) )
        {
            GetComponent<SpriteRenderer>().sprite = DShip;
        }
    }
}