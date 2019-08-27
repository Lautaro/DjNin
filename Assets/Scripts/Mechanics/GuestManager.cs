using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        InvokeRepeating("SlowUpdate", 0, 0.3f);
    }

    void SlowUpdate()
    {
        ActiveTracks = MusicManager.Instance.songySong.GetPlayingTracks();
       
    }

    void SpawnNewGuests(int amount)
    {
        var parentTransform = transform.root.Find("/Game/Guests").transform;
        var newGuests = guestSpawner.SpawnGuests(2, parentTransform);
    }

    void AddGuests(List<Guest> guests)
    {
        Guests.AddRange(guests);
    }



    // Update is called once per frame
    void Update()
    {
        foreach (var guest in Guests)
        {
            var favouriteTracks = guest.FavouriteTracks;
            var worstTracks = guest.DislikedTracks;
            var satisfactionMod = 0f;

            var activeFavTracks = new List<string>();
            var activeWorstTracks = new List<string>();

            // Save all active fav track and add satisfaction
            foreach (var favTrack in favouriteTracks)
            {
                if (ActiveTracks.ContainsKey(favTrack))
                {
                    satisfactionMod += SatisfactionBoost;
                    activeFavTracks.Add(favTrack);
                }
            }

            // Save all active worst track and reduce satisfaction
            foreach (var worstTrack in worstTracks)
            {
                if (ActiveTracks.ContainsKey(worstTrack))
                {
                    satisfactionMod -= SatisfactionDamage;
                    activeWorstTracks.Add(worstTrack);
                }
            }

            // IF SATISFACTION MOD IS NOT POSITIVE IT SHOULDBE NEGATIVE
            if (satisfactionMod <= 0)
            {
                satisfactionMod = -SatisfactionDamage;
            }

            // APPLY SATISFACTION MOD
            guest.Satisfaction += satisfactionMod;

            // UPDATE GUEST UI WITH CURRENT ACTIVE TRACKS AND SATISFACTION
            guest.favTracksUI.text = activeFavTracks.Aggregate("", (current, next) => current + "\n " + next);
            guest.dislikedTracksUI.text = activeWorstTracks.Aggregate("", (current, next) => current + "\n " + next);
            guest.satisfactionUI.text = guest.Satisfaction.ToString("N0");

            // SET SATISFACTION UI COLOR BY SATISFACTION MOD
            if (satisfactionMod >= 0)
            {
                guest.satisfactionUI.color = Color.green;
            }
            else
            {
                guest.satisfactionUI.color = Color.red;
            }

            // CHECK IF FAIL OR SUCCESS
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
