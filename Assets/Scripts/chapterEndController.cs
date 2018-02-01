using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chapterEndController : MonoBehaviour {
    public Canvas chapterEnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0)) chapterEnd.gameObject.active = false; 
	}
}
