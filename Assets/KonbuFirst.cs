using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class KonbuFirst : MonoBehaviour {
    GameObject konbu;
    public GameObject player;

    int[] konbuRandom = new int[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    int konbuId = 0;

    float xSpeed = 0;

    bool alive = true;
    bool hitFloor = false;
    bool hitPlayer = false;

    private Rigidbody2D rb2d;
    private float jumpPower = 0;

    // Start is called before the first frame update
    void Start () {

        this.rb2d = GetComponent<Rigidbody2D> ();

        this.konbu = GameObject.Find ("konbuPrefab");
        this.player = GameObject.Find ("player");

        this.GetComponent<SpriteRenderer> ().sortingLayerName = "wakameOku";
        this.GetComponent<SpriteRenderer> ().sortingOrder = 1;

        xSpeed = Random.Range (-0.25f, -0.1f);

        konbuId = konbuRandom[Random.Range (0, konbuRandom.Length)];

        if (konbuId == 2) {
            rb2d.gravityScale = 3;
            jumpPower = Random.Range (800.0f, 1800.0f);
        }

        if (konbuId == 3) {
            float flyKonbuPositionY = Random.Range (-6.0f, 80.0f);
            transform.position = new Vector2 (81.5f, flyKonbuPositionY);
        }

    }

    // Update is called once per frame
    void Update () {

        //画面外出たらDestroy
        if (transform.position.x < -24 || transform.position.y < -24) {
            Destroy (gameObject);
        }

        if (alive == true) {
            if (hitPlayer == true) {
                rb2d.gravityScale = 0;
                rb2d.velocity = new Vector2 (0, 0);
                alive = false;
                return;
            }

            if (konbuId == 1 || konbuId == 2) {
                transform.Translate (xSpeed, 0, 0); //左へ
            }

            if (konbuId == 2 && hitFloor == true) {
                hitFloor = false;
                rb2d.velocity = new Vector2 (0, 0);
                rb2d.AddForce (transform.up * jumpPower);
            }

            if (konbuId == 3) {
                Vector2 konbuPotisiob = transform.position;
                Vector2 playerPosition = this.player.transform.position; //Player座標
                Vector2 vec = playerPosition - konbuPotisiob;
                transform.Translate (vec.normalized * -xSpeed * 2 / 3);
            }

        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            hitPlayer = true;
            // print ("hitPlayer = " + hitPlayer);
        } else if (other.gameObject.tag == "Floor") {
            hitFloor = true;
            // print ("hitFloor = " + hitFloor);
        }
    }

}