using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    
    public GameObject healthBar;
    private List<GameObject> healthBars = new List<GameObject>();

    void Start()
    {
        int health = GameObject.Find("Player Ship").GetComponent<EntityStats>().hitpoints;
        for (int i = 0; i < health; i++)
        {
            healthBars.Add(Instantiate(healthBar, new Vector3(-150f + i * 6f, -76f, 0f), Quaternion.identity));
        }

    }

    public void Increase()
    {
        int health = GameObject.Find("Player Ship").GetComponent<EntityStats>().hitpoints - 1;
        healthBars.Add(Instantiate(healthBar, new Vector3(-150f + health * 6f, -76f, 0f), Quaternion.identity));
    }

    public void Decrease()
    {
        Destroy(healthBars[healthBars.Count - 1]);
        healthBars.RemoveAt(healthBars.Count - 1);
    }
}
