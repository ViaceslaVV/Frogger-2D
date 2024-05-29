using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Sprite playerUp, playerDown, playerLeft, playerRight;
    public int health = 4;
    private Vector3 originalPosition;
    private HashSet<Transform> visitedHomes = new HashSet<Transform>();
    private const int TotalHomes = 5;
    public AudioClip hopSound;

    public TextMeshProUGUI livesText;

    public GameObject losePanel;


    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
        UpdateLivesText();
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
            PlayHopSound();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.parent = null;
            GetComponent<SpriteRenderer>().sprite = playerDown;
            pos += Vector2.down * 4;
            PlayHopSound();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.parent = null;
            GetComponent<SpriteRenderer>().sprite = playerLeft;
            pos += Vector2.left * 3;
            PlayHopSound();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.parent = null;
            GetComponent<SpriteRenderer>().sprite = playerRight;
            pos += Vector2.right * 3;
            PlayHopSound();
        }

        transform.localPosition = pos;
    }
    private void PlayHopSound()
    {
        AudioSource.PlayClipAtPoint(hopSound, Vector3.zero);
    }

    private void CheckCollision()
    {
        bool isSafe = true;
        GameObject[] gameObject = GameObject.FindGameObjectsWithTag("collidableOBJ");

        foreach (GameObject go in gameObject)
        {
            CollidableOBJ collidableOBJ = go.GetComponent<CollidableOBJ>();

            if (collidableOBJ.Colliding(this.gameObject))
            {
                if (collidableOBJ.isSafe)
                {
                    isSafe = true;
                }
                else
                {
                    isSafe = false;
                }
            }
        }

        if (!isSafe)
        {
            print("Hello");
            LoseLife();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            transform.parent = collision.transform;
            transform.localPosition = Vector3.zero;
            transform.parent = null;
        }
        else if (collision.transform.CompareTag("Home"))
        {
            if (visitedHomes.Add(collision.transform)) // Only add if not already visited
            {
                if (visitedHomes.Count >= TotalHomes)
                {
                    WinGame();
                }
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            transform.parent = collision.transform;
            transform.localPosition = Vector3.zero;
            transform.parent = null;
        }
        if (collision.transform.CompareTag("Danger"))
        {
            // Ensure that we are continuously resetting the player on water
            transform.localPosition = originalPosition;
            transform.GetComponent<SpriteRenderer>().sprite = playerUp;
            transform.parent = null;
        }
        if (collision.transform.CompareTag("Home"))
        {
            // Ensure that we are continuously resetting the player on water
            transform.localPosition = originalPosition;
            transform.GetComponent<SpriteRenderer>().sprite = playerUp;
            transform.parent = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {

            transform.parent = null;
        }
    }

    private void LoseLife()
    {
        health--;
        UpdateLivesText();

        if (health > 0)
        {
            transform.localPosition = originalPosition;
            transform.GetComponent<SpriteRenderer>().sprite = playerUp;
        }
        else
        {
            // Handle game over logic
            Debug.Log("Game Over");
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + health;
    }
    private void WinGame()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
