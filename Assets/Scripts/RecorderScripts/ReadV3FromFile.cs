using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadV3FromFile : MonoBehaviour
{
    public Transform items;
    [HideInInspector]
    public string FilePath;
    public List<Vector3> V3ListOfPoints = new List<Vector3>();
    Vector3[] allPoints;

    private void Awake()
    {
        allPoints = V3ListOfPoints.ToArray();
    }


    private void Start()
    {

        for (int f = 0; f < allPoints.Length; f++)
        {
            Transform item = Instantiate(items) as Transform;
            Vector3 position = allPoints[f];            
            item.transform.parent = transform;
            item.transform.localPosition = position;
        }
    }
}
