﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour {
    private static GeneralManager _gm;
    public static GeneralManager gm {
        get { return _gm; }
    }
    public bool newgame;
    public GameObject[] temp;
    private void Awake()
    {
        if (_gm != null) { Destroy(this.gameObject); }
        else if (_gm == null) { _gm = this; }       
        DontDestroyOnLoad(transform.gameObject);
        newgame = true;
    }
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void LateUpdate () {
        LateSet(1f);
	}

    //gos1 is current scene slot, gos2 is previous scene slot
    public void SetVB(GameObject[] gos1,GameObject[] gos2)
    {
        for(int i = 0; i <= gos1.Length; i++)
        {
            gos1[i].GetComponent<Renderer>().enabled = gos2[i].GetComponent<Renderer>().enabled;
        }
    }

    public void RandomVB()
    {
        foreach (GameObject go in TempSave.instance.slots)
        {
            if (Random.Range(0, 1f) > 0.5f)
            {
                Debug.Log("false");
                go.GetComponent<Renderer>().enabled = false;
            }
            else if (Random.Range(0, 1f) <= 0.5f)
            {
                go.GetComponent<Renderer>().enabled = true;
            }
        }
        newgame = false;
        
    }

    public void NewGame()
    {
        newgame = true;
        SceneManager.LoadSceneAsync("Scene_1", LoadSceneMode.Single);
        
        
    }
    private IEnumerator LateSet(float timer)
    {
        while (true)
        {
            RandomVB();
        }
    }

}