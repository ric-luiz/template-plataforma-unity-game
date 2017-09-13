using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2dPlataform : MonoBehaviour {

    public Transform target;
    public float smoothing;

    Vector3 offset;
    float lowY;
	
	void Start () {
        offset = transform.position - target.position;
        lowY = transform.position.y;

    }
		
	void FixedUpdate () {

        if (target == null)
            return;

        Vector3 positionValue = target.position + offset;

        positionValue.y = lowY;

        transform.position = Vector3.Lerp(transform.position,positionValue, smoothing*Time.deltaTime);

        //if (transform.position.y < lowY)
        //    transform.position = new Vector3(transform.position.x,lowY, transform.position.z);


    }
}
