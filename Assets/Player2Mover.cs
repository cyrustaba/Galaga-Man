using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MazeMover))]
public class Player2Mover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        mazeMover = GetComponent<MazeMover>();
    }
    MazeMover mazeMover;
    Vector2 newDir;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            newDir.x = -1;
            newDir.y = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newDir.x = 1;
            newDir.y = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            newDir.x = 0;
            newDir.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newDir.x = 0;
            newDir.y = -1;
        }
        if (newDir.SqrMagnitude() < 0.05f)
        {
            // The input is REALLY small (probably zero),
            // so don't change the desired direction
            return;
        }

        // newDir could be REALLY wonky at this point. Could be diagonal,
        // could have a fractional number like (0.67, -0.24)

        // In case we have both an X and a Y
        if (Mathf.Abs(newDir.x) >= Mathf.Abs(newDir.y))
        {
            // X is bigger, so zero the Y
            newDir.y = 0;
        }
        else
        {
            newDir.x = 0;
        }

        mazeMover.SetDesiredDirection(newDir.normalized, true);
    }
    
    //Vector2 newDir = new Vector2(
    //Input.GetAxisRaw("Horizontal"),
    //Input.GetAxisRaw("Vertical")
}
