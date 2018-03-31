using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public EnemyStats stats;
	public Stats girlStats;
	bool canBeHit = true;

	//This is called when the enemy touches something.
	void OnCollisionEnter2D(Collision2D hit){
		print ("I have been hit by " + hit.gameObject.name + "!");
		//This defines the enemy's stats.
		if (hit.gameObject.name == "HitBox") {
			hit.gameObject.GetComponent <PolygonCollider2D>().enabled = false;
			canBeHit = false;
			//if (canBeHit == false)
			//	print ("Object was hit by weapon");
			//print (stats.DEF);
			//print (girlStats.ATK);
			//This defines the girl's stats.
			//Calculates if the girl's attack is more than the enemy's defense.
			if ((stats.DEF < girlStats.ATK) && canBeHit == false){
				//Calculates the damage dealt to the enemy.
				stats.HP = stats.HP - (girlStats.ATK - stats.DEF);
				print(stats.HP);
			}else{
				print ("NO DAMAGE");
			}
			InvincibleFrames ();
		}
	}
	// Update is called once per frame
	void Update () {
		if (stats.HP <= 0)
			Destroy (gameObject);
	}
	
	IEnumerator InvincibleFrames(){
		yield return new WaitForSeconds (0.5F);
		canBeHit = true;
	}
}
