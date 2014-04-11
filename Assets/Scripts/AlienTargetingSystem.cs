using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlienTargetingSystem: MonoBehaviour {

    private bool A_isfighting;

    public List<Transform> HumanRegiment { get; set; }

	// Use this for initialization
	void Start () {
        A_isfighting = false;
        HumanRegiment = getHumanRegiment();
	}
	
	// Update is called once per frame
	void Update () {
        if (A_isfighting == false)
        {
            chooseRandomTarget();
            A_isfighting = true;
        }
        //This should occur when your target is dead.
        else if (A_isfighting && true /* Fill in for HumanRegiment[Humantarget].gameObject.GetComponent<???>().Getaliveness();*/)
        {
            //A_isfighting = false;
            Debug.Log("Resetting Human target.");
        }

	}

    //This function will find a random target from the size, set his targeted up 1
    //and say that this is targeting something.
    void chooseRandomTarget(){

        Debug.Log("Total Humans: " + HumanRegiment.Count);
        int Humantarget = Random.Range(0, HumanRegiment.Count);
        Debug.Log("Target Human: " + Humantarget);
        
        HumanRegiment[Humantarget].gameObject.GetComponent<HumanTargeted>().Increasetargeted();

        A_isfighting = true;
        Debug.Log("Found a Human Target.");
    }
    List<Transform> getHumanRegiment()
    {
        return GameObject.Find("List_creator").GetComponent<ListingHumes_Aliens>().SoldierRegiment;
    }
}

