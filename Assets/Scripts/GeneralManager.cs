using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Save
{
    public List<float> savePosX=new List<float>();
    public List<float> savePosY = new List<float>();
    public List<float> savePosZ = new List<float>();
    public List<bool> saveBool=new List<bool>();
    public float savePlayerPosX;
    public float savePlayerPosY;
    public float savePlayerPosZ;
    public string savedSceneName;
}

public class GeneralManager : MonoBehaviour {
    private static GeneralManager _gm;
    public static GeneralManager gm {
        get { return _gm; }
    }
    public bool newgame;
    public bool isReturn;
    public GameObject[] temp;
    float timer;
    private void Awake()
    {
        if (_gm != null) { Destroy(this.gameObject); }
        else if (_gm == null) { _gm = this; }       
        DontDestroyOnLoad(transform.gameObject);
        newgame = true;
        isReturn = false;
    }
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (isReturn)
        {
            timer += Time.deltaTime;
            foreach(GameObject go in TempSave.instance.slots)
            {
                go.GetComponent<Renderer>().enabled = false;
                foreach(Vector3 v3 in TempSave.instance.tempPos)
                {
                    if (go.transform.position == v3)
                    {
                        go.GetComponent<Renderer>().enabled = true;
                    }
                }
            }
        }
        if (timer >= 1f)
        {
            isReturn = false;
            timer = 0;
        }
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
   
}
