using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanTargetingSystem : MonoBehaviour {

    private bool H_isfighting;
    public List<Transform> AlienRegiment { get; set; }

    // Use this for initialization
    void Start()
    {
        H_isfighting = false;
        AlienRegiment = GameObject.Find("List_creator").GetComponent<ListingHumes_Aliens>().getAlienRegiment();
    }

    // Update is called once per frame
    void Update()
    {
        if (H_isfighting == false)
        {
            chooseRandomTarget();
            H_isfighting = true;
        }
        //This should occur when your target is dead.
        //Stopping a fighting.
        else if (H_isfighting && true /* Fill in for AlienRegiment[Alientarget].gameObject.GetComponent<HealthBar>().Getaliveness();*/)
        {
            //H_isfighting = false;
            Debug.Log("Resetting Alien Target.");
        }
    }

    //This function will find a random target from the size, set his targeted up 1
    //and say that this is targeting something.
    void chooseRandomTarget()
    {
       Debug.Log("Total Aliens: " + AlienRegiment.Count);
       int Alientarget = Random.Range(0, AlienRegiment.Count -1);
       Debug.Log("Target Alien: " + Alientarget);



       AlienRegiment[Alientarget].gameObject.GetComponent<AlienTargeted>().Increasetargeted();
       AlienRegiment[Alientarget].gameObject.GetComponent<ShooterController>().setTarget(this.gameObject);
       H_isfighting = true;
       Debug.Log("Found an Alien Target.");
    }

    //This finds, gets and returns
    List<Transform> getAlienRegiment(){
        return GameObject.Find("List_creator").GetComponent<ListingHumes_Aliens>().AlienRegiment;
    }
}