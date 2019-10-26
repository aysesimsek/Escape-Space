using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    #region variables
    private Rigidbody2D rb;
	private Vector2 mousePos;
	private Vector2 offset;
	private bool clicked;
    public Text scoreText;
    public float score = 0;

    public GameObject planet_1;
    public GameObject planet_2;
    public GameObject planet_3;

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
    public GameObject enemy_16;
    public GameObject enemy_17;
    public GameObject enemy_18;
    public GameObject enemy_19;
    public GameObject enemy_20;
    public GameObject enemy_21;
    public GameObject enemy_22;
    public GameObject enemy_23;
    public GameObject enemy_24;
    public GameObject enemy_25;
    public GameObject enemy_26;
    public GameObject enemy_27;
    public GameObject enemy_28;
    public GameObject enemy_29;
    public GameObject enemy_30;
    public GameObject enemy_31;
    public GameObject enemy_32;
    public GameObject enemy_33;
    public GameObject enemy_34;
    public GameObject enemy_35;
    public GameObject enemy_36;
    public GameObject enemy_37;
    public GameObject enemy_38;
    public GameObject enemy_39;
    public GameObject enemy_40;
    public GameObject enemy_41;
    public GameObject enemy_42;
    public GameObject enemy_43;
    public GameObject enemy_44;
    public GameObject enemy_45;
    public GameObject enemy_46;
    public GameObject enemy_47;
    public GameObject enemy_48;
    public GameObject enemy_49;
    public GameObject enemy_50;
    GameObject[] enemyCollection;

    float next_time;
    #endregion

    private void Start () {
		rb = GetComponent<Rigidbody2D> ();
		offset = transform.position;
        InvokeRepeating("Scorer", 0, 1);
        next_time = Time.time + 0.5f;

     enemyCollection = new GameObject[] { enemy_1, enemy_2, enemy_3, enemy_4, enemy_5, enemy_6, enemy_7, enemy_8, enemy_9, enemy_10, enemy_11, enemy_12, enemy_13, enemy_14, enemy_15, enemy_16, enemy_17, enemy_18, enemy_19, enemy_20, enemy_21, enemy_22, enemy_23, enemy_24, enemy_25, enemy_26, enemy_27, enemy_28, enemy_29, enemy_30, enemy_31, enemy_32, enemy_33, enemy_34, enemy_35, enemy_36, enemy_37, enemy_38, enemy_39, enemy_40, enemy_41, enemy_42, enemy_43, enemy_44, enemy_45, enemy_46, enemy_47, enemy_48, enemy_49, enemy_50, planet_1, planet_2, planet_3 };
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
            CreateEnemy();
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

    private void CreateEnemy()
    {
        float random_x = Random.Range(-7.0F, 7.0F);
        float random_y = Random.Range(7.0F, 15.5F);

        int enemy_no = Random.Range(0,53);

        GameObject currentEnemy = enemyCollection[enemy_no];

        GameObject new_enemy = Instantiate(currentEnemy, new Vector3(transform.position.x + random_x, transform.position.y + random_y, transform.position.z), Quaternion.identity);

        Destroy(new_enemy, 53);
    }
}
