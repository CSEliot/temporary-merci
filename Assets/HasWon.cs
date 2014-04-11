using UnityEngine;
using System.Collections;

public class HasWon : MonoBehaviour {

	private GameObject[] soldiers;
	private int soldiersLeft;
	private bool won;

	// Use this for initialization
	void Start () {
		//get total number of soldiers
		soldiers = GameObject.FindGameObjectsWithTag ("soldierDown");
		soldiersLeft = soldiers.GetLength(0);
		won = false;


	}
	
	// Update is called once per frame
	void Update () {
		//decrease soldiersLeft when a soldier dies/is healed
		if(/*soldier dies*/){
			Debug.Log ("died");
			soldiersLeft--;
		}
		else if(/*soldier healed*/){
			Debug.Log ("healed");
			soldiersLeft--;
		}

		if(soldiersLeft == 0){
			Debug.Log ("won");
			Application.LoadLevel(/*win screen level*/);
		}//end if
	}
}
