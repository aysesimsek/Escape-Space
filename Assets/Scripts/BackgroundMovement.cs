using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    [SerializeField]
    private Transform BackgroundCenter;


    void Start()
    {
        SoundManager.PlaySound("background");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y >= BackgroundCenter.position.y + 10f)
        {
            BackgroundCenter.position = new Vector2(BackgroundCenter.position.x, transform.position.y + 10f);
        }
        else if (transform.position.y <= BackgroundCenter.position.y - 10f)
        {
            BackgroundCenter.position = new Vector2(BackgroundCenter.position.x, transform.position.y - 10F);
        }
    }
}
