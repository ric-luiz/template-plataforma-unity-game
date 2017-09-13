using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public GameObject deathFx;
    public float maxHealth = 5;
    float currentHealth;
    PlayerController pc;

    //HUD
    public Slider lifeBar;    
    public Image damageScreen;
    bool damaged = false;
    Color damagedColor = new Color(0f,0f,0f,0.5f);
    [Range(0.0f,10.0f)] public float smoothLerpDamage = 5.0f;


	void Start () {
        currentHealth = maxHealth;
        pc = GetComponent<PlayerController>();

        //HUD Inicializando
        lifeBar.maxValue = maxHealth;
        lifeBar.value = maxHealth;
	}
		
	void Update () {
		effectScreenDamage();
	}

    void effectScreenDamage(){
        if(damaged){
            damaged = false;
            damageScreen.color = damagedColor;
        } else {
            damageScreen.color = Color.Lerp(damageScreen.color,Color.clear,smoothLerpDamage * Time.deltaTime);
        }
    }

    public void takeDamage(float damage) {
        currentHealth -= damage;
        lifeBar.value = currentHealth;
        damaged = true;

        if (currentHealth <= 0) makeDead();
    }

    public void makeDead() {
        Instantiate(deathFx,transform.position,transform.rotation);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
