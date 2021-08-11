using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteUpdaterP1 : MonoBehaviour
{

    public Sprite LShip, UShip, RShip, DShip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().sprite = LShip;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().sprite = RShip;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<SpriteRenderer>().sprite = UShip;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<SpriteRenderer>().sprite = DShip;
        }
        if(GameManager.Invincibility == 1)
        {
            //GetComponent<SpriteRenderer>().sprite =
        }
    }
}
