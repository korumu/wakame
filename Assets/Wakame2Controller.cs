using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Wakame2Controller : MonoBehaviour {

    // Start is called before the first frame update
    void Start () { }

    // Update is called once per frame
    void Update () {
        if (WakameManager.shootingWakame == true && Wakame3Controller.wakame3Pos >= -6.0f) {
            float width = Wakame3Controller.wakame3Pos + 6.0f;
            this.GetComponent<SpriteRenderer> ().drawMode = SpriteDrawMode.Tiled;
            this.GetComponent<SpriteRenderer> ().size = new Vector2 (width, 2);
        } else {
            this.GetComponent<SpriteRenderer> ().drawMode = SpriteDrawMode.Tiled;
            this.GetComponent<SpriteRenderer> ().size = new Vector2 (0, 2);
        }
    }
}