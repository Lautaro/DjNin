﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<string, float> ActiveTracks;
    public List<Guest> Guests;
    public float SatisfactionBoost;
    public float SatisfactionDamage;
    void Start() 
    {
        if (Guests == null)
        {
            Guests = new List<Guest>();
        }

        ActiveTracks = new Dictionary<string, float>();
        InvokeRepeating("SlowUpdate", 0, 1);
    }

    void SlowUpdate()
    {
        ActiveTracks = MusicManager.Instance.songySong.GetPlayingTracks();
    }



    // Update is called once per frame
    void Update()
    {
        foreach (var guest in Guests)
        {
            var favouriteTracks = guest.FavouriteTracks;
            var worstTracks = guest.WorstTracks;
            var satisfactionMod = 0f;
            foreach (var favTrack in favouriteTracks)
            {
                if (ActiveTracks.ContainsKey(favTrack))
                {
                    satisfactionMod += SatisfactionBoost;
                }
            }

            foreach (var favTrack in worstTracks)
            {
                if (ActiveTracks.ContainsKey(favTrack))
                {
                    satisfactionMod -= SatisfactionDamage;
                }
            }

            if (satisfactionMod <= 0)
            {
                satisfactionMod = -SatisfactionDamage;
            }

            guest.Satisfaction += satisfactionMod;

            guest.GetComponentInChildren<TextMeshPro>().text = guest.Satisfaction.ToString("N1");

            if (guest.Satisfaction >= 100)
            {
                guest.SatisfactionMax();
            }
            if (guest.Satisfaction <= 0)
            {
                guest.SatisfactionMin();
            }
        }
    }
}
