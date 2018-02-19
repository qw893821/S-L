using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSave:MonoBehaviour{
    private static TempSave _instance;
    public static TempSave instance {
        get { return _instance; }
    }

    public GameObject[] slots;
    public Vector3[] tempPos;
    public bool[] tempBool;

    void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
        }
        slots = GameObject.FindGameObjectsWithTag("Slot");
        tempPos = new Vector3[slots.Length];
        tempBool = new bool[slots.Length];
    }
    private void Start()
    {
        
    }

    public void GetTemp()
    {
        
        for(int i = 0; i < slots.Length; i++)
        {
            
            tempBool[i] = slots[i].GetComponent<Renderer>().enabled;
            if (tempBool[i])
            {
                tempPos[i] = slots[i].transform.position;
               
            }
            else { tempPos[i] = Vector3.zero; }
        }
    }

    private void Update()
    {
        FindSlots();
    }

    public void FindSlots()
    {
        if (slots[0] == null)
        {
            slots = GameObject.FindGameObjectsWithTag("Slot");
        }
    }
}
