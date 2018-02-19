using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadUI : MonoBehaviour {
    Button btn;
	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save")){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            for (int i = 0; i < TempSave.instance.tempPos.Length; i++)
            {
                TempSave.instance.slots[i].transform.position = new Vector3(save.savePosX[i], save.savePosY[i], save.savePosZ[i]);
                TempSave.instance.slots[i].GetComponent<Renderer>().enabled = save.saveBool[i];
            }
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(save.savePlayerPosX, save.savePlayerPosY, save.savePlayerPosZ);
            //SceneManager.LoadSceneAsync(save.savedSceneName, LoadSceneMode.Single);
        }

        
    }
}
