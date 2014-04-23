using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanTargetingSystem : MonoBehaviour {

    private bool H_isfighting;
    public List<Transform> AlienRegiment { get; set; }
    int Alientarget;
    private Transform targetObject;

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
        else if (H_isfighting && 
            targetObject != null && 
                targetObject.gameObject.GetComponentInChildren<HealthBar>().isDead())
        {
            Debug.Log("Killing the Alien Target.");
            AlienRegiment[Alientarget].GetComponent<Animator>().SetBool("isDead", true);
            Invoke("deleteTarget", 2);
            //H_isfighting = false;
        }
    }

    void deleteTarget()
    {
        Destroy(AlienRegiment[Alientarget].gameObject);
    }
    //This function will find a random target from the size, set his targeted up 1
    //and say that this is targeting something.
    void chooseRandomTarget()
    {
       Debug.Log("Total Aliens: " + AlienRegiment.Count);
       Alientarget = Random.Range(0, AlienRegiment.Count -1);
       Debug.Log("Target Alien: " + Alientarget);


       //tell the alien it's being targetted, this is for you to know roberto!
       targetObject = AlienRegiment[Alientarget].transform;
       targetObject.gameObject.GetComponent<AlienTargeted>().Increasetargeted();
       //get THIS guy to set his target to that alien.
       this.gameObject.GetComponent<ShooterController>().setTarget(AlienRegiment[Alientarget].gameObject);
       H_isfighting = true;
       Debug.Log("Found an Alien Target.");
    }

    //This finds, gets and returns
    List<Transform> getAlienRegiment(){
        return GameObject.Find("List_creator").GetComponent<ListingHumes_Aliens>().AlienRegiment;
    }
}