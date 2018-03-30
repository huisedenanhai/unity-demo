using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BoxActive;
using DemoChapter;

public class skipButtonController : MonoBehaviour {

    //public Button skipButton;

	// Use this for initialization
	void Start () {
		
	}

    public void pointerInButtonTrue() {
        globalVariable.pointerInButton = true;
    }

    public void pointerInButtonFalse() {  
        globalVariable.pointerInButton = false;
    }

    public void skipButtonOn() {
        globalVariable.skipTxtOn = true;
    }
	
	// Update is called once per frame
	void Update () {      
        if ((Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) && globalVariable.pointerInButton==false) globalVariable.skipTxtOn = false;
	}
}
