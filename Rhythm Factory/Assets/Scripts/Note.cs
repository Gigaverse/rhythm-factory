using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
    private int type;
    private float millis, timeleft;
    // Use this for initialization
    void Start () {
	
	}
	
    public void init(float timeleft, int type)
    {
        this.timeleft = timeleft;
        this.type = type;
    }

	// Update is called once per frame
	void Update () {
        millis = Mathf.Abs(timeleft - GameObject.Find("NoteGenerator").GetComponent<Audio>().audio.time * 1000);
		gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 8.775f*Time.deltaTime, this.transform.position.z);

    }

    public float getmillis()
    {
        return millis;
    }

    public int gettype()
    {
        return type;
    }

    public void prune()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(gameObject.GetComponent<Renderer>().material.color.r, gameObject.GetComponent<Renderer>().material.color.g, gameObject.GetComponent<Renderer>().material.color.b, 0));

    }
}
