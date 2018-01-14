using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainTitle : MonoBehaviour {

    public Image imageBackGround;
    public Button buttonStart;
    public Image imageTest;
    public Text lineMain;
    public Image avatar;
    public AudioSource bgm;
    

    private Sprite expan;
    private Sprite back;

    /*fake database*/
    private List<string> lineList;
    private List<string> avatarList;
    private List<int> backImageList;
    private List<string> musicList;
    private int linePointer = 0;
    private int lineMax = 10;

    private float musicVolume = 0.8F;

    private struct DisplayUnit {
        public string line;
        public string avatar;
        public string music;
    };

    private enum MainTitleStates {
        mtvoid = 0,
        mttitle = 1,
        mtchapter = 2,
    };

    private MainTitleStates state;
    private MainTitleStates stateNext;

    private void PlayMusic(string musicPath) {
        if (musicPath == "") {
            return;
        }
        bgm.clip = AssetDatabase.LoadAssetAtPath(musicPath, typeof(AudioClip)) as AudioClip;
        bgm.volume = musicVolume;
        bgm.loop = true;
        bgm.Play();
        return;
    }

    private DisplayUnit GetLineFromDataBase() {
        DisplayUnit ret = new DisplayUnit {
            line = lineList[linePointer],
            avatar = avatarList[linePointer],
            music = musicList[linePointer]
        };
        linePointer = (linePointer + 1) % lineMax;
        return ret;
    }

    private void RefreshState() {
        if (stateNext != MainTitleStates.mtvoid) {
            state = stateNext;
        }
        switch(state) {
            case MainTitleStates.mtchapter:
                imageBackGround.enabled = false;
                imageTest.enabled = true;
                buttonStart.transform.Find("Text").GetComponent<Text>().text = "back";
                lineMain.enabled = true;
                break;
            case MainTitleStates.mttitle:
                imageBackGround.enabled = true;
                imageTest.enabled = false;
                buttonStart.transform.Find("Text").GetComponent<Text>().text = "start";
                lineMain.enabled = false;
                break;
        }
        return;
    }

    private void ButtonStartClick() {
        Debug.Log("ButtonStartClick()" + linePointer.ToString());
        if (state == MainTitleStates.mttitle) {
            stateNext = MainTitleStates.mtchapter;
        } else if(state == MainTitleStates.mtchapter) {
            stateNext = MainTitleStates.mttitle;
        }
        return;
    }

    // Use this for initialization
    void Start() {
        state = MainTitleStates.mttitle;
        stateNext = MainTitleStates.mttitle;
        imageBackGround.enabled = true;
        buttonStart.gameObject.SetActive(true);
        buttonStart.onClick.AddListener(ButtonStartClick);
        imageTest.enabled = false;
        lineMain.StopAllCoroutines();

        /* init */
        lineList = new List<string>();
        avatarList = new List<string>();
        musicList = new List<string>();
        for (int i = 0; i < lineMax; i++) {
            lineList.Add("你对中文支持怎么样 " + i.ToString() + "!\n");
            avatarList.Add("avatar" + (i%2).ToString());
            if (i == 0) {
                musicList.Add("Assets/2.mp3");
            } else if (i==5){
                musicList.Add("Assets/1.mp3");
               
            }
            else {  musicList.Add("");}
              
        }
        linePointer = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonUp(0) == true) {
            if ((state == MainTitleStates.mtchapter) && (stateNext == MainTitleStates.mtchapter)) {
                DisplayUnit dpu = GetLineFromDataBase();
                lineMain.text = dpu.line;
                avatar.sprite = Resources.Load(dpu.avatar, typeof(Sprite)) as Sprite;
                PlayMusic(dpu.music);
            }
            RefreshState();
        }
    }
}
