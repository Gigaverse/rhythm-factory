using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class noteAccept : MonoBehaviour {

    private GameObject[] scorePrefabList;
    public GameObject score300Prefab;
    public GameObject score100Prefab;
    public GameObject scoreMissPrefab;



    // Use this for initialization
    void Start () {
        scorePrefabList = new GameObject[6];
    }
	
	// Update is called once per frame
	void Update () {
                
        if (Input.GetKeyDown(KeyCode.S))
        {

            noteScore sPress = GetComponent<noteScore>();
            scorePrefabList[0] = Instantiate(score300Prefab, new Vector3(-1, this.transform.position.y, this.transform.position.z), transform.rotation) as GameObject;
            Destroy(scorePrefabList[0], 0.5f);
        }



        if (Input.GetKeyDown(KeyCode.D))
        {
            noteScore dPress = GetComponent<noteScore>();
            scorePrefabList[1] = Instantiate(score300Prefab, new Vector3(-2, this.transform.position.y, this.transform.position.z), transform.rotation) as GameObject;
            Destroy(scorePrefabList[1], 0.5f);

        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            noteScore fPress = GetComponent<noteScore>();
            scorePrefabList[2] = Instantiate(score300Prefab, new Vector3(-2, this.transform.position.y, this.transform.position.z), transform.rotation) as GameObject;
            Destroy(scorePrefabList[2], 0.5f);
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            noteScore jPress = GetComponent<noteScore>();
            scorePrefabList[3] = Instantiate(score300Prefab, new Vector3(-2, this.transform.position.y, this.transform.position.z), transform.rotation) as GameObject;
            Destroy(scorePrefabList[3], 0.5f);
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            noteScore kPress = GetComponent<noteScore>();
            scorePrefabList[4] = Instantiate(score300Prefab, new Vector3(-2, this.transform.position.y, this.transform.position.z), transform.rotation) as GameObject;
            Destroy(scorePrefabList[4], 0.5f);
        }


        if (Input.GetKeyDown(KeyCode.L))
        {
            noteScore lPress = GetComponent<noteScore>();
            scorePrefabList[5] = Instantiate(score300Prefab, new Vector3(-2, this.transform.position.y, this.transform.position.z), transform.rotation) as GameObject;
            Destroy(scorePrefabList[5], 0.5f);
        }
    }
}
