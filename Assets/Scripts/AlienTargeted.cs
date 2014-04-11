using UnityEngine;
using System.Collections;

public class AlienTargeted : MonoBehaviour
{
    public int A_istargeted;

    // Use this for initialization
    void Start()
    {
        A_istargeted = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Increasetargeted()
    {
        A_istargeted += 1;
    }

}