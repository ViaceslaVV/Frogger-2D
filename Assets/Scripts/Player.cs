using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite playerUp, playerDown, playerLeft, playerRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.localPosition;

        if (Input.GetKeyDown(KeyCode.W)) 
        {
            GetComponent<SpriteRenderer>().sprite = playerUp;
            pos += Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<SpriteRenderer>().sprite = playerDown;
            pos += Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().sprite = playerLeft;
            pos += Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().sprite = playerRight;
            pos += Vector2.right;

            
        }
        transform.localPosition = pos;

    }
}
