using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{

    public AudioClip[] stings;
	public float millis = 0;
    public AudioSource stingSource;
    public float bpm = 139;
    public bool play = false, start = false;
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
			audio.Play();
			start = true;
        }
		if ((int)(audio.time*1000) != (int)millis) {
			GameObject.Find ("NoteGenerator").GetComponent<noteGeneration> ().time = (GameObject.Find ("NoteGenerator").GetComponent<noteGeneration> ().time + audio.time*1000) / 2;
		}
		millis = audio.time;
    }

}