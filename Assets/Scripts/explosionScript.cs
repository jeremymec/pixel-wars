using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}

    void activate(Vector3 pos)
    {
        this.transform.position = new Vector3(pos.x, pos.y, 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
