using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacmentController : MonoBehaviour
{

    public GameObject HeadCamera;
    public GameObject Accardion;
    public GameObject Collider;



    // Use this for initialization
    void Start()
    {
        Accardion.transform.position = new Vector3(HeadCamera.transform.position.x, HeadCamera.transform.position.y, HeadCamera.transform.position.z + 0.3f);
        this.gameObject.transform.position = HeadCamera.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Collider.transform.position = HeadCamera.transform.position;

    }
}
