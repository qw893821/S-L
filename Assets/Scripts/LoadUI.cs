using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/game.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
        }

        for (int i = 0; i < TempSave.instance.tempPos.Length; i++)
        {
            TempSave.instance.slots[i].transform.position = new Vector3(save.savePosX,save.savePosY,save.savePosZ);
            TempSave.instance.slots[i].GetComponent<Renderer>().enabled = save.saveBool;
        }
        GameObject.FindGameObjectWithTag("Player").transform.position=new Vector3(save.savePlayerPosX,save.savePlayerPosY,save.savePlayerPosZ);
        SceneManager.LoadSceneAsync(save.savedSceneName,LoadSceneMode.Single);
    }
}
