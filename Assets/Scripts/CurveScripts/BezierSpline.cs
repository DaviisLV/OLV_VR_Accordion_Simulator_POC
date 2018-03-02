using UnityEngine;
using System;

public class BezierSpline : MonoBehaviour {

   
    private static int V3 = 121;
    public Vector3[] points = new Vector3[V3];
    public float pozX1 = 0.2f;
    public float pozX2 = -0.2f;
        float X = 0;
        float Y = 0;
        float Z = 0;
    public bool swich = false;

    private LineRenderer lineRenderer;
    private int index=0;

    public void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        GenerateV3();
       // SetLinePoints(points);
    }
    public void GenerateV3()
    {
       int rightSide = 1;
        int leftSide = 0;

        for (int i = 0; i < V3; i++)
        {
            if (rightSide <= 2)
            {
                if (swich)
                X = pozX1;
                else
                X = pozX2;
                rightSide++;
                leftSide = 0;
            }
            else
            {
                if(leftSide <=1)
                {
                    if (swich)
                        X = pozX2;
                    else
                        X = pozX1;
                    leftSide++;
                }
                else
                {
                    rightSide = 0;
                }
            }
            if ( i != 0)
            {
               // Z = Z + 0.2f;
                Z = UnityEngine.Random.Range(Z, Z +1f);
            }

            points[i] = new Vector3(X,Y,Z);
        }
    }



public int CurveCount {
		get {
			return (points.Length - 1) / 3;
		}
	}

	public Vector3 GetPoint (float t) {
		int i;
		if (t >= 1f) {
			t = 1f;
			i = points.Length - 4;
		}
		else {
			t = Mathf.Clamp01(t) * CurveCount;
			i = (int)t;
			t -= i;
			i *= 3;
		}
		return transform.TransformPoint(Bezier.GetPoint(points[i], points[i + 1], points[i + 2], points[i + 3], t));
	}
	
	public Vector3 GetVelocity (float t) {
		int i;
		if (t >= 1f) {
			t = 1f;
			i = points.Length - 4;
		}
		else {
			t = Mathf.Clamp01(t) * CurveCount;
			i = (int)t;
			t -= i;
			i *= 3;
		}
		return transform.TransformPoint(Bezier.GetFirstDerivative(points[i], points[i + 1], points[i + 2], points[i + 3], t)) - transform.position;
	}
	
	public Vector3 GetDirection (float t) {
		return GetVelocity(t).normalized;
	}

   
    

}