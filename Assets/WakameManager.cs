using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakameManager : MonoBehaviour {

    public Transform canvas;
    public GameObject wakame1Pre;
    public GameObject wakame3Pre;
    public static bool shootingWakame = false;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Space) && shootingWakame == false) {
            shootingWakame = true;

            //wakame1つくるよ
            GameObject wakame1 = Instantiate (wakame1Pre, canvas);

            //wakame3つくるよ
            GameObject wakame3 = Instantiate (wakame3Pre) as GameObject;
            wakame3.transform.position = new Vector2 (-11.75f, -5.75f);
        }
    }
}