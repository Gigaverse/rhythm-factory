using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {
	Color[] Colors = { new Color (53.0f/256, 82.0f/256, 74.0f/256), new Color (181.0f/256,146.0f/256,160.0f/256), new Color (16.0f/256, 46.0f/256, 74.0f/256), new Color (175.0f/256, 59.0f/256, 110.0f/256)};
	Color c;
	float[] bounds = new float[6];
	// Use this for initialization
	void Start () {
		c = Colors[(int)(Random.value*4)];
		bounds [0] = c.r - (30.0f/256);
		bounds [1] = c.r + (30.0f/256);
		bounds [2] = c.g - (30.0f/256);
		bounds [3] = c.g + (30.0f/256);
		bounds [4] = c.b - (30.0f/256);
		bounds [5] = c.b + (30.0f/256);
	}
	
	// Update is called once per frame
	void Update () {
		c.r = Mathf.Max(bounds[0], Mathf.Min(bounds[1],c.r + Random.value*(2.0f / 256) - (1.0f / 256)));
		c.g = Mathf.Max(bounds[2], Mathf.Min(bounds[3],c.g + Random.value*(2.0f / 256) - (1.0f / 256)));
		c.b = Mathf.Max(bounds[4], Mathf.Min(bounds[5],c.b + Random.value*(2.0f / 256) - (1.0f / 256)));
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", c);
	}
}
