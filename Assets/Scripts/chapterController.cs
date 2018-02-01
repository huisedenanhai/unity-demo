using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chapterController : MonoBehaviour {

    public Canvas chapter1;
    public Canvas chapter2;
    public Canvas chapter3;
    public Canvas chapter4;
    public Canvas chapterEnd;
    // Use this for initialization
    void Start () {
        chapter1.gameObject.active = false;
        chapter2.gameObject.active = false;
        chapter3.gameObject.active = false;
        chapter4.gameObject.active = false;
        chapterEnd.gameObject.active = false;
    }

    public void startChpter(){
        chapter1.gameObject.active = true;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
