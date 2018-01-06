using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTitle : MonoBehaviour {

    public Image imageBackGround;
    public Button buttonStart;
    public Image imageTest;

    private Sprite expan;
    private Sprite back;

    private bool ifShow = false;

    private void ButtonStartClick() {
        ifShow = !ifShow;
        if (ifShow) {
            imageBackGround.enabled = false;
            imageTest.enabled = true;
            buttonStart.transform.Find("Text").GetComponent<Text>().text = "back";
        } else {
            imageBackGround.enabled = true;
            imageTest.enabled = false;
            buttonStart.transform.Find("Text").GetComponent<Text>().text = "start";
        }
        return;
    }

	// Use this for initialization
	void Start () {
        imageBackGround.enabled = true;
        buttonStart.gameObject.SetActive(true);
        buttonStart.onClick.AddListener(ButtonStartClick);
        imageTest.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

	}
}
