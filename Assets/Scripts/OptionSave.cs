using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DemoLib;

public class OptionSave : MonoBehaviour {

    public SaveAndLoad SaveAndLoadManager;

    public void Start() {
        Debug.Log("Button Start.");
        SaveAndLoadManager = new SaveAndLoad();
    }

    public void OnClick() {
        SaveAndLoadManager.Save();
        Debug.Log("Button Clicked. ClickHandler.");
    }

    public void OnLoad() {
        SaveAndLoadManager.Load();
        Debug.Log("Button Clicked. ClickHandler.");
    }
}
