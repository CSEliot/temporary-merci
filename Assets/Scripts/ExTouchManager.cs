using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ExTouch
{
  public class ExTouchManager : MonoBehaviour
  {

    protected GameObject touchedObject;

    private Dictionary<int, ExGestureObject> gestures;
    private Dictionary<int, GameObject> boundObjects;
    private List<ExGestureObject> remove;

    // Use this for initialization
    void Start()
    {
      gestures = new Dictionary<int, ExGestureObject>();
      boundObjects = new Dictionary<int, GameObject>();
      remove = new List<ExGestureObject>();

      Input.multiTouchEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
      remove.Clear();
      int touches = Input.touchCount;
      for ( int i = 0; i < touches; i++ )
      {
        Touch touch = Input.GetTouch( i );
        ConvertToExGestureObject( touch );
      }

      ConvertMouseToExGestureObject();

      foreach ( ExGestureObject g in gestures.Values )
      {
        if ( g != null )
        {
          boundObjects.TryGetValue( g.Id, out touchedObject );
          if ( touchedObject != null )
          {
            ExTouchObject touchObj = touchedObject.GetComponent<ExTouchObject>();
            if ( touchObj != null )
            {
              if ( g.GameGesture == ExGestureObject.GameGestureType.Tap )
              {
                touchObj.OnTap( g );
              }
              else if ( g.GameGesture == ExGestureObject.GameGestureType.Pull )
              {
                touchObj.OnPull( g );
              }
              else if ( g.GameGesture == ExGestureObject.GameGestureType.Drag )
              {
                touchObj.OnDrag( g );
              }
              else if ( g.GameGesture == ExGestureObject.GameGestureType.Hold )
              {
                touchObj.OnHold( g );
              }
              else if ( g.GameGesture == ExGestureObject.GameGestureType.Pinch )
              {
                touchObj.OnPinch( g );
              }
            }
          }
          else
          {
            Ray ray = Camera.main.ScreenPointToRay( g.ScreenEnd );
            var hits = Physics.RaycastAll( ray, 100.0f );
            foreach ( RaycastHit hit in hits )
            {
              touchedObject = hit.transform.gameObject;
              ExTouchObject touchObj = touchedObject.GetComponent<ExTouchObject>();
              if ( touchObj != null )
              {
                bool actionPerformed = false;
                if ( g.GameGesture == ExGestureObject.GameGestureType.Tap )
                {
                  actionPerformed = touchObj.OnTap( g );
                }
                else if ( g.GameGesture == ExGestureObject.GameGestureType.Pull )
                {
                  actionPerformed = touchObj.OnPull( g );
                }
                else if ( g.GameGesture == ExGestureObject.GameGestureType.Drag )
                {
                  actionPerformed = touchObj.OnDrag( g );
                  if ( actionPerformed ) boundObjects.Add( g.Id, touchedObject );
                }
                else if ( g.GameGesture == ExGestureObject.GameGestureType.Hold )
                {
                  actionPerformed = touchObj.OnHold( g );
                  if ( actionPerformed ) boundObjects.Add( g.Id, touchedObject );
                }
                else if ( g.GameGesture == ExGestureObject.GameGestureType.Pinch )
                {
                  actionPerformed = touchObj.OnPinch( g );
                }
                if ( actionPerformed )
                  break;
              }
            }
          }
          if ( g.GameGesture == ExGestureObject.GameGestureType.Tap )
          {
            remove.Add( g );
          }
          else if ( g.GameGesture == ExGestureObject.GameGestureType.Pull )
          {
            remove.Add( g );
          }
          else if ( g.GameGesture == ExGestureObject.GameGestureType.Pinch )
          {
            remove.Add( g );
          }
        }
      }

      foreach ( ExGestureObject g in remove )
      {
        gestures.Remove( g.Id );
        boundObjects.Remove( g.Id );
      }
    }

    protected ExGestureObject ConvertToExGestureObject( Touch t )
    {
      if ( t.phase == TouchPhase.Began )
      {
        Vector3 worldStartPosition = Camera.main.ScreenToWorldPoint( t.position );
        ExGestureObject g = new ExGestureObject();
        g.Initialize( ExGestureObject.GameGestureType.Down, worldStartPosition, worldStartPosition, t.position, t.position, Time.time, t.fingerId );
        gestures.Add( g.Id, g );
        return g;
      }
      else
      {
        ExGestureObject g;
        gestures.TryGetValue( t.fingerId, out g );

        Vector3 worldEndPosition = Camera.main.ScreenToWorldPoint( t.position );
        if ( g != null )
        {
          if ( t.phase == TouchPhase.Ended )
          {
            if ( g.GameGesture == ExGestureObject.GameGestureType.Down || g.GameGesture == ExGestureObject.GameGestureType.Hold
            || g.GameGesture == ExGestureObject.GameGestureType.None )
            {
              g.GameGesture = ExGestureObject.GameGestureType.Tap;
            }
            else if ( g.GameGesture == ExGestureObject.GameGestureType.Drag )
            {
              g.GameGesture = ExGestureObject.GameGestureType.Pull;
              g.EndPosition = worldEndPosition;
              g.ScreenEnd = t.position;
            }
          }
          else if ( t.phase == TouchPhase.Moved )
          {
            if ( g.GameGesture == ExGestureObject.GameGestureType.Down ||
                g.GameGesture == ExGestureObject.GameGestureType.Drag ||
                g.GameGesture == ExGestureObject.GameGestureType.None )
            {
              g.GameGesture = ExGestureObject.GameGestureType.Drag;
              g.EndPosition = worldEndPosition;
              g.ScreenEnd = t.position;
            }
          }
          else if ( t.phase == TouchPhase.Stationary )
          {
            if ( g.GameGesture == ExGestureObject.GameGestureType.Down ||
                g.GameGesture == ExGestureObject.GameGestureType.None )
            {
              if ( Time.time - g.StartTime > 2 )
              {
                g.GameGesture = ExGestureObject.GameGestureType.Hold;
              }
              else
              {
                g.GameGesture = ExGestureObject.GameGestureType.Down;
              }
              g.EndPosition = worldEndPosition;
              g.ScreenEnd = t.position;
            }
          }
        }
        else
        {
          g = new ExGestureObject();
          g.Initialize( ExGestureObject.GameGestureType.None, worldEndPosition, worldEndPosition, t.position, t.position, Time.time, t.fingerId );
          gestures.Add( g.Id, g );
        }

        return g;
      }

    }

    private void ConvertMouseToExGestureObject()
    {
      ExGestureObject mouseGesture;
      try
      {
        gestures.TryGetValue( -1, out mouseGesture );

        if ( Input.GetMouseButton( 1 ) )
        {
          Vector3 worldStartPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
          mouseGesture = new ExGestureObject();
          mouseGesture.Initialize( ExGestureObject.GameGestureType.Pinch, worldStartPosition, worldStartPosition, Input.mousePosition, Input.mousePosition, Time.time, -1 );
          gestures.Add( mouseGesture.Id, mouseGesture );
        }
        else if ( Input.GetMouseButton( 0 ) )
        {
          Vector3 worldEndPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
          if ( mouseGesture == null )
          {
            mouseGesture = new ExGestureObject();
            mouseGesture.Initialize( ExGestureObject.GameGestureType.Down, worldEndPosition, worldEndPosition, Input.mousePosition, Input.mousePosition, Time.time, -1 );
            gestures.Add( mouseGesture.Id, mouseGesture );
          }
          else
          {
            if ( !worldEndPosition.Equals( mouseGesture.StartPosition ) )
            {
              mouseGesture.GameGesture = ExGestureObject.GameGestureType.Drag;
            }
            else
            {
              if ( Time.time - mouseGesture.StartTime > 2 )
              {
                mouseGesture.GameGesture = ExGestureObject.GameGestureType.Hold;
              }
              else
              {
                mouseGesture.GameGesture = ExGestureObject.GameGestureType.Down;
              }
            }
            mouseGesture.EndPosition = worldEndPosition;
            mouseGesture.ScreenEnd = Input.mousePosition;
          }
        }
        else if ( Input.GetMouseButtonUp( 0 ) )
        {
          Vector3 worldEndPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
          if ( mouseGesture.GameGesture == ExGestureObject.GameGestureType.Drag )
          {
            mouseGesture.GameGesture = ExGestureObject.GameGestureType.Pull;
            mouseGesture.EndPosition = worldEndPosition;
            mouseGesture.ScreenEnd = Input.mousePosition;
          }
          else if ( mouseGesture.GameGesture == ExGestureObject.GameGestureType.Down
                || mouseGesture.GameGesture == ExGestureObject.GameGestureType.Hold )
          {
            mouseGesture.GameGesture = ExGestureObject.GameGestureType.Tap;
            mouseGesture.EndPosition = worldEndPosition;
            mouseGesture.ScreenEnd = Input.mousePosition;
          }
        }
      }
      catch
      {
        mouseGesture = null;
      }
    }
  }
}
