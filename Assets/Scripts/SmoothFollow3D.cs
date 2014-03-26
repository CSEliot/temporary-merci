using UnityEngine;
using System.Collections;

public class SmoothFollow3D : MonoBehaviour {

    public Transform target;
    private float smoothTime = 0.3f;
    private Transform thisTransform;
    private Vector3 velocity;

	// Use this for initialization
	void Start () {
	    thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
	    thisTransform.position.Set(Mathf.SmoothDamp( thisTransform.position.x, target.position.x, ref velocity.x, smoothTime), 
                                   target.position.y, 
                                   Mathf.SmoothDamp( thisTransform.position.z, target.position.z, ref velocity.z, smoothTime));
	}
}
