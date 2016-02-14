using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	


	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - .05f, this.transform.position.z);
	}
}
