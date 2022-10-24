using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRB;
    public float bounceForce = 6;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;
        
        if (materialName == "Safe (Instance)")
        {
            // The ball hit the safe area

        } else if(materialName == "Unsafe (Instance)")
        {
            // The ball hit the unsafe area
            GameManager.gameOver = true;
            audioManager.Play("game over");
        }
        else if(materialName == "LastRing (Instance)" && !GameManager.levelCompleted)
        {
            // Check game mode
            if (!GameManager.dualGameMode)
            {
                // We completed the level
                GameManager.levelCompleted = true;
                audioManager.Play("win level");
            } else
            {

                if (gameObject.CompareTag("Player"))
                {
                    GameManager.playerReachLastRing = true;
                }
                else if (gameObject.CompareTag("Player2"))
                {
                    GameManager.player2ReachLastRing = true;
                }

                // Check if the two ball reach the base
                if (GameManager.playerReachLastRing && GameManager.player2ReachLastRing)
                {
                    // We completed the dual mode level
                    GameManager.levelCompleted = true;
                    audioManager.Play("win level");
                    GameManager.player2ReachLastRing = GameManager.playerReachLastRing = false;
                }
            }
            
        }
    }
}
