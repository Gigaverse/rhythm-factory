using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class noteAccept : MonoBehaviour {

    public GameObject notePrefab;
    public List<GameObject> scorePrefabList = new List<GameObject>();
    public GameObject score300Prefab;
    public GameObject score100Prefab;
    public GameObject scoreMissPrefab;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
                
        if (Input.GetKeyDown(KeyCode.S))
        {
            score300Prefab = Instantiate(score300Prefab, new Vector3(-2, this.transform.position.y), transform.rotation) as GameObject;            
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Destroy(score300Prefab, 0);
        }



        if (Input.GetKeyDown(KeyCode.D))
        {

        }
        if (Input.GetKeyUp(KeyCode.D))
        {

        }

        if (Input.GetKeyDown(KeyCode.F))
        {

        }
        if (Input.GetKeyUp(KeyCode.F))
        {

        }

        if (Input.GetKeyDown(KeyCode.J))
        {

        }
        if (Input.GetKeyUp(KeyCode.J))
        {

        }

        if (Input.GetKeyDown(KeyCode.K))
        {

        }
        if (Input.GetKeyUp(KeyCode.K))
        {

        }

        if (Input.GetKeyDown(KeyCode.L))
        {

        }
        if (Input.GetKeyUp(KeyCode.L))
        {

        }
    }
}
