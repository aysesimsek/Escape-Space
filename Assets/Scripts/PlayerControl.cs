using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector2 mousePos;
	private Vector2 offset;
	private bool clicked;

    public Text scoreText;
    public float score = 0;

    public GameObject ballon;

    public GameObject enemy_1;
    public GameObject enemy_2;
    public GameObject enemy_3;
    public GameObject enemy_4;
    public GameObject enemy_5;
    public GameObject enemy_6;
    public GameObject enemy_7;
    public GameObject enemy_8;
    public GameObject enemy_9;
    public GameObject enemy_10;
    public GameObject enemy_11;
    public GameObject enemy_12;
    public GameObject enemy_13;
    public GameObject enemy_14;
    public GameObject enemy_15;

    GameObject[] enemyCollection;



    float next_time;

	private void Start () {
		rb = GetComponent<Rigidbody2D> ();
		offset = transform.position;
        InvokeRepeating("Scorer", 0, 1);
        next_time = Time.time + 0.5f;

     enemyCollection = new GameObject[] { enemy_1, enemy_2, enemy_3, enemy_4, enemy_5, enemy_6, enemy_7, enemy_8, enemy_9, enemy_10, enemy_11, enemy_12, enemy_13, enemy_14, enemy_15 };

    //enemyCollection[0]=enemy_1;

    }

    private void FixedUpdate () {
        //Týklaniginda
		if (Input.GetMouseButton (0)) {
			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			if (!clicked) {
				offset = (Vector2) transform.position - mousePos + new Vector2 (0, Camera.main.GetComponent<CameraMovement> ().cameraSpeed);
				clicked = true;
			}

			Vector2 newPos = new Vector2 (
				Mathf.Clamp (mousePos.x + offset.x, GameManager.gm.cameraEdges.w + 0.32f, GameManager.gm.cameraEdges.y - 0.32f),
				mousePos.y + offset.y
			);

			rb.MovePosition (newPos);
		}
        //Yukselirken
		else {
			rb.MovePosition (transform.position + new Vector3 (0, Camera.main.GetComponent<CameraMovement> ().cameraSpeed, 0));
			clicked = false;
		}
        //Debug.Log(Time.deltaTime % 10);
        if(Time.time > next_time)
        {
            createEnemy();
            next_time = next_time + 0.5f;

        }

        this.gameObject.transform.localScale = transform.localScale - new Vector3(Time.deltaTime/100000, Time.deltaTime / 100000, Time.deltaTime / 100000);
        ballon.transform.localScale = ballon.transform.localScale + new Vector3(Time.deltaTime / 100, Time.deltaTime / 100, Time.deltaTime / 100);




    }

    void Scorer()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            score++;
            scoreText.text = (score).ToString();
        }
    }

    private void createEnemy()
    {

        float random_x = Random.Range(-7.0F, 7.0F);
        float random_y = Random.Range(3.0F, 7.5F);

        int enemy_no = Random.Range(0,15);

        GameObject currentEnemy = enemyCollection[enemy_no];

        GameObject new_enemy = Instantiate(currentEnemy, new Vector3(transform.position.x + random_x, transform.position.y + random_y, transform.position.z), Quaternion.identity);

        Destroy(new_enemy, 15);
    }

}
