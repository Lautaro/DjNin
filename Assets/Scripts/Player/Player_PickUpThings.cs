using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PickUpThings : MonoBehaviour
{
    public List<GameObject> RecordsInReach;
    public GameObject Carrying;
    public List<UnloadSurface> SurfaceInReach;
    GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        SurfaceInReach = new List<UnloadSurface>();
        RecordsInReach = new List<GameObject>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var carriable = col.gameObject.GetComponent<Carriable>();
        var surfaceInReach = col.gameObject.GetComponent<UnloadSurface>();
        if (carriable != null)
        {
            RecordsInReach.Add(col.gameObject);
        }

        if (surfaceInReach != null)
        {
            SurfaceInReach.Add(surfaceInReach);
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        var carriable = col.gameObject.GetComponent<Carriable>();
        var surfaceInReach = col.gameObject.GetComponent<UnloadSurface>();
        if (carriable != null)
        {
            RecordsInReach.Remove(col.gameObject);
        }

        if (surfaceInReach != null)
        {
            SurfaceInReach.Remove(surfaceInReach);
        }
    }

    public void OnPlayerMoving(object facesLeft)
    {
        if (Carrying != null)
        {
            var direction = (bool)facesLeft == true ? -0.5f : 0.5f;
            Carrying.transform.position = transform.position + new Vector3(direction, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Carrying != null)
                {
                    if (SurfaceInReach.Count > 0)
                    {
                        var surface = SurfaceInReach[0];
                        var carriable = Carrying.GetComponent<Carriable>();
                        var returnObject = surface.Place(carriable);
                        if (returnObject != null)
                        {
                            Carrying = returnObject.gameObject;
                        }
                        else
                        {
                            Carrying = null;
                        }
                    }
                    else
                    {
                        Carrying = null;
                    }

                }
                else if (RecordsInReach.Count > 0 || SurfaceInReach.Count > 0)
                {
                    if (SurfaceInReach.Count > 0 && SurfaceInReach[0].PlacedObject != null)
                    {
                        var surface = SurfaceInReach[0];
                        Carrying = surface.Take().gameObject;

                    }
                    else if (RecordsInReach.Count > 0)
                    {
                        Carrying = RecordsInReach[0];
                    }
                }
            }
        }
    }
}
