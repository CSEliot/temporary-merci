using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthBar : MonoBehaviour
{
    private float maxHealth;
    private float currHealth;
    private float damagePerSecond;
    private float damageDamper;
    private bool isDown;
    private float targetCount;
    private Animator animator;
    private float lifeFrac;
    private float size;
    //private List<Transform> soldier;
    private int damageSpeed;

    void Start()
    {
        //allows getScript to use ListingHumes_Aliens methods
        //ListingHumes_Aliens getScript = GameObject.Find("List_creator").GetComponent<ListingHumes_Aliens>();

        //GameObject.Find("Green").transform.localScale.Set(0f, 0f, 0f);

        //initialize variables
        damagePerSecond = .001f; // when under fire
        damageDamper = 0.4f;//1.00f;
        isDown = false;
        size = 1.1f; //referes to the Green child plane.
        maxHealth = size; // bar size, this never changes
        currHealth = size; //transform bar size
        Debug.Log("Parent name of this health bar is: " + transform.parent.name);

        //see who is being targetted and set the target size
        setTargetCount();
        
        //Debug.Log("Size after if statement =" + size);
     //Don't need to do this, we know what it starts at and can set it manually.
        //size = GameObject.Find("Green").transform.localScale.x;
        //Debug.Log("Size after assigned=" + size);
        animator = transform.parent.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isDead();
        //Debug.Log("OH HEY CALLED I AM");
        //if target, set true
        if (targetCount >= 1)
        {
            //decrease health
            currHealth -= (damagePerSecond * targetCount)*damageDamper;

            //size -= (.1f * targetCount);
            //Debug.Log("My health is: " + currHealth);
           // Debug.Log(this.transform.GetChild(0).name);
            this.transform.GetChild(0).GetChild(0).transform.localScale -= new Vector3((damagePerSecond * targetCount)*damageDamper, 0f, 0f);

        }
        else
        {
            //in the future, the target will change, this targetCount will change, so we have 
            //to check for this.
            setTargetCount();
        }


        //if health = 50;
        if (currHealth <= maxHealth/2f)
        {
            //Debug.Log("OH JEEZ I AM DOWN");
            isDown = true;
            animator.SetBool("isDown", true);
            //set isDown to true
        }
    }

    void Recovery()
    {
        //if amputated then
        //health = 90;
        //else
        //health = 100;
        //getRecovered=ture
    }

    //returns true if soldier is healed
    bool isHeal()
    {
        //return getRecovered;
        return false;
    }

    //returns true if soldier is down
    public bool getIsDown()
    {
        return isDown;
    }

    //returns true if soldier is dead
    public bool isDead()
    {
        if (currHealth <= 0.001)
        {
            if (transform.parent.name.Equals("soldier_v2"))
            {
                animator.SetBool("isDead", true);
                Application.LoadLevel(2);
                Debug.Log("OH CRAP I DIED");
                Destroy(this.gameObject);
                Invoke("loseScene", 2);
                return true;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    void loseScene()
    {
        Application.LoadLevel(2);
        Debug.Log("OH CRAP I DIED");
        Destroy(this.gameObject);
    }

    private void setTargetCount()
    {
        if (transform.parent.name.Equals("soldier_v2"))
        {

            targetCount = transform.parent.gameObject.GetComponent<HumanTargeted>().H_istargeted;
            Debug.Log("Target after assigned=" + targetCount);

            //Not sure what this is for other than for debugging.
            //soldier = getScript.getAlienRegiment();
            //Debug.Log("Regiment =" + soldier.Count);

        }
        else if (transform.parent.name.Equals("TempAlien"))
        {
            targetCount = transform.parent.gameObject.GetComponent<AlienTargeted>().A_istargeted;

            //soldier = getScript.getSoldierRegiment();

        }

    }


}
