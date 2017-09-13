using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float rocketSpeed = 10;

    Rigidbody2D rb2d;
	
	void Awake ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z<0)
            rb2d.AddForce(new Vector2(-1,0)*rocketSpeed,ForceMode2D.Impulse);
        else
            rb2d.AddForce(new Vector2(1, 0) * rocketSpeed, ForceMode2D.Impulse);
    }
		
	void Update () {
		
	}

    public void removeForce() {
        rb2d.velocity = new Vector2(0,0);
    }
}
