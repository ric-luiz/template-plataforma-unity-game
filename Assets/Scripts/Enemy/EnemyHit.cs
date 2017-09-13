using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

    public float damage = 1;
    public float damageRate = 1;
    public float pushBackFroce = 3;

    float nextDamage = 0;
	
	void Start () {
		
	}
		
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && nextDamage < Time.time) {
            nextDamage = Time.time + damageRate;
            collision.GetComponent<PlayerHealth>().takeDamage(damage);
            pushBack(collision.transform);
        }
    }

    void pushBack(Transform other) {
        Vector2 forceDirection = new Vector2(0,other.position.y - transform.position.y).normalized;
        forceDirection *= pushBackFroce;
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.AddForce(forceDirection,ForceMode2D.Impulse);
    }

}
