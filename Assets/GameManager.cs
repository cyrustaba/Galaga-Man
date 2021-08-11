using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // if (Level == 1)
        //{
            //For now -- this will change when we have multiple levels
        //    WallTileMap = GameObject.FindObjectOfType<WallTileMap>().GetComponent<Tilemap>();
       // }
       // else
       // {
            //WallTileMap = GameObject.FindObjectOfType<WallTileMap>().GetComponent<Tilemap>();
           // w1 = GameObject.FindObjectOfType<WallTileMap>().GetComponent<Tilemap>();
            //w2 = GameObject.FindObjectOfType<WallTileMap>().GetComponent<Tilemap>();
        //}
    }
   // static public Tilemap w1;
   // static public Tilemap w2;
   // static public Tilemap[] WallTileMap = { w1, w2 }; 
    static public int Level = 1;
    static public int Invincibility;
    static public int destroyself = 0;
    //public int ScoreP1 = 0;
    // Update is called once per frame
    void Update()
    {
        if(Level == 2 && destroyself == 0)
        {
            //SWITCH SCENES code goes down here-----------------------------------------------
			//WallTileMap = GameObject.FindObjectOfType<WallTileMap>().GetComponent<Tilemap>()
            SceneManager.LoadScene(2);
            destroyself = 1;
        }
    }

    //Todo: make the setting of this private/protected/something
    //public static Tilemap WallTileMap;
}
