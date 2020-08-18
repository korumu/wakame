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

    public static float wakame3Pos = 0;

    // Start is called before the first frame update
    void Start () {
        this.GetComponent<SpriteRenderer> ().sortingLayerName = "wakameOku";
        this.GetComponent<SpriteRenderer> ().sortingOrder = 2;
    }

    // Update is called once per frame
    void Update () {
        wakame3Pos = transform.position.x;

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
}