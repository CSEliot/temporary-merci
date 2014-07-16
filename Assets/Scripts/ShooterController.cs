    using UnityEngine;
using System.Collections;

public class ShooterController : MonoBehaviour {
	public Rigidbody projectile;
	public GameObject target;
	public float burstDelay = 0.5f, bulletDelay = 0.1f, burstTime, fireSpeed = 200.0f;
	public int burstSize = 3, bulletsFired;
	public bool newTarget;
	// Use this for initialization
	void Start () {
		bulletsFired = 0;
		burstTime = Time.time;

		newTarget = false;
	}

	public void setTarget(GameObject nTarget){
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
