using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PelletTileMap : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        pelletEaters = GameObject.FindObjectsOfType<PelletEater>();
        p = GameObject.FindObjectOfType<PelletEater>(); //referencing pellet eater from
        p2 = GameObject.FindObjectOfType<PelletEater>(); //referencing pellet eater from
        myTileMap = GetComponent<Tilemap>();
    }

    // TODO: Add code for pellet eaters to signal updating this
    // whenever they die/respawn, if that's something that happens.
    static PelletEater p;
    static PelletEater p2;
    PelletEater[] pelletEaters = { p, p2 };
    Tilemap myTileMap;

    // What happens when we eat a pellet on this map?

    public int PelletPoints = 100;
    public bool RequiredForLevelCompletion = false;
    public float PowerSeconds = 0;

    // Update is called once per frame
    void Update()
    {
        // Is a pellet eater on a tile with a pellet?
        foreach (PelletEater pe in pelletEaters)
        {
            CheckPellet(pe);
        }

    }


    void CheckPellet(PelletEater pelletEater)
    {
        Vector2 offsetPosition = (Vector2)pelletEater.transform.position + new Vector2(0.5f, 0.5f);

        // What tile is the pellet eater "in"? 
        TileBase tile = GetTileAt(offsetPosition);

        if (tile == null)
        {
            // Empty tile with no pellets
            return;
        }

        Debug.Log("NOM");
        audioSource.Play();

        EatPelletAt(offsetPosition);
    }

    void EatPelletAt(Vector2 pos)
    {
        SetTileAt(pos, null);

        // TODO: Do the thing...points and whatnot. ---> GameManager
        //foreach (PelletEater pe in pelletEaters)
        // {
        //     pe.SetScore(PelletPoints);
        // }
        // Check which pelletEater ate a pellet based on their vector position on the Tilemap
        if (pos == (Vector2)p2.transform.position + new Vector2(0.5f, 0.5f))
        {
            p.SetScore2(PelletPoints);
            return;
        }
        else
        {
            p.SetScore(PelletPoints);
            return;
        }
    }

    void SetTileAt(Vector2 pos, TileBase tile)
    {
        // Get the tile from the tilemap at position pos

        // First, we need to change the World Position, to a tile cell index
        Vector3Int cellPos = myTileMap.WorldToCell(pos);

        // Now return the actual tile!
        myTileMap.SetTile(cellPos, tile);
    }


    TileBase GetTileAt(Vector2 pos)
    {
        // Get the tile from the tilemap at position pos

        // First, we need to change the World Position, to a tile cell index
        Vector3Int cellPos = myTileMap.WorldToCell(pos);

        // Now return the actual tile!
        return myTileMap.GetTile(cellPos);
    }


}