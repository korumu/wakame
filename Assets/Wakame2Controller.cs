using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Wakame2Controller : MonoBehaviour {

    // Start is called before the first frame update
    void Start () {
        this.GetComponent<SpriteRenderer> ().drawMode = SpriteDrawMode.Tiled;
    }

    // Update is called once per frame
    void Update () {
        var width = Wakame3Controller.wakame3Pos + 6.0f;

        if (WakameManager.shootingWakame && Wakame3Controller.wakame3Pos >= -6.0f) {
            //wakame3のx座標に応じてTiledが伸びますの
            this.GetComponent<SpriteRenderer> ().size = new Vector2 (width, 2);
        } else {
            //フレームの関係かこれ書かないとwidthが0いかないのじゃ
            this.GetComponent<SpriteRenderer> ().size = new Vector2 (0, 2);
        }
    }
}