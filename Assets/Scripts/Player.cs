using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite playerUp, playerDown, playerLeft, playerRight;

    private Vector2 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
    }
    void Update()
    {
        UpdatePosition();

        CheckCollision();
    }

    // Update is called once per frame
    void UpdatePosition()
    {
        Vector2 pos = transform.localPosition;

        if (Input.GetKeyDown(KeyCode.W)) 
        {
            GetComponent<SpriteRenderer>().sprite = playerUp;
            pos += Vector2.up;
            pos += Vector2.up;
            pos += Vector2.up;

            
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<SpriteRenderer>().sprite = playerDown;
            pos += Vector2.down;
            pos += Vector2.down;
            pos += Vector2.down;
            pos += Vector2.down;

            if (pos.x < 0)
            {
                pos += Vector2.up;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().sprite = playerLeft;
            pos += Vector2.left;
            pos += Vector2.left;
            pos += Vector2.left;

            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().sprite = playerRight;
            pos += Vector2.right;
            pos += Vector2.right;
            pos += Vector2.right;


        }
        

        transform.localPosition = pos;

        

    }
    private void CheckCollision ()
    {
        bool isSafe = true;
        GameObject[] gameObject = GameObject.FindGameObjectsWithTag("collidableOBJ");

        foreach (GameObject go in gameObject)
        {
            CollidableOBJ collidableOBJ = go.GetComponent<CollidableOBJ>();

            if(collidableOBJ.Colliding(this.gameObject))
            {
                if(collidableOBJ.isSafe)
                {
                    isSafe = true;

                    if(collidableOBJ.isLog)
                    {
                        Vector2 pos = transform.localPosition;

                        if(collidableOBJ.GetComponent<Log>().moveRight)
                        {
                            pos.x += collidableOBJ.GetComponent<Log>().moveSpeed * Time.deltaTime;

                            if(transform.position.x - GetComponent<SpriteRenderer>().size.x /2 >= 53.4f)
                            {
                                pos.x = transform.position.x /2 -106.8f;
                            }
                        }
                        else
                        {
                            pos.x -= collidableOBJ.GetComponent<Log>().moveSpeed * Time.deltaTime;
                        }
                        transform.localPosition = pos;
                    }
                    break;
                    
                }
                else
                {
                    isSafe = false;
                    
                }
            }

        }
        if(!isSafe)
        {
            transform.localPosition = originalPosition;
            transform.GetComponent<SpriteRenderer>().sprite = playerUp;
        }
    }

}
