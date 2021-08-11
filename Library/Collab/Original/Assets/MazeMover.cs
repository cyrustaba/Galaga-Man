using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeMover : MonoBehaviour
{
    // Start is called before the first frame update 
    void Start()
    {
        //Test:
        desiredDirection = new Vector2(-1, 0);

        // Set our initial target position to be our starting position
        // so that the update will, well, update the target
        targetpos = transform.position;

        //This works as long as there is only ONE Tilemap in the scene
        /*This will look through the entire scene and find first object with
        a Tilemap component */ 
        wallTileMap = GameObject.FindObjectOfType<Tilemap>();
    }

    float Speed = 3; // How many world-space "tiles" this unit moves in one second

    Vector2 desiredDirection; // The current direction we want to move in

    Vector2 targetpos; //Always a legal, empty tile

    Tilemap wallTileMap;

    // Update is called once per GRAPHIC frame
    // This is the best place to read inputs and do things like updating animations
    void Update()
    {
        // First, make sure we can legally move in the direction that we want
        UpdateTargetPosition();

        //Do the move!
        MoveToTargetPosition();

    }

    void UpdateTargetPosition()
    {

        //Have we reached our target?
        float distanceToTarget = Vector3.Distance(transform.position, targetpos);
        if(distanceToTarget > 0)
        {
            //Not there yet, no need to update anything.
            return;
        }

        //If we get here, it means we need a new target position;
        targetpos = targetpos + desiredDirection; //targetpos += direction;

        // "Normalize" the target position to a tile's position 

        if (IsTileEmpty(targetpos))
        {
            //Good to go!
            return;
        }

        //If we get here, it means that our target positon is OCCUPIED!
        //So we aren't allowed to move, Stand still!
        targetpos = transform.position;
    }


    bool IsTileEmpty(Vector2 pos)
    {
        //Is there a tile at pos?
        return GetTileAt(pos) == null;
        // either it will return tile in the coordinates it is asking for
        // or it will just return null and there is nothing there
        // != null -> theres a tile there..... == null -> there is no tile there
    }

    //helper function
    TileBase GetTileAt(Vector2 pos)
    {
        //Get the tile from the tilemap at position pos
        //First we need to change the World Position, to a tile cell index
        Vector3Int cellPos = wallTileMap.WorldToCell(pos);
        //Now return the actual tile!
        return wallTileMap.GetTile(cellPos);

    }


    // FixedUpdate is called once her PHYSICS ENGINE frame
    // This is the best place to update the physic's system
    // velocity if you are using it to move your object
    //
    //void FixedUpdate()
    //{
    // Our objects are not physics-enabled rigibodies, so 
    // the hysics system isn't moving us, nor are we doing
    // "real" collisions, so we don't need to stress about
    // FixedUpdate
    //}

    void MoveToTargetPosition()
    {
        // How far can we move this frame?
        float distanceThisUpdate = Speed * Time.deltaTime;

        //And in what direction is this movement?
        //Towards our target position!
        Vector2 distToTarget = targetpos - (Vector2)transform.position;

        // And in what direction is this movement?
        Vector2 movementThisUpdate = distToTarget.normalized * distanceThisUpdate;

        //What if we would be moving PAST the target?
        // We could change movementThisUpdate to have the same magnitude as distance to target
        if(distToTarget.SqrMagnitude() < movementThisUpdate.SqrMagnitude())
        {
            // Just set our position to the target, not a "move"
            transform.position = targetpos;
            return;
        }

        //Do the move!
        transform.Translate(movementThisUpdate);

    }



}
