using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class configBoxController : MonoBehaviour {

    public Canvas configBox;
    public Canvas chapter1, chapter2, chapter3, chapter4;
    public Canvas txtBox;
   
	// Use this for initialization
	void Start () {
        configBox.gameObject.active = false;
	}

    public void configBoxSetActive()
    {
        configBox.gameObject.active = !configBox.gameObject.active;
    }

    public void returnTitleButton()
    {
        chapter1.gameObject.active = false;
        chapter2.gameObject.active = false;
        chapter3.gameObject.active = false;
        chapter4.gameObject.active = false;
        txtBox.gameObject.active = false;
        configBox.gameObject.active = !configBox.gameObject.active;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonUp(1) == true) configBox.gameObject.active = false;
	}
}
