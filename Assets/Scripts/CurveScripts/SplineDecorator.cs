﻿using UnityEngine;

public class SplineDecorator : MonoBehaviour {

	public BezierSpline spline;

	public int frequency;

	public bool lookForward;

	public Transform items;

	private void Start () {
		if (frequency <= 0 || items == null ) {
			return;
		}
		float stepSize = frequency ;
		if ( stepSize == 1) {
            stepSize = 1f / stepSize;
        }
		else {
            stepSize = 1f / (stepSize - 1);      
		}
		for (int p = 0, f = 0; f < frequency; f++) {
			for (int i = 0; i < 1; i++, p++) {
				Transform item = Instantiate(items) as Transform;
				Vector3 position = spline.GetPoint(p * stepSize);
				item.transform.localPosition = position;
				if (lookForward) {
					item.transform.LookAt(position + spline.GetDirection(p * stepSize));
				}
				item.transform.parent = transform;
			}
		}
	}


}