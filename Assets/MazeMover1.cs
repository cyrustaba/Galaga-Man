using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeMover1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TEst
        //set target position to starting position
        targetPos = transform.position;
        wallTileMap = GameObject.FindObjectOfType<WallTileMap>().GetComponent<Tilemap>();
    }

    public delegate void OnEnterNewTileDelegate();
    public event OnEnterNewTileDelegate OnEnterNewTile;
    float tileDistanceTolerance = 0.01f; // How close to the target position counts as "arriving"
    float Speed = 3; //how many world-space "tiles" this unit moves in one second
    Vector2 desiredDirection; //the current direction wwe want to move in
    Vector2 targetPos;   //always a legal, empty tile
    Tilemap wallTileMap;
    // Update is called once per frame
    //best place for inputs
    void Update()
    {

        //First, make sure we can move legaly the direction we want

        //UpdateDirection(); //change direction to zero vectior if we cant legally move that way

        //direction = GetUpdatedDirection();
       UpdateTargetPostion();

        //Move
        MoveToTargetPosition();
    }
    void UpdateTargetPostion(bool force = false)
    {
        if (force == false)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetPos);
            if (distanceToTarget > 0)
            {
                //not there yet no need to update
                return;
            }
        }
        //If we get here we entered a new tile
        //Giving other scripts a chance to respond to this event
        //and possibly update desired direction
        if (OnEnterNewTile != null)
        {
            OnEnterNewTile();
        }
        //if we get there, it means we need a new target position
        targetPos = targetPos + desiredDirection;

        //Normalize the target position to a tile's position
        //More robust soultion to lookup the tile at the new targetpos
        //then read back that Tile's world coordinate
        //makes it so u dont go through the tile (move assist)
        targetPos = FloorPosition(targetPos);

        if (IsTileEmpty(targetPos))
        {
            //good to go
            return;
        }
        //if we get here that means the target pos occupied not allowed to move
        //hitting a wall stop moving by setting the target to where u are
        targetPos = transform.position;
    }
    Vector2 FloorPosition(Vector2 pos)
    {
        return new Vector2(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y));
    }
    public bool WouldHitWall()
    {
        //returns true if our targetPos is a wall
        return IsTileEmpty(targetPos + desiredDirection) == false;
    }

    bool IsTileEmpty(Vector2 pos)
    {
        //Get the tile from tilemap at position pos
        return GetTileAt(pos) == null;
    }
    TileBase GetTileAt(Vector2 pos)
    {
        //Frist we need to change the world postiont to a tile cell index
        //   Vector3Int cellPos = GameManager.WallTileMap.WorldToCell(pos);
            Vector3Int cellPos = wallTileMap.WorldToCell(pos);
        //    return GameManager.WallTileMap.GetTile(cellPos);
             return wallTileMap.GetTile(cellPos);
    }
    void MoveToTargetPosition()
    {
        //We have some kind of direction/velocity that we are moving in
        //So move in that direction if we can
        //what if there is a wall, then we stop

        //How far can we move this frame?
        //x = (x / t) * t;
        float distanceThisUpdate = Speed * Time.deltaTime;

        //What direction is the movement?
        //towards our target position
        Vector2 distToTarget = targetPos - (Vector2)transform.position;
        //movement = direction*distance
        Vector2 movementThisUpdate = distToTarget.normalized * distanceThisUpdate;

        //what if we would be moving past the target?


        //Moving player to Target position
        //transform.position = transform.position + 1;
        //transform.Translate(direction * Speed * Time.deltaTime);
        if (distToTarget.SqrMagnitude() < movementThisUpdate.SqrMagnitude()) //if u havent hit a wall
        {
            transform.position = targetPos; //keep moving
            return;
        }
        // Do the move!
        transform.Translate(movementThisUpdate);

        if (Vector2.Distance(targetPos, (Vector2)transform.position) < tileDistanceTolerance)
        {
            // Close enough to count as arriving
            transform.position = targetPos;
        }
    }
    public void SetDesiredDirection(Vector2 newDir, bool canInstantUpdate = false)
    {
        //is this a valid movement (is there a wall in the way?)
        Vector2 testPos = targetPos + newDir;
        if (IsTileEmpty(testPos) == false)
        {
            return;
        }
        //save old direction
        Vector2 oldDir = desiredDirection;
        //desiredDirection = user input
        desiredDirection = newDir;

        //if the input is to reverse our direction, do it instantly 
        if (canInstantUpdate && ((oldDir.x * newDir.x) < 0 || (oldDir.y * newDir.y) < 0))
        {
            UpdateTargetPostion(true);
        }
    }
    public Vector2 GetDesiredDirection()
    {
        return desiredDirection;
    }
    Vector2 plsStop;
    public void StopMoving()
    {

        desiredDirection.x = -1;
        desiredDirection.y = 0;
        targetPos = transform.position;
        UpdateTargetPostion(true);
        Debug.Log("works?");
        //transform.Translate(0, 0, 0);
        

        //SetDesiredDirection(plsStop, true);
    }
    //called once per physics engine frame
    //best place for movement if you care about any part of
    // the physics system regardless of visual fps
    //void FixedUpdate()
    //{
    //our objects are not physics-enabled rigidbodies
    //}
    // bool IsDirectionLegal()
    // {
    //All direction legal unless slamming into wall

    //How do we check if we are hitting a wall
    //     Vector2 checkTilePos = transform.position + (Vector3)direction;

    //     return IsTilePresent(checkTilePos) == false;
    // }
}
//1:18:38