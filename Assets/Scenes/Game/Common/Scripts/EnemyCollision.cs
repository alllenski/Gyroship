using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    private GameObject healthDisplay;

    void Start()
    {
        healthDisplay = GameObject.Find("HealthDisplay");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<EntityStats>().Hurt(gameObject.GetComponent<EntityStats>().damage);
            if (collision.gameObject.name == "Player Ship")
            {
                healthDisplay.GetComponent<HealthDisplay>().Decrease();
            }
        }
    }
}
