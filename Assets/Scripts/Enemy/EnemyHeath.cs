using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeath : MonoBehaviour {

    public float EnemyMaxHeath = 5;
    float currentHeath;

	void Start () {
        currentHeath = EnemyMaxHeath;
	}
		
	void Update () {
		
	}

    public void takeDamage(float damage) {
        currentHeath -= damage;        
        if (currentHeath <= 0) makeDead();
    }

    void makeDead() {
        Destroy(gameObject);
    }

}
