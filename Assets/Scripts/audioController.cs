using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class audioController : MonoBehaviour {

    public AudioSource BGM;
    public Slider sliderBGM;

    private void PlayMusic(string musicPath)
    {
        if (musicPath == "")
        {
            return;
        }
        BGM.clip = AssetDatabase.LoadAssetAtPath(musicPath, typeof(AudioClip)) as AudioClip;
        BGM.Play();
        return;
    }

    // Use this for initialization
    void Start () {
        
        BGM.volume = sliderBGM.value;
        
	}
	int i = (int)(Random.value*1000)%3+1;
    int j=0;
	// Update is called once per frame
	void Update () {
        BGM.volume = sliderBGM.value;
        if (BGM.isPlaying == false) {            
            while (j == i) i = (int)(Random.value * 1000) % 3 + 1;
            j = i;          
            PlayMusic("Assets/BGM/" + j + ".mp3");
            
        }
    }
}
