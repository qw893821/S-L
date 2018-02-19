using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour {
    public GameObject door;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Check());
        if (Check())
        {
            door.GetComponent<Renderer>().enabled = false;
            door.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
    
    bool Check()
    {
        /*for(int i = 0; i < TempSave.instance.slots.Length; i++)
        {
            if (TempSave.instance.tempPos[i]==TempSave.instance.slots[i].transform.position&&TempSave.instance.slots[i].GetComponent<Renderer>().material.color!=new Color(1,1,1,0))
            {
                return false;
            }
            else if(TempSave.instance.tempBool[i]&& TempSave.instance.slots[i].GetComponent<Renderer>().material.color != new Color(1, 1, 1, 0))
            {
                return false;
            }           
        }*/
        foreach(Vector3 v3 in TempSave.instance.tempPos)
        {
            for (int i=0; i< TempSave.instance.slots.Length; i++)
            {
                if(v3 != TempSave.instance.slots[i].transform.position && TempSave.instance.slots[i].GetComponent<Renderer>().material.color == new Color(1, 1, 1, 0))
                {
                    return false;
                }
                else if (v3 == TempSave.instance.slots[i].transform.position && TempSave.instance.slots[i].GetComponent<Renderer>().material.color == new Color(1, 1, 1, 0))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
