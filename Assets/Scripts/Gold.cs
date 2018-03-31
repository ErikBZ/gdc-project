using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {
	public int value = 1;
	public AudioClip ping;
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D hit){
		AudioSource Clip = GetComponent<AudioSource>();
		//print ("Hit something");
		if (hit.gameObject.name == "Girl") {
			hit.gameObject.GetComponent<Stats> ().GP += value;
			print (hit.gameObject.GetComponent<Stats> ().GP);
			Destroy (gameObject);
		} else if (hit.gameObject.name == "Ground") {
			Clip.PlayOneShot (ping,0.5F);
		}
	}
}
