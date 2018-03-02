using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetArmPosition : MonoBehaviour {

    public GameObject Arm;
    Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        OnCollisionSelfDestroy GC = Arm.GetComponent<OnCollisionSelfDestroy>();

        text.text = GC.GetHitCount().ToString();
     
	}
}
