using UnityEngine;
using System.Collections;

public class IsSwiped : MonoBehaviour {

	private bool inTopHalf;
	private bool inBotHalf;
	private bool buttonPressed;
	private float mouseY;
	private float halfScreen;
	private bool swiped;

	// Use this for initialization
	void Start () {
		inTopHalf = false;
		inBotHalf = false;
		buttonPressed = false;
		halfScreen = Screen.height / 2;
		swiped = false;
	}
	
	// Update is called once per frame
	void Update () {
		buttonPressed = Input.GetMouseButton (0);
		if (buttonPressed) {
			mouseY = Input.mousePosition.y;
			if (mouseY > halfScreen) {
				inTopHalf = true;
			}//end if
			else if(mouseY < halfScreen){
				inBotHalf = true;
			}//end else if
		}//end if
		else {
			inTopHalf = false;
			inBotHalf = false;
		}//end else
		swiped = (inTopHalf && inBotHalf);
		if (swiped) {
			Debug.Log ("sliced");
			inTopHalf = false;
			inBotHalf = false;
		}//end if
	}
}
