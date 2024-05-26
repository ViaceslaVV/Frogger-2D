using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool moveRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.localPosition;

        if(moveRight )
        {
            pos.x += Vector2.right.x * moveSpeed * Time.deltaTime;

            if (pos.x >= 54.7f)
            {
                pos.x = -54.8f;
            }
        }
        else
        {
            pos.x += Vector2.left.x * moveSpeed * Time.deltaTime;

            if(pos.x <= -54.7f )
            {
                pos.x = 54.63f;
            }
        }
        transform.localPosition = pos;
    }
}
