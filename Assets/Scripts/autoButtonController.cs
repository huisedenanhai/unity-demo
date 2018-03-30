using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using BoxActive;


public class autoButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void autoButtonOn(){   
        globalVariable.autoTxtOn = true;
        autotime = 0;
    }

    // private IEnumerator WaitForAuto(float autoTime ) {
    //     yield return new WaitForSeconds(autoTime);
    //     globalVariable.autoFrame = true;
    //     yield return new WaitForEndOfFrame();
    //     globalVariable.autoFrame = false;
    //}
    private  float autotime=0;
    // Update is called once per frame
    void Update () {
        if ((Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) && globalVariable.pointerInButton == false) globalVariable.autoTxtOn = false;
        if(globalVariable.autoTxtOn==true){
            //  StartCoroutine(WaitForAuto(1));
            if (autotime == 0) globalVariable.autoFrame = false;
            autotime += Time.deltaTime;
            if(autotime>=3){           
                globalVariable.autoFrame = true;
                autotime = 0;
            }
        }
    }
}
