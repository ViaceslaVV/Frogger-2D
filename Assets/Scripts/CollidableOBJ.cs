using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableOBJ : MonoBehaviour
{
    public bool isSafe;

    Rect playerRect;
    Vector2 playerSize;
    Vector2 PlayerPosition;

    Rect collidableOBJRect;
    Vector2 collidableObjectSize;
    Vector2 collidableObjectPosition;
    // Start is called before the first frame update
    

    public bool Colliding (GameObject playerGameOBJ)
    {
        playerSize = playerGameOBJ.transform.GetComponent<SpriteRenderer>().size;
        PlayerPosition = playerGameOBJ.transform.localPosition;

        collidableObjectSize = GetComponent<SpriteRenderer>().size;
        collidableObjectPosition = transform.localPosition;

        playerRect = new Rect(PlayerPosition.x - playerSize.x / 2, PlayerPosition.y - playerSize.y / 2, playerSize.x, playerSize.y);

        collidableOBJRect = new Rect(collidableObjectPosition.x - collidableObjectSize.x / 2, collidableObjectPosition.y - collidableObjectSize.y / 2, collidableObjectSize.x, collidableObjectSize.y);

        if (collidableOBJRect.Overlaps(playerRect, true))
        {
            return true;
        }
        return false;
    }
}
