using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class noteAccept : MonoBehaviour {

    private GameObject scorePrefab;
    private GameObject[] noteAcceptPrefabList;
    public GameObject noteAcceptPrefab;
    public GameObject score300Prefab;
    public GameObject score100Prefab;
    public GameObject scoreMissPrefab;
    



    // Use this for initialization
    void Start () {
        noteAcceptPrefabList = new GameObject[6];
        noteAcceptPrefabList[0] = Instantiate(noteAcceptPrefab, new Vector3(-4f + (0 * (10f / 6f)), -4.55f, this.transform.position.z), transform.rotation) as GameObject;
        noteAcceptPrefabList[1] = Instantiate(noteAcceptPrefab, new Vector3(-4f + (1 * (10f / 6f)), -4.55f, this.transform.position.z), transform.rotation) as GameObject;
        noteAcceptPrefabList[2] = Instantiate(noteAcceptPrefab, new Vector3(-4f + (2 * (10f / 6f)), -4.55f, this.transform.position.z), transform.rotation) as GameObject;
        noteAcceptPrefabList[3] = Instantiate(noteAcceptPrefab, new Vector3(-4f + (3 * (10f / 6f)), -4.55f, this.transform.position.z), transform.rotation) as GameObject;
        noteAcceptPrefabList[4] = Instantiate(noteAcceptPrefab, new Vector3(-4f + (4 * (10f / 6f)), -4.55f, this.transform.position.z), transform.rotation) as GameObject;
        noteAcceptPrefabList[5] = Instantiate(noteAcceptPrefab, new Vector3(-4f + (5 * (10f / 6f)), -4.55f, this.transform.position.z), transform.rotation) as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
                
      
    }

    public void splash(int key, int type)
    {
        if (type == 1)
            scorePrefab = Instantiate(score100Prefab, new Vector3(-4f + (key * (10f / 6f)), -4.55f, this.transform.position.z), transform.rotation) as GameObject;
        else if (type == 2)
            scorePrefab = Instantiate(score300Prefab, new Vector3(-4f + (key * (10f / 6f)), -4.55f, this.transform.position.z), transform.rotation) as GameObject;
        else
            scorePrefab = Instantiate(scoreMissPrefab, new Vector3(-4f + (key * (10f / 6f)), -4.55f, this.transform.position.z), transform.rotation) as GameObject;
        Destroy(scorePrefab, 0.5f);
    }
}
