using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    Rigidbody rg;
    float speed;
	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody>();
        speed = 5f;
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update () {
        float h, v;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        Move(h, v);

    }

    void Move(float x, float z)
    {
        rg.MovePosition(transform.position + new Vector3(x, 0, z).normalized * Time.deltaTime*speed);
    }
}
