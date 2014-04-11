using UnityEngine;
using System.Collections;

public class HumanTargeted : MonoBehaviour {

    public int H_istargeted;

    //It starts off untargeted.
    void Start()
    {
        H_istargeted = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //It increases targeted.
    public void Increasetargeted()
    {
        H_istargeted += 1;
    }

}