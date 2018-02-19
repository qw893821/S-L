using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCube : MonoBehaviour {
    GameObject player;
    bool enter;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        enter = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (enter)
        {
            player.GetComponent<Movement2>().SetCube(transform.gameObject);
        }
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            
            enter = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            enter = false;
        }
    }
}
