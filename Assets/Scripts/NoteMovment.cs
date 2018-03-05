using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovment : MonoBehaviour
{

    public GameObject CurveObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        CurveObject.transform.position += Vector3.back * Time.deltaTime * 2;
    }

}
