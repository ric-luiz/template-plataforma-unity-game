using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

    public float aliveTime = 2.0f;	

	void Awake () {
        Destroy(gameObject,aliveTime);           
	}   

}
