using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DemoChapter;

public class chapterEndController : MonoBehaviour {
    public Canvas chapterEnd;
    
    private bool animationPlay = false;
    private float posY = -3168;

	// Use this for initialization
    void OnEnable(){
        animationPlay = false;
        posY = -3168;
        chapterEnd.transform.FindChild("bg_end").GetComponent<RectTransform>().anchoredPosition = new Vector3((float)-0.015081, posY, 0);
    }

	void Start () {
        
}
	
	// Update is called once per frame
	void Update () {
        if (animationPlay==false && Input.GetMouseButtonUp(0)) animationPlay = !animationPlay;
        else if(Input.GetMouseButtonUp(0)){       
            animationPlay = false;
            chapterEvent.chapterEndActive = false;
        }
        if (animationPlay == true && chapterEnd.transform.FindChild("bg_end").GetComponent<RectTransform>().anchoredPosition.y <= 428){        
            chapterEnd.transform.FindChild("bg_end").GetComponent<RectTransform>().anchoredPosition = new Vector3((float)-0.015081, posY, 0);
            posY += 100 * Time.deltaTime;
        }
	}
}
