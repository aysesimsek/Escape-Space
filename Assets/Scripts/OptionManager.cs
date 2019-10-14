using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    GameObject player;
    public void StartGame()
    {
        player = GameObject.Find("Player");
        Destroy(player);
        SceneManager.LoadScene("UnityGame");
    }
}
