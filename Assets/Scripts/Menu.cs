using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		int width = Screen.width;
		int height = Screen.height;
		int widthSegment = width / 20;
		int heightSegment = height / 40;

		Rect guiMenu = new Rect (width / 2 - widthSegment * 4, height / 2 - heightSegment * 12,
		                        widthSegment * 8, heightSegment * 24);
		GUI.Box (guiMenu,"YOU LOST"); 


		Rect rectangle0 = new Rect (width/2 - widthSegment * 1 - 15, height/2 - heightSegment * 10,
		                            widthSegment * 2 + 30, heightSegment * 2);
		if(GUI.Button(rectangle0, "Start Game")) {
			Application.LoadLevel(0);
		}
		/*
		Rect rectangle1 = new Rect (width/2 - widthSegment * 1, height/2 - heightSegment * 5,
		                            widthSegment * 2, heightSegment * 2);
		if(GUI.Button(rectangle1, "Restart")) {
			Application.LoadLevel(0);
		}
		*/
		// Make the second button.
		Rect rectangle2 = new Rect (width/2 - widthSegment * 1 - 15, height/2 - heightSegment * 2,
		                            widthSegment * 2 + 30, heightSegment * 2);
		if(GUI.Button(rectangle2, "Exit game")) {
			Application.Quit();
		}
		/*
		Rect rectangle3 = new Rect (width/2 - widthSegment * 1, height/2 + heightSegment,
		                            widthSegment * 2, heightSegment * 2);
		if(GUI.Button(rectangle3, "Level 3")) {
			Application.LoadLevel(1);
		}
		*/
	}
}
