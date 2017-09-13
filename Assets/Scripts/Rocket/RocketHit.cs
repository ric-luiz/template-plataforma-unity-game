using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHit : MonoBehaviour {

    public float weaponDamage = 1;
    public GameObject explosionEffect;

    ProjectileController pc;
    
    void Awake () {
        pc = GetComponentInParent<ProjectileController>();
	}
		
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliderOther(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        colliderOther(collision);
    }

    void colliderOther(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            pc.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);

            ColliderEnemy(collision);
        }
    }

    void ColliderEnemy(Collider2D collision) {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHeath>().takeDamage(weaponDamage);
        }
    }
}
