using UnityEngine;
using System.Collections;

public class StitchParent : MonoBehaviour {
	public int numPoints = 5;
	private bool[] hits;
	// Use this for initialization
	void Start () {
		hits = new bool[numPoints];
	}

	void reset() {
		for(int i = 0; i < numPoints; i++) hits[i] = false;
	}

	public bool hitTrigger(int point){
		if(point == 0) {
			reset();
			hits[0] = true;
			return true;
		} else {
			if(hits[point-1]) {
				hits[point] = true;
				return true;
			}else{
				reset();
				return false;
			}
		}
	}


	// Update is called once per frame
	void Update () {
		if(hits[numPoints-1]){
			print("Successful Stitch");
			reset();
		}
	}
}
