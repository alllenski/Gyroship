using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{

    public int hitpoints;
    public int damage;

    public GameObject healthDrop;

    public void Hurt(int damage)
    {
        hitpoints -= damage;
        if (hitpoints <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                int randomNumber = Random.Range(0, 3);
                if (randomNumber == 2)
                {
                    Instantiate(healthDrop, transform.position, Quaternion.identity);
                }
            }
            gameObject.SetActive(false);
        }
    }
}
