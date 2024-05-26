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

    Vector2 pos;
    // Update is called once per frame
    void UpdatePosition()
    {
        pos = transform.localPosition;

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.parent = null;

            GetComponent<SpriteRenderer>().sprite = playerUp;
            pos += Vector2.up * 3;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.parent = null;

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
            transform.parent = null;

            GetComponent<SpriteRenderer>().sprite = playerLeft;
            pos += Vector2.left;
            pos += Vector2.left;
            pos += Vector2.left;


        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.parent = null;

            GetComponent<SpriteRenderer>().sprite = playerRight;
            pos += Vector2.right;
            pos += Vector2.right;
            pos += Vector2.right;


        }


        transform.localPosition = pos;



    }
    private void CheckCollision()
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

                    
                    
                }
                else
                {
                    isSafe = false;
                    
                }
            }

        }
        if(!isSafe)
        {
            print("Hello");
            transform.localPosition = originalPosition;
            transform.GetComponent<SpriteRenderer>().sprite = playerUp;
        }
        
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        print("TRIGGER");
        if (collision.transform.CompareTag("Platform"))
        {
            pos = transform.localPosition;
            pos.x += collision.GetComponent<Log>().moveSpeed * Time.deltaTime;

            if (transform.position.x >= 53.4f)
            {
                pos.x = transform.position.x / 2 - 106.8f;
                transform.localPosition = pos;
            }
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        GameObject[] gameObject = GameObject.FindGameObjectsWithTag("collidableOBJ");
        CollidableOBJ collidableOBJ = GetComponent<CollidableOBJ>();
        if (collision.transform.CompareTag("Platform"))
        {
            transform.parent = collision.transform;
            transform.localPosition = Vector3.zero;
        }
        



    }
}
