using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wakame1Controller : MonoBehaviour {

    // Start is called before the first frame update
    void Start () {
        Wakame3Controller.wakame1Return = false;
    }

    // Update is called once per frame
    void Update () {
        if (Wakame3Controller.wakame1Return == false) {
            this.GetComponent<Image> ().fillAmount += Time.deltaTime * 7.0f;
        } else {
            this.GetComponent<Image> ().fillAmount -= Time.deltaTime * 7.0f;
        }

        if (Wakame3Controller.wakame1Return == true && this.GetComponent<Image> ().fillAmount == 0) {
            Destroy (gameObject);
        }
    }
}