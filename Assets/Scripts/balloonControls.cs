using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class balloonControls : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            DontDestroyOnLoad(player);
            player.GetComponent<PlayerControl>().enabled = false;
            SceneManager.LoadScene("GameOverMenu");
            Debug.Log("Game Over!");
        }
        else if (collision.tag == "LevelEnd")
        {
            collision.tag = "Untagged";
        }
    }
    
}
