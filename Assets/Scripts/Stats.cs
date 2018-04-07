using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stats : MonoBehaviour {
	//Health and maximum health
	public int HP = 50;
	public int MHP = 50;
	//Defines states that character can be inflicted with
	public string state = "N/A";
	//The time remaining in a state
	public int stateTime = 10;
	//The number ID for which mask the player is using
	public int maskID = 0;
	//Attack power as well as the damage the player can do
	public int ATK = 0;
	public int DAMAGE = 0;
	//Defense
	public int DEF = 0;
	//Magical strength
	public int MAG = 0;
	//Luck (for critical hits and item drops)
	public int LUK = 0;
	//Stanima
	public int STA = 0;
	//Money
	public int GP = 0;
	//The ID's for the primary and secondary (if not two-handed) equipted
	public int wepID = 0;
	public int secID = 0;
	//A boolean for whether something is two-handed or not. False if not.
	public bool dualWeapons = false;

	//Defines slots for items
	// this could just be an array
	public int slot1 = 0;
	public int slot2 = 0;
	public int slot3 = 0;
	public int slot4 = 0;
	public int slot5 = 0;

	//GUI text
	public Text HPText;
	public Text weaponText;
	public Text secondaryText;
	public Text maskText;
	public Text staminaText;
	public Text itemText;

	//This activates when the script loads.
	void Start()
	{
		//Creates the ugly GUI text
		HPText.text = "HP: " + HP + "/" + MHP;
		staminaText.text = "Stamina: " + STA;
		maskText.text = "Mask: ";
		//Sets the damage to the current attack power
		DAMAGE = ATK;
		//Starts the background management of the states
		StartCoroutine (ManageStates ());
	}

	// Update is called once per frame
	void Update ()
	{
		// this should be a switch too
		if (maskID == 0)
		{
			//No mask equipted when 0
			maskText.text = "Mask: Nothing";
		} else if (maskID == 1) {
			//Wrath if mask ID is 1
			maskText.text = "Mask: Wrath";
		} else if (maskID == 2) {
			//Envy if mask ID is 2
			maskText.text = "Mask: Envy";
		} else if (maskID == 3) {
			//Hate if mask ID is 3
			maskText.text = "Mask: Hate";
		} else if (maskID == 4) {
			//Obsession if mask ID is 4
			maskText.text = "Mask: Obsession";
		} else if (maskID == 5) {
			//Loneliness if mask ID is 5
			maskText.text = "Mask: Loneliness";
		} else if (maskID == 6) {
			//Paranoia if mask ID is 6
			maskText.text = "Mask: Paranoia";
		} else {
			/*
			 * This mask is a SPECIAL one. I, Greed, have developed the ULTIMATE MASK. Whaaat?
			 * It looks like a paper mask? And WHAAAAT? You don't trust me?!! Let me tell ya, this ain't
			 * any ol' paper mask. This is what I call THE CHAMPION'S MASK!!! Only the FINEST of heroes
			 * would be WORTHY of buying this beauty of a creation. Now, you gonna buy it or what?
			 * It's 50000 gold.
			*/
			maskText.text = "Mask: Paper Mask";
		}
		HPText.text = "HP: " + HP + "/" + MHP;
		staminaText.text = "Stamina: " + STA;
	}
	
	// Methods should follow Pascal case
	IEnumerator ManageStates()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			
			// just use a switch with an Enum here 
			// IE Status.Poisoned, Status.None, Status.Whatever
			if (state == "VENOM")
			{
				//Poisoned
				yield return new WaitForSeconds (1);
				HP = HP - 2;
				stateTime = stateTime - 1;

				if (stateTime == 0)
				{
					state = "N/A";
					stateTime = 10;
				}
			}
			else if(state == "ATK UP")
			{
				//Attack buff
				yield return new WaitForSeconds (1);
				DAMAGE = ATK * 2;
				stateTime = stateTime - 1;

				if (stateTime == 0)
				{
					state = "N/A";
					stateTime = 10;
				}
			}
		}
	}
}
