using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public Sprite home;

    // Update is called once per frame
    void Update()
    {
        HomeEnd();  
    }

    private void HomeEnd()
    {
        if (transform.CompareTag("Player"))
        {
            transform.GetComponent<SpriteRenderer>().sprite = home;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            transform.GetComponent<SpriteRenderer>().sprite = home;
        }
        

    }
}
