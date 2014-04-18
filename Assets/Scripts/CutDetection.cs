using UnityEngine;
using System.Collections;

public class CutDetection : MonoBehaviour {

   private bool InTophalf;
   private bool InBottomhalf;
   private bool IsCut;
   private bool IsLMouseDown;

   private float MouseY;
   private float ScreenHeight;
   private float ScreenYCenter;
  
	// Use this for initialization
	void Start () {
        ScreenHeight = Screen.height;
        ScreenYCenter = ScreenHeight / 2;
        Debug.Log("Screen Height is");
        Debug.Log(ScreenHeight);
   InTophalf = false;
   InBottomhalf = false;
   //IsCut = false;
	}
	
	// Update is called once per frame
	void Update () {
        // This if Statement first asks if the left mouse is pressed.
        IsLMouseDown = Input.GetMouseButton(0);
        if (IsLMouseDown)
        {
            MouseY = Input.mousePosition.y;
            // This Statement returns if the mouse is in the top or bottom half of the screen, based on MouseY
            if (MouseY > ScreenYCenter)
            {
                InTophalf = true;
                Debug.Log("InTopHalf");
            }
            else if (MouseY < ScreenYCenter)
            {
                InBottomhalf = true;
                Debug.Log("InBottomHalf");
            }
            //This occurs when the mouse has been in the top and bottom half, when it's pressed down.
         if (InTophalf && InBottomhalf)
            {
                IsCut = true;
                Debug.Log("Has Been Cut");
             }  
        }
            //If the Mouse is released, this will reset flags.
        else
        {
            if (InTophalf || InBottomhalf)
            {
                InTophalf = false;
                InBottomhalf = false;
                Debug.Log("Flags Reset");
            } 
        }
	}
}
