using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballScript : MonoBehaviour {

    bool moving = false;
    Vector3 target;
    GameObject explosion;

	// Use this for initialization
	void Start () {
        this.explosion = Resources.Load("explosion") as GameObject;
        
    }

    void setTarget(Vector3 target)
    {
        this.target = target;
        this.moving = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.Equals(target))
        {
            this.moving = false;
            GameObject explosion = Instantiate(this.explosion) as GameObject;
            explosion.SendMessage("activate", this.target);
            Destroy(this.gameObject);
        }

        if (moving)
        {
            float step = Time.deltaTime * 5f;

            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }

    }
}
