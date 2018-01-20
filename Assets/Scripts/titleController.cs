using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleController : MonoBehaviour {

    public Canvas title;
   
	// Use this for initialization
	void Start () {
		
	}

	public void titleSetAcive(){
        title.gameObject.active = !title.gameObject.active;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
