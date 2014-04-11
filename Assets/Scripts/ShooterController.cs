﻿using UnityEngine;
using System.Collections;

public class ShooterController : MonoBehaviour {
	public Rigidbody projectile;
	public GameObject target;
	public float burstDelay, bulletDelay, burstTime, fireSpeed;
	public int burstSize, bulletsFired;
	public bool newTarget;
	// Use this for initialization
	void Start () {
		bulletsFired = 0;
		burstTime = Time.time;

		newTarget = false;
	}

	void setTarget(GameObject nTarget){
		target = nTarget;
		newTarget = true;
	}

	// Update is called once per frame
	void Update () {
		if(target != null){
			if(newTarget){
				newTarget = false;
				burstTime = Time.time;
				transform.LookAt(target.transform.position);
			}
			
			if(Time.time - burstDelay > burstTime) {
				bulletsFired = 0;
				burstTime = Time.time;
			}
			
			if((bulletsFired < burstSize) && (Time.time - bulletDelay * bulletsFired > burstTime)){
				Rigidbody bulletFired = (Rigidbody) Instantiate(projectile, (transform.position) , transform.rotation);
				
				
				bulletFired.velocity = (target.transform.position - transform.position).normalized * fireSpeed;
				Destroy(bulletFired.gameObject, burstDelay * 2);
				bulletsFired++;
			}
		}
	}
}