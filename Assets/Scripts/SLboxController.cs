using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BoxActive;
using DemoChapter;

public class SLboxController : MonoBehaviour {

    public Canvas saveBox;
    public Canvas loadBox;
    
    // Use this for initialization
	void Start () {
        saveBox.GetComponent<CanvasGroup>().alpha = 0;
        saveBox.gameObject.active = false;
        loadBox.GetComponent<CanvasGroup>().alpha = 0;
        loadBox.gameObject.active = false;
    }

    public void saveBoxOn() {
        globalVariable.saveBoxAcive = true;
        saveBox.gameObject.active = true;
}

    public void loadBoxOn()
    {
        globalVariable.loadBoxAcive = true;
        loadBox.gameObject.active = true;
    }

    // Update is called once per frame
    void Update () {
        if (globalVariable.saveBoxAcive == true && saveBox.GetComponent<CanvasGroup>().alpha != 1) saveBox.GetComponent<CanvasGroup>().alpha += (float)3 * Time.deltaTime;
        if (Input.GetMouseButtonUp(1) == true) globalVariable.saveBoxAcive = false;
        if (globalVariable.saveBoxAcive == false && saveBox.GetComponent<CanvasGroup>().alpha != 0) saveBox.GetComponent<CanvasGroup>().alpha -= (float)3 * Time.deltaTime;
        if (globalVariable.saveBoxAcive == false && saveBox.GetComponent<CanvasGroup>().alpha == 0) {      
            saveBox.gameObject.active = false;
        }

        if (globalVariable.loadBoxAcive == true && loadBox.GetComponent<CanvasGroup>().alpha != 1) loadBox.GetComponent<CanvasGroup>().alpha += (float)3 * Time.deltaTime;
        if (Input.GetMouseButtonUp(1) == true) globalVariable.loadBoxAcive = false;
        if (globalVariable.loadBoxAcive == false && loadBox.GetComponent<CanvasGroup>().alpha != 0) loadBox.GetComponent<CanvasGroup>().alpha -= (float)3 * Time.deltaTime;
        if (globalVariable.loadBoxAcive == false && loadBox.GetComponent<CanvasGroup>().alpha == 0){       
            loadBox.gameObject.active = false;
        }

     //   if (globalVariable.saveBoxAcive == true || globalVariable.loadBoxAcive == true) chapterEvent.mouseLock = true;
     //   else chapterEvent.mouseLock = false;
    }
}
