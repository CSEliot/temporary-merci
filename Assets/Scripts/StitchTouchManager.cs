using UnityEngine;
using System.Collections;

public class StitchTouchManager : ExTouch.ExTouchObject {
	public int ID;
	public StitchParent parent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		print ("HIT " + ID);
		parent.hitTrigger(ID);
	}

	public override bool OnDrag(ExTouch.ExGestureObject g) {
		print("Got a drag");
		//Vector3 newPos = new Vector3(g.EndPosition.x, g.EndPosition.y, transform.position.z);
		//transform.position = newPos;
		//this.gameObject. = g.EndPosition.x;
		//this.gameObject.transform.position.y = g.EndPosition.y;
		return true;
	}
}
