using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousEnter : MonoBehaviour {
    string currentName;
    string preName;
    private void Awake()
    {
        currentName = SceneManager.GetActiveScene().name;
        for (int i = 0; i <= 5; i++)
        {
            //match current scene with the name of currentName and then name nextName with next scene name
            if (currentName == "Scene_" + i.ToString())
            {
                preName = "Scene_" + (i - 1).ToString();
                break;
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            GeneralManager.gm.isReturn = true;
            SceneManager.LoadScene(preName, LoadSceneMode.Single);
        }
    }
}
