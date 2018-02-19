using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFindGo : MonoBehaviour {
    Button btn;
    // Use this for initialization
    void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(GeneralManager.gm.NewGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
