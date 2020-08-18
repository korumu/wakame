using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonbuGenerator : MonoBehaviour {

    public GameObject konbuPre;
    float span = 1.0f;
    float delta = 0;
    public static float elapsedTime = 0;
    float s1 = 3.0f;
    float s2 = 0;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        elapsedTime += Time.deltaTime;
        s1 = 3.0f - elapsedTime * 0.05f; //経過時間に応じ限りなく3に近づく
        s2 = s1 + 1.0f;
        if (s1 < 0) {
            s1 = 0.01f;
            s2 = 0.5f;
        }

        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            this.span = Random.Range (s1, s2);
            GameObject go = Instantiate (konbuPre) as GameObject;
            go.transform.position = new Vector2 (81.5f, -6.0f);
        }
    }

}