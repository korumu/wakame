using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Wakame3Controller : MonoBehaviour {

    float shootingWakameDist = -6.0f + KonbuGenerator.elapsedTime * 0.5f;

    //wakame3が手元に戻るときにtrueするよ
    bool returnWakame = false;

    //wakame1を手元に戻すよ fillAmountを1→0にして…な。
    public static bool wakame1Return = false;

    // 生成位置を変えたときに問題になる危険なコード :warning:
    //ここからしかのびね～～～～よ！
    // いや！
    // wakame3.transform.position = new Vector2 (-11.75f, -5.75f);
    // この記述との一貫性持たせるのが厳しいってんの
    //"まぁそう"黒木玄斎
    public static float wakame3Pos = -11.75f;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start () {
        this.rb2d = GetComponent<Rigidbody2D> ();

        this.GetComponent<SpriteRenderer> ().sortingLayerName = "wakameOku";
        this.GetComponent<SpriteRenderer> ().sortingOrder = 2;
    }

    public void UpdateWakame3Pos () {
        wakame3Pos = transform.position.x;
    }

    // Update is called once per frame
    void Update () {

        UpdateWakame3Pos ();

        if (transform.position.x < shootingWakameDist && returnWakame == false) {
            transform.Translate (0.5f, 0, 0);
        } else if (transform.position.x > shootingWakameDist && returnWakame == false) {
            returnWakame = true;
        } else if (transform.position.x >= -11.75f && returnWakame == true) {
            transform.Translate (-0.5f, 0, 0);
        } else if (transform.position.x < -11.75f && returnWakame == true) {
            Destroy (gameObject);
            WakameManager.shootingWakame = false;
        }

        if (transform.position.x <= -6.0f && returnWakame == true) {
            wakame1Return = true;
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Konbu") {
            returnWakame = true;
        }
    }
}