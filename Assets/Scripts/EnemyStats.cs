using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	public int HP = 0;
	public int ATK = 0;
	public int DEF = 0;
	public int GP = 0;
	//These are the different item drops. Simply put in a prefab for each one or leave it empty.
	public GameObject itemDrop1;
	public GameObject itemDrop2;
	public GameObject itemDrop3;
	bool hasItem;
	int item;

	public GameObject parent;
	void Start(){
		hasItem = System.Convert.ToBoolean( UnityEngine.Random.Range( 0, 2 ) );
		item = UnityEngine.Random.Range( 0, 3 );
	}
	// Update is called once per frame
	void Update () {
		if (HP == 0) {
			if (hasItem = true){
				if (item == 0){
					if (itemDrop1 != null) {
						Instantiate (itemDrop1);
						itemDrop1.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
					}
				}else if (item == 1){
					if (itemDrop2 != null) {
						Instantiate (itemDrop2);
						itemDrop2.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
					}
				}else{
					if (itemDrop3 != null) {
						Instantiate (itemDrop3);
						itemDrop3.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
					}
				}
			}
			Destroy (parent);
		}
	}
}
