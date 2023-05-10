using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
	[SerializeField]public int maxHealth = 100;
	public int currentHealth;

	public healthbar healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    //Update is called once per frame
   /* void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
    }*/

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

		if(currentHealth <= 0)
		{
			//FindObjectOfType<GameManeger>().EndGame;
			gameObject.GetComponent<playerMovementPlus>().enabled = false;
			//Debug.Log("Game Over");
		}
		

		
	}

}