using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private GameObject healthDisplay;

    void Start()
    {
        healthDisplay = GameObject.Find("HealthDisplay");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EntityStats>().Hurt(gameObject.GetComponent<EntityStats>().damage);
        }
        if (collision.gameObject.tag == "Powerup" && gameObject.name == "Player Ship")
        {
            Destroy(collision.gameObject);   
            gameObject.GetComponent<EntityStats>().hitpoints++;
            healthDisplay.GetComponent<HealthDisplay>().Increase();
        }
    }
}
