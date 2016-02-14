using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class noteGeneration : MonoBehaviour {

    List<int[]> songData = new List<int[]>();    

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

        foreach(int[] a in songData)
        {
            Debug.Log(a[2]);
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
