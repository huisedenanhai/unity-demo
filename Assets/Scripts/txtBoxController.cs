using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txtBoxController : MonoBehaviour {

    public Canvas txtBox;
	// Use this for initialization
	void Start () {
        txtBox.gameObject.active = false;
	}
	public void txtBoxSetActive(){
        txtBox.gameObject.active = !txtBox.gameObject.active;

    }
	// Update is called once per frame
	void Update () {
		
	}
}
