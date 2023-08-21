using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LaserScript : MonoBehaviour
{
    
    public float force = 10f;
    public float lifeTime = 3f;
    private Rigidbody2D rb;
    public ParticleSystem pSystem;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
        Vector3 direction = transform.up;
        rb.velocity = direction.normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "BlueLaser(Clone)")
        {
            if (collision.tag == "RedBase")
            {
                collision.GetComponent<Health>().Damage();
                Instantiate(pSystem, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            if (collision.tag == "BattleShip_Red")
            {
                collision.GetComponent<Health>().Damage();
                Instantiate(pSystem, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            if (collision.tag == "Cruiser_Red")
            {
                collision.GetComponent<Health>().Damage();
                Instantiate(pSystem, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            if (collision.tag == "Fighter_Red")
            {
                collision.GetComponent<Health>().Damage();
                Instantiate(pSystem, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

        }
        if (gameObject.name == "RedLaser(Clone)")
        {
            force *= 2;
            if (collision.tag == "BlueBase")
            {
                collision.GetComponent<Health>().Damage();
                
               Instantiate(pSystem, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            if (collision.tag == "Battleship")
            {
                collision.GetComponent<Health>().Damage();
                Instantiate(pSystem, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            if (collision.tag == "Cruiser")
            {
                collision.GetComponent<Health>().Damage();
                Instantiate(pSystem, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            if (collision.tag == "Fighter")
            {
                collision.GetComponent<Health>().Damage();
                Instantiate(pSystem, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        
    }

}
