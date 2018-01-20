using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class audioController : MonoBehaviour {

    public AudioSource BGM;
    public Slider sliderBGM;

    public void PlayMusic(AudioSource bgm,string musicPath)
    {
        if (musicPath == "")
        {
            return;
        }
        bgm.clip = AssetDatabase.LoadAssetAtPath(musicPath, typeof(AudioClip)) as AudioClip;
        bgm.Play();
        return;
    }

    int i,j;
    // Use this for initialization
    private GameObject title;
    void Start () {
        BGM.volume = sliderBGM.value;
        title = GameObject.Find("title");
        i = (int)(Random.value * 1000) % 3 + 1;
        j = 0;
    }
    
	// Update is called once per frame
	void Update () {
        BGM.volume = sliderBGM.value;
        if (BGM.isPlaying == false && title.gameObject.active == true) {            
            while (j == i) i = (int)(Random.value * 1000) % 3 + 1;
            j = i;          
            PlayMusic(BGM,"Assets/BGM/" + j + ".mp3");
        }
        if (title.gameObject.active == false) BGM.Stop();
    }
}
