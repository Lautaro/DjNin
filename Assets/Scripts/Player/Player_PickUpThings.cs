using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PickUpThings : MonoBehaviour
{
    public List<GameObject> InReach;
    public GameObject Carrying;
    public List<UnloadSurface> SurfaceInReach;
    GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        SurfaceInReach = new List<UnloadSurface> ();
        InReach = new List<GameObject> ();
    }

    void OnCollisionEnter2D( Collision2D col )
    {


    }

    void OnTriggerEnter2D( Collider2D col )
    {
        if ( col.gameObject.GetComponent<Carriable>() != null )
        {
            InReach.Add ( col.gameObject );
            Debug.Log ( "OnTriggerEnter2D: " + col.gameObject.name );
        }

        if ( col.gameObject.GetComponent<UnloadSurface> () != null )
        {
         //   SurfacesInReach.Add ( col.gameObject );
            Debug.Log ( "OnTriggerEnter2D: " + col.gameObject.name );
        }

    }
    void OnTriggerExit2D( Collider2D col )
    {   
            InReach.Remove ( col.gameObject );
            Debug.Log ( "OnTriggerExit2D: " + col.gameObject.name );
    }

    public void OnPlayerMoving(object facesLeft)
    {
        if ( Carrying != null )
        {
            var direction = ( bool )facesLeft == true ? -0.5f: 0.5f;
            Carrying.transform.position = transform.position + new Vector3 ( direction, 0 );
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.anyKeyDown )
        {
            if ( Input.GetKeyDown ( KeyCode.Space ) )
            {
                if ( Carrying != null )
                {
                    Carrying = null;
                }
                else if(InReach.Count > 0)
                {
                    Carrying = InReach[0];
                }
            }
        }
    }
}
