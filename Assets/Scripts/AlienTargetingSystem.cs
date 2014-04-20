using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlienTargetingSystem : MonoBehaviour
{

    private bool A_isfighting;

    public List<Transform> HumanRegiment { get; set; }
    private Transform targetObject;

    // Use this for initialization
    void Start()
    {
        A_isfighting = false;
        HumanRegiment = GameObject.Find("List_creator").GetComponent<ListingHumes_Aliens>().getSoldierRegiment();
    }

    // Update is called once per frame
    void Update()
    {
        if (A_isfighting == false)
        {
            chooseRandomTarget();
            A_isfighting = true;
        }
        else if (A_isfighting && targetObject == null)
        {
            
            chooseRandomTarget();
            A_isfighting = true;
            //Debug.Log("A HUMAN DIED GAME OVER");
            //Application.LoadLevel(2);
            //A_isfighting = false;
            //Debug.Log("Resetting Human target.");
        }
        else
        {
            //Debug.Log("Wut");
        }

    }

    //This function will find a random target from the size, set his targeted up 1
    //and say that this is targeting something.
    void chooseRandomTarget()
    {
        GameObject.Find("List_creator").GetComponent<ListingHumes_Aliens>().remakeList();
        Debug.Log("Total Humans: " + HumanRegiment.Count);
        int Humantarget = Random.Range(0, HumanRegiment.Count - 1);
        Debug.Log("Target Human: " + Humantarget);

        targetObject = HumanRegiment[Humantarget].transform;
        targetObject.gameObject.GetComponent<HumanTargeted>().Increasetargeted();
        //get THIS guy to set his target to that alien.
        this.gameObject.GetComponent<ShooterController>().setTarget(HumanRegiment[Humantarget].gameObject);
        //the above tells the human that THIS alien is 
        A_isfighting = true;
        Debug.Log("Found a Human Target.");
    }
}