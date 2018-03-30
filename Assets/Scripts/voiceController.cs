using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class voiceController : MonoBehaviour {

    public AudioSource voice;
    public Slider sliderVoice;

    // Use this for initialization
    void Start () {
        voice.volume = sliderVoice.value;
    }
	
	// Update is called once per frame
	void Update () {
        voice.volume = sliderVoice.value;
    }
}
