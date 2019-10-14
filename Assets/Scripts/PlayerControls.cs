using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    GameObject player;
    public float score = 0;
    public Text scoreText;

    float distance = 10;

    void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("Scorer", 0, 1);

    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            onMouseDrag();
        }
    }

    void onMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 playerPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        player.transform.position = playerPosition;
    }

    void Scorer()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            score++;
            scoreText.text = (score).ToString();
        }
    }

}
