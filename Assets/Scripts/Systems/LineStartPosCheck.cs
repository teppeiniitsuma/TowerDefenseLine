using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineStartPosCheck : MonoBehaviour {
    public bool GetPosCheck { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "LineStartPos") {
            GetPosCheck = true;
        }
    }

}
