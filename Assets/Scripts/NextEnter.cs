using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextEnter : MonoBehaviour {
    string currentName;
    string nextName;
    private void Awake()
    {
        currentName = SceneManager.GetActiveScene().name;
        for(int i = 0; i<= 5; i++)
        {
            //match current scene with the name of currentName and then name nextName with next scene name
            if (currentName == "Scene_" + i.ToString())
            {
                nextName = "Scene_" + (i + 1).ToString();
                Debug.Log(nextName);
                break;
            }
        }
    }

    //when enter the game, load next scene
    private void OnTriggerEnter(Collider col)
    {
        TempSave.instance.GetTemp();
        if (col.tag == "Player")
        {
            SceneManager.LoadScene(nextName, LoadSceneMode.Single);
        }
    }
}
