using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour {
    Rigidbody rg;
    float speed;
    
    // Use this for initialization
    void Start()
    {
        
        rg = GetComponent<Rigidbody>();
        speed = 5f;
        
        
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h, v;
        h = Input.GetAxisRaw("Vertical");
        v = -Input.GetAxisRaw("Horizontal");
        Move(h, v);
       
    }

    void Move(float x, float z)
    {
        rg.MovePosition(transform.position + new Vector3(x, 0, z).normalized * Time.deltaTime * speed);
    }

    public void SetCube(GameObject go)
    {
        Renderer rend;
        rend = go.GetComponent<Renderer>();
        if (Input.GetButtonUp("Fire1"))
        {
            if (rend.material.color == new Color(0, 0, 0, 0))
            {
                rend.material.color = new Color(1, 1, 1, 0);
            }
            else if(rend.material.color == new Color(1, 1, 1, 0))
            {
                rend.material.color = new Color(0, 0, 0, 0);
            }
           
        }
    }
}
