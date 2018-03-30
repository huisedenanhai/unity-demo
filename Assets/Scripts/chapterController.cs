using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DemoChapter;

public class chapterController : MonoBehaviour {

    public Canvas chapter;

    public Canvas chapterEnd;
    // Use this for initialization
    void Start () {
        chapter.gameObject.active = false;
        chapter.GetComponent<CanvasGroup>().alpha = 0;
        chapterEnd.gameObject.active = false;
        chapterEnd.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void startChpter(){
        chapter.gameObject.active = true;
        chapterEvent.chapterActive = true;

    }

    public void saveGame() {
        chapterEvent.SaveIndex = chapterEvent.PlayIndex-1;
    }

    public void loadGame()
    {
        if (chapterEvent.SaveIndex != 0) chapterEvent.PlayIndex = chapterEvent.SaveIndex;
        else chapterEvent.mouseLock = true;
    }

    // Update is called once per frame
    void Update () {
        if (chapterEvent.chapterActive == true && chapter.GetComponent<CanvasGroup>().alpha != 1) chapter.GetComponent<CanvasGroup>().alpha += (float)1 * Time.deltaTime;
        if (chapterEvent.chapterActive == false && chapter.GetComponent<CanvasGroup>().alpha != 0) chapter.GetComponent<CanvasGroup>().alpha -= (float)1 * Time.deltaTime;
        if (chapterEvent.chapterActive == false && chapter.GetComponent<CanvasGroup>().alpha == 0) chapter.gameObject.active = false;
        if (chapterEvent.chapterEndActive == true && chapterEnd.GetComponent<CanvasGroup>().alpha != 1) chapterEnd.GetComponent<CanvasGroup>().alpha += (float)1 * Time.deltaTime;
        if (chapterEvent.chapterEndActive == false && chapterEnd.GetComponent<CanvasGroup>().alpha != 0) chapterEnd.GetComponent<CanvasGroup>().alpha -= (float)1 * Time.deltaTime;
        if (chapterEvent.chapterEndActive == false && chapterEnd.GetComponent<CanvasGroup>().alpha == 0) chapterEnd.gameObject.active = false;
    }
}
