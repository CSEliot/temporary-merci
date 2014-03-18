using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
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
    void Start()
    {
        thisTransform = this.transform;
        numTarget = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //control camera following, doesn't when zooming
        if (shouldMove)
        {
            Debug.Log("Moving Camera");
            posX = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, smoothTime);
            posZ = Mathf.SmoothDamp(thisTransform.position.z, target.position.z, ref velocity.z, smoothTime);
            thisTransform.position = new Vector3(posX, this.transform.position.y, posZ);
        }
        else
        {
            Debug.Log("NOT moving camera");
            //this.transform.position = new Vector3(0f,0f,0f);
        }
    }

    public void unZoom(UnityEngine.GameObject myObject)
    {
        //change camera to back above merci
        thisTransform.position = oldPos;
        //get camera following again
        shouldMove = true;
        //MOVE THE body back up
        myObject.transform.GetChild(6).transform.Translate(new Vector3(0, 20f, 0));
        //reference to arm transform
        Transform arm = myObject.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(1);
        //makes arm invisible
        arm.GetComponent<SkinnedMeshRenderer>().enabled = false;
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
        Debug.Log(myObject.transform.GetChild(6).name);
        Debug.Log(myObject.transform.GetChild(6).GetChild(0).name);
        Debug.Log(myObject.transform.GetChild(6).GetChild(0).GetChild(0).name);
        Debug.Log(myObject.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(1).name);



        Transform arm = myObject.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(1);
        //makes arm visible
        arm.GetComponent<SkinnedMeshRenderer>().enabled = true;

        //move body out of way
        Debug.Log(myObject.transform.GetChild(6).name);
        //move the body away
        myObject.transform.GetChild(6).transform.Translate(new Vector3(0, -20f, 0));
        
        //move camera
        Vector3 armPos = new Vector3(arm.transform.position.x - 9f, arm.transform.position.y + 2f, arm.transform.position.z);
        this.transform.position = armPos;

        /***while ((thisTransform.position.y >= numTarget+2f))
        {

            //Mathf.SmoothDamp(thisTransform.position.y, numTarget, ref velocity.y, smoothTime),
            //Debug.Log("Camera Position is: " + thisTransform.position.y);
            //System.Threading.Thread.Sleep(50);
            thisTransform.position = new Vector3 (arm.position.x,  arm.position.y + 2f, arm.position.z);
        }*/
    }

}
