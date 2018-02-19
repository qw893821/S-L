using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveUI : MonoBehaviour {
    Button btn;
	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SaveGame);
	}
	
	// Update is called once per frame
	void Update () {
	}

    private Save CreateSave()
    {
        Save save = new Save();
        for(int i = 0; i < TempSave.instance.tempPos.Length; i++)
        {
            save.savePosX.Add(TempSave.instance.tempPos[i].x);
            save.savePosY.Add(TempSave.instance.tempPos[i].y);
            save.savePosZ.Add(TempSave.instance.tempPos[i].z);
            save.saveBool.Add(TempSave.instance.tempBool[i]);
        }
        save.savePlayerPosX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        save.savePlayerPosY = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        save.savePlayerPosZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        save.savedSceneName = SceneManager.GetActiveScene().name;
        return save;
    }

    private void SaveGame()
    {
        Save save = CreateSave();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("save game");
    }


}
