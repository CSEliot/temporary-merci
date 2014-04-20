using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private Vector3 velocity;
    public Transform target;
	private Transform thisTransform;
    public float smoothTime;
    private float numTarget;
    private bool shouldMove = true;
    float posX;
    float posZ;

    private Vector3 oldPos;
    // Use this for initialization
    void Start()
    {
        thisTransform = this.transform;
        numTarget = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //control camera following, doesn't when zooming
        if (shouldMove)// && thisTransform.position.y > 10f)
        {
            //Debug.Log("Moving Camera");
            posX = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, smoothTime);
            posZ = Mathf.SmoothDamp(thisTransform.position.z, target.position.z, ref velocity.z, smoothTime);
            thisTransform.position = new Vector3(posX, this.transform.position.y, posZ);
        }
        else
        {
            //thisTransform.position = oldPos;
            //Debug.Log("NOT moving camera");
            //this.transform.position = new Vector3(0f,0f,0f);
        }
    }

    public void unZoom()
    {
        //change camera to back above merci
        transform.position = oldPos;
        Debug.Log("Old Position Set: " + oldPos);
        //get camera following again
        shouldMove = true;
        //MOVE THE body back up
        //myObject.transform.GetChild(6).transform.Translate(new Vector3(0, 20f, 0));
        //reference to arm transform
        //Transform arm = myObject.transform.GetChild(0);
        //makes arm invisible
        //arm.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = false;
    }



    public void doZoom(UnityEngine.GameObject myObject)
    {
        shouldMove = false;

        
        oldPos = new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.z);
        //Debug.Log ("Zooming");
        //get arm's height??
        numTarget = myObject.transform.position.y;
        Debug.Log("Object Y is: " + numTarget);
        Debug.Log(myObject.transform.childCount);

        //reference to arm transform
        Debug.Log(myObject.transform.name);
        Debug.Log(myObject.transform.GetChild(0).name);

		//get arm reference
        Transform arm = myObject.transform.GetChild(0);
		//get arm location for camera. Due to offset, some manual modifications have, to occur.
        Vector3 armPos = new Vector3(arm.transform.position.x + 0f, arm.transform.position.y + 1.42f, arm.transform.position.z + 14f);// 15.2f);
        //makes arm visible
        arm.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = true;

        //move body out of way
        //Debug.Log("This is the body to move: " + myObject.transform.name);
        //move the body away
		//Debug.Log("Moving body down"); 
		//myObject.transform.position =  new Vector3(myObject.transform.position.x , myObject.transform.position.y - 7f, myObject.transform.position.z);
		//arm.transform.position = armPos;
        
        //move camera
		Debug.Log("This position WAS: " + this.transform.position);
        transform.position = armPos;
		Debug.Log("This position IS : " + this.transform.position);
        /***while ((thisTransform.position.y >= numTarget+2f))
        {
            //Mathf.SmoothDamp(thisTransform.position.y, numTarget, ref velocity.y, smoothTime),
            //Debug.Log("Camera Position is: " + thisTransform.position.y);
            //System.Threading.Thread.Sleep(50);
            thisTransform.position = new Vector3 (arm.position.x,  arm.position.y + 2f, arm.position.z);
        }*/
    }

}
