using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{

    public health health;
    [SerializeField]public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
void OnTriggerEnter2D(Collider2D collision)
 {
     var chealth = col.GetComponentInParent<phealth>();
     if (chealth == health)
     {
	 health.currentHealth = health.currentHealth - damage;
     }
 }

 void TakeDamage(int damage)
    {
    if(health.currentHealth <= 0)
	{
			
		Destroy(this.gameObject);
			
	}
	}
}
