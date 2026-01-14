using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	public int Vida;
	public Animator animator;
	public Slider BarraDeVida;


	public void TakeDamage(int damageAmount)
	{
		BarraDeVida.value = Vida;
		Vida -= damageAmount;
		if(Vida < 0)
		{
			animator.SetBool("Death",true);
			GetComponent<Collider>().enabled = false;
			Destroy(gameObject, 3);
		}
		else
		{
			animator.SetTrigger("Hurt");
		}
	}

}
