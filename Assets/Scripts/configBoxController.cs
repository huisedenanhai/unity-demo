using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class configBoxController : MonoBehaviour {

    public Canvas configBox;
   
	// Use this for initialization
	void Start () {
        configBox.gameObject.active = false;
	}

    public void configBoxSetActive()
    {
        configBox.gameObject.active = !configBox.gameObject.active;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(1) == true) configBox.gameObject.active = false;
	}
}
