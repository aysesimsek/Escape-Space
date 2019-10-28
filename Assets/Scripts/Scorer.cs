using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    public Text scoreText;
    public Text highestScoreText;

    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        PlayerControl playerControls = player.GetComponent<PlayerControl>();
        scoreText.text = playerControls.score.ToString();

        if (!PlayerPrefs.HasKey("highestScore") || PlayerPrefs.GetInt("highestScore") < Mathf.RoundToInt(playerControls.score))
        {
            PlayerPrefs.SetInt("highestScore", Mathf.RoundToInt(playerControls.score)); //new highest score

        }

        highestScoreText.text = PlayerPrefs.GetInt("highestScore").ToString();

    }

    void Update()
    {
        
    }
}
