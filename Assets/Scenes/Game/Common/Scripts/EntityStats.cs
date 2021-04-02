using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{

    public int hitpoints;
    public int damage;

    public void Hurt(int damage)
    {
        hitpoints -= damage;
        if (hitpoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
