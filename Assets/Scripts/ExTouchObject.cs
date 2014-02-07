using UnityEngine;
using System.Collections;

namespace ExTouch
{
    public class ExTouchObject : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public virtual bool OnTap(ExGestureObject g)
        {
            return false;
        }

        public virtual bool OnDrag(ExGestureObject g)
        {
            return false;
        }

        public virtual bool OnPull(ExGestureObject g)
        {
            return false;
        }

        public virtual bool OnHold(ExGestureObject g)
        {
            return false;
        }

        public virtual bool OnDown(ExGestureObject g)
        {
            return false;
        }

        public virtual bool OnPinch(ExGestureObject g)
        {
            return false;
        }
    }
}
