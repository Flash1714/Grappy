using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject deadEffect;
    public GameObject deadSound;
    public GameObject LavaSound;
    public int health = 2;
    public int score = 0;
    public int speed;
    private SpringJoint2D joint;
    public GameObject overScreen;
    public GameObject bgMusic;
    public GameObject lossMusic;
    public Text healthDisplay;
    public Text scoreDisplay;
    public Text deathDisplay;



    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "Lives Left: " + health.ToString();
        scoreDisplay.text = score.ToString();
        deathDisplay.text = "You Ded :(\n" + "\n" + "Your Score: " + score.ToString() + "\n" + "\n" + "Highscore: " + PlayerPrefs.GetInt("HighScore").ToString();
        


        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        if (health <= 0)
        {
            health = 0;
            overScreen.SetActive(true);
            bgMusic.SetActive(false);
            lossMusic.SetActive(true);
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            
            Destroy(gameObject);

        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lava"))
        {
            Instantiate(LavaSound, transform.position, Quaternion.identity);
        }
    }


}
