using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDistanceToLine : MonoBehaviour {

    public BezierSpline spline;

    public float duration;
    float time= 0;
    private float progress;
    private void Start()
    {
      
        InvokeRepeating("PointsV3", 0.0f, 1.0f);
    }

    private void Update()
    {
        progress += Time.deltaTime / duration;
        if (progress > 1f)
        {
            progress = 1f;
        }
        if (time < 30)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
        }


    }
    public void PointsV3()
    {
        Debug.Log(spline.GetPoint(time / 30));
    }
}
