using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class chapterEvent : MonoBehaviour {

    public Canvas txtBox;
    public Image chapter_title_bg;
    public Image chapter_title;
    public Image bg;
    public AudioSource bgm;

    void OnEnable() {
        chapter_title.enabled = false;
        bg.enabled = false;
    }

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    int i=0;
    void Update(){    
        if (Input.GetMouseButtonUp(0) == true){
            if (chapter_title.enabled == false) chapter_title.enabled = true;
            else {
                bg.enabled = true;
                txtBox.gameObject.active = true;
                bgm.GetComponent<audioController>().PlayMusic(bgm,"Assets/BGM/1.mp3"); 
            } 
        }
    }
}
