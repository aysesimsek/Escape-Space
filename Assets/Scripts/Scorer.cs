using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    public Text scoreText;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        PlayerControl playerControls = player.GetComponent<PlayerControl>();
        scoreText.text = playerControls.score.ToString();
    }

    void Update()
    {
        
    }
}
