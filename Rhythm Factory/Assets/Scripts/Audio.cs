using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{

    public AudioClip[] stings;
    public AudioSource stingSource;
    public float bpm = 139;
    bool play = false, start = false;
    public AudioSource audio;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameObject.Find("NoteGenerator").GetComponent<noteGeneration>().time >= 5.2 && !play)
        {
            play = true;
            Debug.Log("HERE WE GO");
        }
        if (play && !start)
        {
            audio.Play();
            start = true;
        }
    }

}