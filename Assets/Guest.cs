using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    public float Satisfaction;
    public List<string> FavouriteTracks;
    public List<string> WorstTracks;
    // Start is called before the first frame update
    public void SatisfactionMax()
    {
        print(name + " is SATISFIED");
        this.gameObject.SetActive(false);
    }

    public void SatisfactionMin()
    {
        print(name + " is ANGRY");
        this.gameObject.SetActive(false);

    }
}
