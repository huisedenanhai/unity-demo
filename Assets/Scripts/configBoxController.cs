using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DemoChapter;

public class configBoxController : MonoBehaviour {

    public Canvas configBox;
    public Canvas chapter;
    public Canvas txtBox;
    public Slider Slider_txtSpeed;

    public static int MaxTextSpeed = 100;

    bool configBoxActive;

    // Use this for initialization
    void Start () {
        chapterEvent.letterPause = 0.01f + (float)(MaxTextSpeed - Slider_txtSpeed.value) / 1000;
        configBoxActive = false;
        configBox.gameObject.active = false;
        configBox.GetComponent<CanvasGroup>().alpha = 0;
	}

    public void configBoxSetActive()
    {
        configBoxActive = true;
        configBox.gameObject.active = true;
    }

    public void returnTitleButton()
    {
        //chapter.gameObject.active = false;
        chapterEvent.chapterActive = false;
        //txtBox.gameObject.active = false;
        chapterEvent.txtBoxActive = false;
        configBoxActive = false;
    }

    // Update is called once per frame
    void Update() {
        chapterEvent.letterPause = 0.01f + (float)(MaxTextSpeed - Slider_txtSpeed.value) / 1000;
        if (configBoxActive == true && configBox.GetComponent<CanvasGroup>().alpha != 1) configBox.GetComponent<CanvasGroup>().alpha += (float)3 * Time.deltaTime;
        if (Input.GetMouseButtonUp(1) == true) configBoxActive = false;
        if (configBoxActive == false && configBox.GetComponent<CanvasGroup>().alpha != 0) configBox.GetComponent<CanvasGroup>().alpha -= (float) 3* Time.deltaTime;
        if (configBoxActive == false && configBox.GetComponent<CanvasGroup>().alpha == 0) configBox.gameObject.active=false;
    }
}
