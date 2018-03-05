using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeForword : MonoBehaviour
{

    public GameObject finish;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(this.transform.position, finish.transform.position);
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(this.transform.position, finish.transform.position, fracJourney);
    }
}
