using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class noteGeneration : MonoBehaviour {
    public GameObject noteSkin;
    public static long score=0;
    public GUIText scoreDisplay;
    List<GameObject> notes = new List<GameObject>();
    List<int[]> songData = new List<int[]>();
    int num;
    public float time;
    KeyCode[] keys = { KeyCode.S, KeyCode.D , KeyCode.F, KeyCode.J , KeyCode.K , KeyCode.L };

    // Use this for initialization
    void Start () {
        scoreDisplay.text = "Score";
        try
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/Songs/rolling.rff"))
            {
                while (sr.Peek() >= 0)
                {
                    string[] data = sr.ReadLine().Split(' ');
                    int[] tempArr = new int[3];
                    for (int i = 0; i < 3; i++)
                        tempArr[i] = Int32.Parse(data[i]);
                    songData.Add(tempArr);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        time = 0;
        num = songData.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < 5.2) return;
        time += Time.deltaTime * 1000;
        scoreDisplay.text = score + "";

        for(int j = notes.Count - 1; j >= 0; j--)
        {
            if(notes[j] == null)
            {
                notes.Remove(notes[j]);
                continue;
            }
            GameObject g = notes[j];
            float millis = g.GetComponent<Note>().getmillis();
            if (g.GetComponent<Note>().getmillis() < 150)
            {
                int type = g.GetComponent<Note>().gettype();
                Debug.Log(type);
                if (Input.GetKeyDown(keys[type-1]))
                {
                    int test = millis > 0 && millis < 100 ? (2 - (int)(millis / 50)) : 0;
                    if (test != 0)
                    {
                        g.GetComponent<Note>().prune();
                    }
                    GameObject.Find("noteBar").GetComponent<noteAccept>().splash(type-1, test);
                    score += test * 150;
                }
            }
        }

        int i;
        for (i = 0; i < songData.Count; i++)
        {
            //Debug.Log(time);
            if (songData[i][2] - time < 2000)
            {
                //Debug.Log(songData[i][1]);
                //Note note = GetComponent<Note>();
                GameObject n = Instantiate(noteSkin, new Vector3(-4f - (10f / 6f) + (songData[i][1] * (10f/6f)), this.transform.position.y +25f, this.transform.position.z), transform.rotation) as GameObject;
                n.GetComponent<Note>().init(songData[i][2], songData[i][1]);
                notes.Add(n);
                Destroy(n, (songData[i][2] - time) / 500f);


            }
            else
            {

                break;
            }
        }
        i--;
        for (; i >= 0; i--)
        { songData.Remove(songData[i]); }
    }
}
