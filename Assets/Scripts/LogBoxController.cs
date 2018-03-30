using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BoxActive;
using DemoChapter;

public class LogBoxController : MonoBehaviour {
    
    public Canvas LogBox;

	// Use this for initialization
	void Start () {
        LogBox.GetComponent<CanvasGroup>().alpha = 0;
        LogBox.gameObject.active = false;
    }

    public void LogBoxOn()
    {
        globalVariable.LogBoxActive = true;
        LogBox.gameObject.active = true;
    }

    // Update is called once per frame
    void Update () {
        if (globalVariable.LogBoxActive == true && LogBox.GetComponent<CanvasGroup>().alpha != 1) LogBox.GetComponent<CanvasGroup>().alpha += (float)3 * Time.deltaTime;
        if (Input.GetMouseButtonUp(1) == true) globalVariable.LogBoxActive = false;
        if (globalVariable.LogBoxActive == false && LogBox.GetComponent<CanvasGroup>().alpha != 0) LogBox.GetComponent<CanvasGroup>().alpha -= (float)3 * Time.deltaTime;
        if (globalVariable.LogBoxActive == false && LogBox.GetComponent<CanvasGroup>().alpha == 0)
        {
            LogBox.gameObject.active = false;
        }
    }
}
