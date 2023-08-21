using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float regenTime = 2f;
    public float timer;
    public AudioSource hitSound;
    private HealthBar healthBar;
    public GameObject explosionEffect;
    public float explosionScale = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
        
        if (gameObject.tag == ("RedBase") || gameObject.tag == ("BlueBase"))
        {
            maxHealth = 500;
        }
        if (gameObject.tag == ("Battleship") || gameObject.tag == ("BattleShip_Red"))
        {
            maxHealth = 200;
        }
        if (gameObject.tag == ("Cruiser") || gameObject.tag == ("Cruiser_Red"))
        {
            maxHealth = 75;
        }
        if (gameObject.tag == ("Fighter") || gameObject.tag == ("Fighter_Red"))
        {
            maxHealth = 15;
        }
        health = maxHealth;
        
        timer = 0f;
        healthBar = GetComponentInChildren<HealthBar>();
        if (healthBar == null)
        {
            Debug.Log("Didnt have health bar");
        }
        else if (healthBar != null)
        {
            healthBar.UpdateHealth(health, maxHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > regenTime )
        {
            health++;
            timer = 0f;
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }
    public void Damage()
    {
        health--;
        hitSound.Play();
        if (healthBar != null)
        {
            healthBar.UpdateHealth(health, maxHealth);
        }
        if (health <= 0)
        {
            GameObject explosion = Instantiate(explosionEffect,transform.position,Quaternion.identity);
            explosion.transform.localScale *= explosionScale;
            Destroy(gameObject);
        }
    }
}
