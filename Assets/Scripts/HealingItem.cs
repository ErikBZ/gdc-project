using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour {

	public Animator anim;
	public int healing;
	public Stats girlStats;
	void Start(){
		anim = GetComponent<Animator> ();
		girlStats = GameObject.Find ("Girl").GetComponent<Stats>();
	}

	void OnCollisionEnter2D(Collision2D hit){
		if (hit.gameObject.name == "Girl") {
			girlStats.HP += healing;
			if (girlStats.HP > girlStats.MHP) {
				girlStats.HP = girlStats.MHP;
			}
			Destroy (gameObject);
		} else if (hit.gameObject.name == "Ground"){
			//anim.Play ("Delete");
			//deleteObject ();
			anim.Play("Idle");
			waitBeforeDeletion();
		}
	}
	IEnumerator deleteObject(){
		int i = 0;
		yield return new WaitForSeconds (1.0F);
		if (i == 10) {
			Destroy(gameObject);
		}
		i += 1;
	}
	IEnumerator waitBeforeDeletion(){
		print ("Starting deletion");
		yield return new WaitForSeconds (5.0F);
		anim.SetBool ("Timeout", true);
		deleteObject ();
	}
}
