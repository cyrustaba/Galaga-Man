using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowersScript : MonoBehaviour
{
    public static int active;
    Text Powers;
    // Start is called before the first frame update
    void Start()
    {
        Powers = GetComponent<Text>();
        PlayerCollider = GameObject.FindObjectOfType<PlayerCollsion>();
    }
    PlayerCollsion PlayerCollider;
    // Update is called once per frame
    void Update()
    {
        active = PlayerCollider.inv_flag; //--------------------------fix text not going away
        if(active == 1)
        {
            Powers.text = "Invincible! " + PlayerCollider.timer;
        }
        else
        {
            Powers.text = "";
        }
       
    }
}
