using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCall : MonoBehaviour {

    private delegate void Call();
    private Call call;

    void Start() {
        call += OnCall;
    }

    public void OnCall() {
        Debug.Log("Numm");
    }

    void Update() {

    }
}

public class Test {
    public void OnCa() {
        Debug.Log("OON");
    }
}
