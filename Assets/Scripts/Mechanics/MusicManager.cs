﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public SongySong songySong;

    public Transform Player;
    public Transform BasicBeat;
    public Transform Bass;
    public Transform Chords;
    public Transform Pads;
    public Transform Arrpegio;
    public Transform ExtraBeat;
    public static MusicManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        songySong = GetComponent<SongySong>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new System.Exception("Only one music manager allowed");
        }
        
        songySong.SetLoop("BasicBeat", "Bass", "Chords", "Pads", "Arrpegio", "ExtraBeat");

        //songySong.TrackingObject = Player;
        //songySong.SetTrackingObjectOnClip("BasicBeat", BasicBeat);
        //songySong.SetTrackingObjectOnClip("Bass", Bass);
        //songySong.SetTrackingObjectOnClip("Chords", Chords);
        //songySong.SetTrackingObjectOnClip("Pads", Pads);
        //songySong.SetTrackingObjectOnClip("Arrpegio", Arrpegio);
        //songySong.SetTrackingObjectOnClip("ExtraBeat", ExtraBeat);
        songySong.SetMainVolume(0);
        songySong.PlaySongySong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}