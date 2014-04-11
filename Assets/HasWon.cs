using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HasWon : MonoBehaviour {

	private List<Transform> soldiers;
	private int soldiersLeft;
	private int numHealed;
	private bool won;

	// Use this for initialization
	void Start () {
		//get total number of soldiers
		soldiers = GameObject.Find("List_creator").GetComponent<ListingHumes_Aliens>().getSoldierRegiment();
		soldiersLeft = soldiers.Count;
		won = false;
		numHealed = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if(soldiersLeft == 0){
			if(numHealed == 0){
				Debug.Log ("lost");
				//Application.LoadLevel(/*lose screen level*/);
			}//end if
			else{
				Debug.Log ("won");
				won = true;
				//Application.LoadLevel(/*win screen level*/);
			}//end else
		}//end if
	}

	//updates upon soldier death. called from an outside class when soldier dies
	public void soldierDied(){
		Debug.Log ("died");
		soldiersLeft--;
	}

	//updates upon soldier recovery. called from an outside class when soldier is healed
	public void soldierHealed(){
		Debug.Log ("healed");
		soldiersLeft--;
		numHealed++;
	}

	public bool getWon(){
		return won;
	}
}
