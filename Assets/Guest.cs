using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Guest : MonoBehaviour
{
    public TextMeshPro satisfactionUI;
    public TextMeshPro favTracksUI;
    public TextMeshPro dislikedTracksUI;
    public float Satisfaction;
    public List<string> FavouriteTracks;
    public List<string> DislikedTracks;
    // Start is called before the first frame update

    void Start()
    {
        satisfactionUI = transform.Find("SatisfactionUI").GetComponent<TextMeshPro>();
        favTracksUI = transform.Find("FavTracksUI").GetComponent<TextMeshPro>();
        dislikedTracksUI = transform.Find("DislikedTracksUI").GetComponent<TextMeshPro>();

        favTracksUI.text = string.Join(" \n", FavouriteTracks.ToArray());
        dislikedTracksUI.text = string.Join(" \n", DislikedTracks.ToArray());
    }

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
