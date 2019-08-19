using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadSurface : MonoBehaviour
{
    public  Carriable PlacedObject;

    public Carriable Place(Carriable objectToPlace)
    {
        var returnObject = PlacedObject;
        PlacedObject = objectToPlace;
        PlacedObject.transform.position = transform.position;
        return returnObject;
    }
    
}
