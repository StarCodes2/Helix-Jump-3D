using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform player;
    private Transform player2;
    private AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioManager = FindObjectOfType<AudioManager>();

        if (GameManager.dualGameMode)
        {
            player2 = GameObject.FindGameObjectWithTag("Player2").transform;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.dualGameMode)
        {
            player2 = GameObject.FindGameObjectWithTag("Player2").transform;
        }

        if (transform.position.y > player.position.y && !GameManager.dualGameMode)
        {
            audioManager.Play("whoosh");
            GameManager.numberOfPassedRings++;
            GameManager.score++;
            // Single ball mode
            Destroy(gameObject);

        } else if (GameManager.dualGameMode)
        {
            // If any of the balls passed the rings
            if (transform.position.y > player2.position.y && gameObject.CompareTag("PlaceHolder2"))
            {
                audioManager.Play("whoosh");
                GameManager.numberOfPassedRings++;
                GameManager.score++;
                Destroy(gameObject);
            }

            // Check if the two balls passed the ring
            if (transform.position.y > player.position.y && gameObject.CompareTag("PlaceHolder"))
            {
                audioManager.Play("whoosh");
                GameManager.numberOfPassedRings++;
                GameManager.score++;
                // We completed the dual mode level
                Destroy(gameObject);
            }
        }
    }
}
