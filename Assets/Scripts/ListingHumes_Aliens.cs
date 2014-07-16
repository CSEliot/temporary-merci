using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListingHumes_Aliens : MonoBehaviour {

    public List<Transform> SoldierRegiment;
    public List<Transform> AlienRegiment;
    GameObject[] alienarray;
    GameObject[] soldierarray;

	// Use this for initialization
	void Start () {
        soldierarray = GameObject.FindGameObjectsWithTag("soldierDown"); //Replace with SoldierUp
        Debug.Log("Num of soldiers found: " + soldierarray.Length);
        for (int Q = 0; Q < soldierarray.Length; Q++){
            SoldierRegiment.Add(soldierarray[Q].transform);
        }
        alienarray = GameObject.FindGameObjectsWithTag("alien"); // Replace with alienup
        Debug.Log("Num of aliens found: " + alienarray.Length);
        for (int Q = 0; Q < alienarray.Length; Q++){
            AlienRegiment.Add(alienarray[Q].transform);
        }
	}

    public void remakeList()
    {
       
        soldierarray = GameObject.FindGameObjectsWithTag("soldierDown"); //Replace with SoldierUp
        if (soldierarray.Length == 0)
        {
            Application.LoadLevel(3);
        }
        Debug.Log("Num of soldiers found: " + soldierarray.Length);
        SoldierRegiment.Clear();
        for (int Q = 0; Q < soldierarray.Length; Q++)
        {
            
            SoldierRegiment.Add(soldierarray[Q].transform);
        }
       
        alienarray = GameObject.FindGameObjectsWithTag("alien"); // Replace with alienup
        if (alienarray.Length == 0)
        {
            Application.LoadLevel(3);
        }
        Debug.Log("Num of aliens found: " + alienarray.Length);
        AlienRegiment.Clear();
        for (int Q = 0; Q < alienarray.Length; Q++)
        {
            
            AlienRegiment.Add(alienarray[Q].transform);
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        for (int Q = 0; Q < alienarray.Length; Q++)
        {

            if (alienarray[Q] == null)
            {
                Debug.Log("Null reference, must mean dead thing! Aleins remake list!");
                remakeList();
            }
        }
        for (int Q = 0; Q < soldierarray.Length; Q++)
        {

            if (soldierarray[Q] == null)
            {
                Debug.Log("Null reference, must mean dead thing! Humans remake list!");
                remakeList();
            }
        }
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

