using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListingHumes_Aliens : MonoBehaviour {

    public List<Transform> SoldierRegiment;
    public List<Transform> AlienRegiment;

	// Use this for initialization
	void Start () {
        GameObject[] soldierarray;
        soldierarray = GameObject.FindGameObjectsWithTag("soldierDown"); //Replace with SoldierUp
        Debug.Log("Num of soldiers found: " + soldierarray.Length);
        for (int Q = 0; Q < soldierarray.Length; Q++){
            SoldierRegiment.Add(soldierarray[Q].transform);
        }
        GameObject[] alienarray;
        alienarray = GameObject.FindGameObjectsWithTag("alien"); // Replace with alienup
        Debug.Log("Num of aliens found: " + alienarray.Length);
        for (int Q = 0; Q < alienarray.Length; Q++){
            AlienRegiment.Add(alienarray[Q].transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public List<Transform> getAlienRegiment()
    {
        return AlienRegiment;
    }

    public List<Transform> getSoldierRegiment()
    {
        return SoldierRegiment;
    }

}

