using UnityEngine;
using System.Collections;

public class HumanTargeted : MonoBehaviour {

    public int H_istargeted;

    void Start()
    {
        H_istargeted = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Increasetargeted()
    {
        H_istargeted += 1;
    }

}