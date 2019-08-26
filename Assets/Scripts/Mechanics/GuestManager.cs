using System.Collections;
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
    SpawnGuest guestSpawner;

    void Start() 
    {
        guestSpawner = new SpawnGuest();

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
        var parentTransform = transform.root.Find("/Game/Guests").transform;
        var newGuests = guestSpawner.SpawnGuests(2,parentTransform);
    }



    // Update is called once per frame
    void Update()
    {
        foreach (var guest in Guests)
        {
            var favouriteTracks = guest.FavouriteTracks;
            var worstTracks = guest.DislikedTracks;
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

            guest.satisfactionUI.text = guest.Satisfaction.ToString("N1");
            if (satisfactionMod >= 0)
            {
                guest.satisfactionUI.color = Color.green;
            }
            else
            {
                guest.satisfactionUI.color = Color.red;
            }


            if (guest.Satisfaction >= 100)
            {
                guest.OnSatisfiedSuccess();
            }
            if (guest.Satisfaction <= 0)
            {
                guest.OnSatisfiedFail();
            }
        }
    }
}
