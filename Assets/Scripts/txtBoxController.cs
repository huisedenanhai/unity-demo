using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DemoChapter;

public class txtBoxController : MonoBehaviour {

    public Canvas txtBox;
	// Use this for initialization
	void Start () {
        txtBox.gameObject.active = false;
        txtBox.GetComponent<CanvasGroup>().alpha = 0;
	}
	public void txtBoxSetActive(){
        txtBox.gameObject.active = !txtBox.gameObject.active;

    }
	// Update is called once per frame
	void Update () {
        if (chapterEvent.txtBoxActive==true && txtBox.GetComponent<CanvasGroup>().alpha != 1) txtBox.GetComponent<CanvasGroup>().alpha += (float)2* Time.deltaTime;
        if (chapterEvent.txtBoxActive == false && txtBox.GetComponent<CanvasGroup>().alpha != 0) txtBox.GetComponent<CanvasGroup>().alpha -= (float)2 * Time.deltaTime;
        if (chapterEvent.txtBoxActive == false && txtBox.GetComponent<CanvasGroup>().alpha == 0 ||(chapterEvent.chapterActive == false && (Input.GetMouseButtonUp(0) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl))))
           txtBox.gameObject.active = false;
    }
}
