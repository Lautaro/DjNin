using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadSurface : MonoBehaviour
{
    public  Carriable PlacedObject;
    public float RotationSpeed;

    public Carriable Place(Carriable objectToPlace)
    {
        var returnObject = PlacedObject;
        PlacedObject = objectToPlace;
        PlacedObject.transform.position = transform.position;
        ResetRotationOfPlacedObject();
        if (objectToPlace != null)
        {
            var record = objectToPlace.GetComponent<Carriable>().CarriableName;
            MusicManager.Instance.songySong.SetClipVolume(1 ,record);
        }

        if (returnObject != null)
        {

            var record = returnObject.CarriableName;
            MusicManager.Instance.songySong.SetClipVolume(0, record);
        }
        return returnObject;
    }

    public Carriable Take()
    {
        var returnObject = PlacedObject;
        ResetRotationOfPlacedObject();
        PlacedObject = null;
        if (returnObject != null)
        {
            var record = returnObject.CarriableName;
            MusicManager.Instance.songySong.SetClipVolume(0, record);
        }
        return returnObject;
    }

    private void ResetRotationOfPlacedObject()
    {
        PlacedObject.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void Update()
    {
        if (PlacedObject)
        {
            PlacedObject.transform.eulerAngles += new Vector3(0, 0, RotationSpeed);
            
        }
    }

}
