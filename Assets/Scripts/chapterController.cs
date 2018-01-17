using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chapterController : MonoBehaviour {

    public Canvas chapter;
	// Use this for initialization
	void Start () {
        chapter.gameObject.active = false;
    }

    public void startChpter(){
        chapter.gameObject.active = true;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
