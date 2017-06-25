using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    enum States { NORMAL, IMMOBILE }

    States state = States.NORMAL;
    float speed = 1.2f;
    GameObject fireball;

	// Use this for initialization
	void Start () {
        fireball = Resources.Load("fireball") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

        if (state == 0)
        {
            // Movement Logic
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }


        // Casting Fireball
        if (Input.GetKeyDown(KeyCode.F)){
            StartCoroutine("castFireball");
        }

    }

    IEnumerator castFireball()
    {
        this.state = States.IMMOBILE;
        GameObject fireball = Instantiate(this.fireball) as GameObject;
        Physics2D.IgnoreLayerCollision(8, 9);

        fireball.transform.position = transform.position;
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos.ToString());

        Vector3 initialMove = fireball.transform.rotation * new Vector3(0.1f, 0.1f, 0);
        fireball.transform.position += 5f * initialMove;

        Vector3 deltaToTarget = mousePos - fireball.transform.position;
        float angle = (Mathf.Atan2(deltaToTarget.y, deltaToTarget.x) * Mathf.Rad2Deg) - 180;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        fireball.transform.rotation = Quaternion.Slerp(fireball.transform.rotation, q, 2f);

        yield return new WaitForSeconds(1f);

        fireball.SendMessage("setTarget", mousePos);
        this.state = States.NORMAL;
    }


}
