using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class noteGeneration : MonoBehaviour {

    public GameObject noteSkin;
    List<int[]> songData = new List<int[]>();
    int num;
    float time;

    // Use this for initialization
    void Start () {
        try
        {
            using (StreamReader sr = new StreamReader("D:\\Files\\Code Related\\rhythm-factory\\Rhythm Factory\\Assets\\Songs\\test.rff"))
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
        time += Time.deltaTime * 1000;
        int i;
        for (i = 0; i < songData.Count; i++)
        {
            //Debug.Log(time);
            if (songData[i][2] - time < 1000)
            {
                Debug.Log(songData[i][2]);
                Note note = GetComponent<Note>();
                GameObject n = Instantiate(noteSkin, new Vector3(-4 + (songData[i][1]*(10/6)), this.transform.position.y, 0), transform.rotation) as GameObject;
                Destroy(n, (songData[i][2] - time) / 1000f);


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
