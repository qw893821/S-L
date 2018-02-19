using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GeneralManager.gm.newgame)
        {
            TempSave.instance.FindSlots();
            GeneralManager.gm.RandomVB();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
