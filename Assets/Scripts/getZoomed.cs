using UnityEngine;
using System.Collections;

public class getZoomed : MonoBehaviour {

	private Vector3 velocity;
	public Transform target;
	private Transform thisTransform;
	public float smoothTime = 1f;
	private float numTarget;


	// Use this for initialization
	void Start () {
		thisTransform = transform;
		numTarget = 2f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void testZoom(){
		Debug.Log ("POOOPZOOM");
	}


	public void doZoom(UnityEngine.GameObject myObject){
		Debug.Log ("Zooming");
		for (int i = 0; thisTransform.position.y >= numTarget+1f ; i++) 
		{
			Debug.Log(thisTransform.position);
			thisTransform.position = new Vector3 (thisTransform.position.x, Mathf.SmoothDamp(thisTransform.position.y, numTarget, ref velocity.y, smoothTime), thisTransform.position.z);
		}


		Debug.Log("Zoomed a bit");
	}

}
