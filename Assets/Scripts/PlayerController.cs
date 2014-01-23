using UnityEngine;
using System.Collections;
[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour {
    
    private Vector3 input;
    
    // System
    private Quaternion targetRotation;
    private Camera camedra = GameObject.Find("Main Camera").GetComponent(Camera);
    private Vector3 mousePos;
    private Vector3 worldPos;


    // Handling Variables
    public float rotationSpeed = 450;
    public float walkSpeed = 25;

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
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        /*
        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("MOUSE DOWN");
            worldPos = camera.ScreenToWorldPoint(Input.mousePosition);
            worldPos.y = 0;
            targetRotation = Quaternion.LookRotation(worldPos);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }

        Vector3 motion = worldPos;
        motion += Vector3.up * -8;

        if (motion.magnitude == 8) //8 means that only gravity is pulling down, aka no movement elsewhere.
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }

        controller.Move(motion * Time.deltaTime * walkSpeed);

    }
}
