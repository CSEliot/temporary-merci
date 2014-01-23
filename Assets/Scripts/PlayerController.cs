using UnityEngine;
using System.Collections;
[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour {
    
    private Vector3 input = new Vector3(0,0,0);
    
    // System
    private Quaternion targetRotation;
    private Vector3 mousePos;
    private Vector3 worldPos;
    private float mouseMag;
    private bool moving = false;

    // Handling Variables
    public float rotationSpeed = 450;
    public float walkSpeed = 5;

    // Components
    private CharacterController controller;
    private Animator animator;

    // Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
    void Update(){


        if (Input.GetMouseButtonDown(0))
        {
            moving = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moving = false;
        }
        if(moving)
        {
            mousePos = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
            //worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            //worldPos = worldPos.normalized;
            //Debug.Log(worldPos);
            mouseMag = Mathf.Sqrt(Mathf.Pow(mousePos.x, 2) + Mathf.Pow(mousePos.y, 2));
            // Turning mouse pos into a unit vector.
            mousePos = mousePos / mouseMag;
            input.Set(mousePos.x, 0, mousePos.y);//Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            
            animator.SetBool("isRunning", true);

        }
        else if(!moving)
        {
            input.Set(0, 0, 0);
            animator.SetBool("isRunning", false);

        }
        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }


        Vector3 motion = input;
        motion.Set(motion.x, -8, motion.z); //yay psuedo gravity! 

        controller.Move(motion * Time.deltaTime * walkSpeed);


        //END MOVEMENT.
    }

    void OnTriggerEnter(Collider colide)
    {
        Debug.Log(" O HI MARK");
        if (colide.gameObject.tag == "soldierDown")
        {
            Debug.Log("COLLIDEEEEE");
        }
    }

}
