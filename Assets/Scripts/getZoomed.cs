using UnityEngine;
using System.Collections;

public class getZoomed : MonoBehaviour {
    private Vector3 velocity;
    public Transform target;
    private Transform thisTransform;
    public float smoothTime;
    private float numTarget;
    public bool shouldMove = true;
    float posX;
    float posZ;

    private Vector3 oldPos;
	// Use this for initialization
	void Start () {
		thisTransform = transform;
		numTarget = 2f;
	}
	
	// Update is called once per frame
	void Update () {
        if (shouldMove)
        {
            posX = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, smoothTime);
            posZ = Mathf.SmoothDamp(thisTransform.position.z, target.position.z, ref velocity.z, smoothTime);
            thisTransform.position = new Vector3(posX, this.transform.position.y, posZ);
        }
	}

    public void unZoom(UnityEngine.GameObject myObject)
    {
        thisTransform.Translate(new Vector3(0f, 10f, 0f));//oldPos;
        shouldMove = true;
        //MOVE THE arm back down
        myObject.transform.GetChild(6).transform.Translate(new Vector3(0, 20f, 0));
        //reference to arm transform
        Transform arm = myObject.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(1);
        //makes arm visible
        arm.GetComponent<SkinnedMeshRenderer>().enabled = false;
    }


	public void doZoom(UnityEngine.GameObject myObject){
        oldPos = thisTransform.position;
		Debug.Log ("Zooming");
        numTarget = myObject.transform.position.y;
        Debug.Log("Object Y is: " + numTarget);
        Debug.Log(myObject.transform.childCount);

        //reference to arm transform
        Debug.Log(myObject.transform.name);
        Debug.Log(myObject.transform.GetChild(6).name);
        Debug.Log(myObject.transform.GetChild(6).GetChild(0).name);
        Debug.Log(myObject.transform.GetChild(6).GetChild(0).GetChild(0).name);
        Debug.Log(myObject.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(1).name);
        
        
        
        Transform arm = myObject.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(1);
        //makes arm visible
        arm.GetComponent<SkinnedMeshRenderer>().enabled = true;
        //float myObjectTransformX = myObject.transform.GetChild(1).transform.position.x;
        //float myObjectTransformZ = myObject.transform.GetChild(1).transform.position.z;
        

        //move body out of way
        Debug.Log(myObject.transform.GetChild(6).name);
        //move the body away
        myObject.transform.GetChild(6).transform.Translate(new Vector3(0, -20f, 0));
        //move the arm in
        arm.transform.Translate(new Vector3(0, 20f, 0));
        //disable following script
        //shouldMove = false;

        //move camera
        thisTransform.Translate(new Vector3(arm.transform.position.x, arm.transform.position.y + 2f, arm.transform.position.z));

		/***while ((thisTransform.position.y >= numTarget+2f))
        {

            //Mathf.SmoothDamp(thisTransform.position.y, numTarget, ref velocity.y, smoothTime),
            //Debug.Log("Camera Position is: " + thisTransform.position.y);
            //System.Threading.Thread.Sleep(50);
			thisTransform.position = new Vector3 (arm.position.x,  arm.position.y + 2f, arm.position.z);
		}*/
	}

}
