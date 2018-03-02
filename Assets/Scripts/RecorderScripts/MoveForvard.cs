using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForvard : MonoBehaviour {
    public bool move = false;
    private Vector3 _startPoz;
    private void Start()
    {
        _startPoz = this.transform.position;
    }

    void Update () {
        if (move == true)
            this.transform.position += Vector3.forward * Time.deltaTime * 2;
        else
            this.transform.position = _startPoz;

    }
}
