using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using BoxActive;

namespace DemoChapter {


    public class chapterEvent : MonoBehaviour {

        public Canvas txtBox;
        public Canvas configBox;
        public Canvas LogBox;
        public Image chapter_title_bg;
        public Image chapter_title;
        public Image bg;
        public AudioSource bgm;
        public AudioSource voice;
        public AudioSource otmosphereSound;
        public AudioSource effectSound;
        public Text txt;
        public Text txt2;
        public Image avatar;
        public Canvas chapterThis;
        public Canvas chapterNext;

        private struct DisplayUnit {
            public string line;
            public string character;
            public string avatar;
            public string voice;
            public string music;
            public string sound;
            public string chapterbg;
        }

        private enum MainTitleStates {
            mtvoid = 0,
            mttitle = 1,
            mtchapter = 2,
        };

        private MainTitleStates state;
        private MainTitleStates stateNext;
        private IDbConnection dbconn;

        private DisplayUnit GetLineFromDataBase(int ID) {


            IDbCommand dbcmd = dbconn.CreateCommand();
            int id = ID;
            string sqlQuery = "SELECT line,character,avatarpath, voicepath,musicpath,soundpath,chapterbgpath from colorless where id = " + id.ToString() + ";";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            string line = "";
            string character = "";
            string avatarpath = "";
            string voicepath = "";
            string musicpath = "";
            string soundpath = "";
            string chapterbgpath = "";
            while (reader.Read()) {
                line = reader.GetString(0);
                character = reader.GetString(1);
                avatarpath = reader.GetString(2);
                if (avatarpath == "" || avatarpath==null) avatarpath = "Character/ch_0";
                voicepath = reader.GetString(3);
                musicpath = reader.GetString(4);
                soundpath = reader.GetString(5);
                chapterbgpath = reader.GetString(6);
                //Debug.Log("line= " + line + "  character =" + character + "  avatarpath =" + avatarpath + "  voicepath =" + voicepath + "  musicpath =" + musicpath + "  soundpath =" + soundpath + "  chapterbgpath =" + chapterbgpath);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            // Debug.Log("test bug");

            DisplayUnit ret = new DisplayUnit {
                line = line,
                character = character,
                avatar = avatarpath,
                voice = voicepath,
                music = musicpath,
                sound = soundpath,
                chapterbg = chapterbgpath 
            };
            return ret;
        }
        public static bool mouseLock;
        string avatarChange="";
        public void mouseLockOn() { if (globalVariable.skipTxtOn != true && globalVariable.autoTxtOn!=true) chapterEvent.mouseLock = true; }
        public void mouseLockOff() { chapterEvent.mouseLock = false; }
        public static int PlayIndex = 0;
        public static int SaveIndex = 0;
        public static int LogIndex = 0;
        public static bool txtBoxActive = false;
        public static bool chapterbgActive = false;
        public static bool chapterActive = false;
        public static bool chapterEndActive = false;
        public static float letterPause = 0.2f;
        string bgmPlay;
        void OnEnable() {
            PlayIndex = 1;
            bgmPlay = "";
            chapter_title.enabled = false;
            bg.enabled = false;
            chapterEvent.mouseLock = false;
        }

        private IEnumerator TypeText(string word, Text T) {
            foreach (char letter in word.ToCharArray()) {
                T.text += letter;
                yield return new WaitForSeconds(letterPause);
            }
        }

        private IEnumerator AvatarChange(Image avatar,string avatarpath,float durationTime){       
            avatar.CrossFadeAlpha(0, durationTime, true);
            yield return new WaitForSeconds(durationTime);
            avatar.sprite = Resources.Load(avatarpath, typeof(Sprite)) as Sprite;
            avatar.CrossFadeAlpha(1, durationTime, true);
        }

        private IEnumerator ImageFadeOut(Image bg,float durationTime){
            bg.CrossFadeAlpha(0, durationTime, true);
            yield return new WaitForSeconds(durationTime);
            bg.enabled = false;
        }


        // Use this for initialization

        
        void Start() {
            string conn = "URI=file:" + Application.dataPath + "/DataBase/test.db";
            Debug.Log(conn);
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open();
            bg.CrossFadeAlpha(0, 0, true);
            chapter_title.CrossFadeAlpha(0, 0, true);
            avatar.CrossFadeAlpha(0, 0, true);
            bg.CrossFadeAlpha(0, 0, true);
        }

        // Update is called once per frame

        void Update() {
            if (chapterbgActive == false && otmosphereSound.isPlaying==false) otmosphereSound.Play();
            if(bg.enabled == true) otmosphereSound.Stop();
            if ((Input.GetMouseButtonUp(0) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl) || globalVariable.skipTxtOn == true || globalVariable.autoFrame == true) && chapterEvent.mouseLock == false && configBox.gameObject.active == false && globalVariable.saveBoxAcive == false && globalVariable.loadBoxAcive == false && globalVariable.LogBoxActive == false ) {

                if (chapter_title.enabled == false){
                    chapter_title.enabled = true;
                    chapter_title.CrossFadeAlpha(1,(float)0.33, true);
                }
                else
                {

                    DisplayUnit dpu = GetLineFromDataBase(PlayIndex);
                    if (bgmPlay != dpu.music)
                    {
                        bgmPlay = dpu.music;
                        bgm.GetComponent<audioController>().PlayMusic(bgm, dpu.music);
                    }
                    if(dpu.chapterbg!="") bg.sprite = Resources.Load(dpu.chapterbg, typeof(Sprite)) as Sprite;
                    bg.enabled = true;
                    chapterbgActive = true;
                    bg.CrossFadeAlpha(1, (float)1, true);
                    txtBox.gameObject.active = true;
                    txtBoxActive = true;
                    effectSound.clip = Resources.Load(dpu.sound, typeof(AudioClip)) as AudioClip;
                    effectSound.Play();
                    voice.clip = Resources.Load(dpu.voice, typeof(AudioClip)) as AudioClip;
                    voice.Play();
                    txt.text = "";
                    //Debug.Log("-----------------------"+dpu.sound);
                    StartCoroutine(TypeText(dpu.line, txt));
                    //Debug.Log("foreach");
                    txt2.text = dpu.character;
                    if (avatarChange != dpu.avatar){
                        StartCoroutine(AvatarChange(avatar,dpu.avatar,(float)0.2));
                        avatarChange = dpu.avatar;
                    }
                   
                    //Debug.Log(PlayIndex.ToString ());                   
                    if (PlayIndex == 69)
                    {
                        bgm.Stop();
                        txtBoxActive = false;
                        chapterbgActive = false;
                        StartCoroutine(ImageFadeOut(bg, (float)1));
                        chapter_title.enabled = false;
                        chapter_title.sprite = Resources.Load("UI/chapter/chapter2", typeof(Sprite)) as Sprite;
                        chapter_title.CrossFadeAlpha(0, 0, true);
                    }
                    if (PlayIndex == 101)
                    {
                        bgm.Stop();
                        txtBoxActive = false;
                        chapterbgActive = false;
                        StartCoroutine(ImageFadeOut(bg, (float)1));
                        chapter_title.enabled = false;
                        chapter_title.sprite = Resources.Load("UI/chapter/chapter3", typeof(Sprite)) as Sprite;
                        chapter_title.CrossFadeAlpha(0, 0, true);
                    }
                    if (PlayIndex == 136)
                    {
                        bgm.Stop();
                        txtBoxActive = false;
                        chapterbgActive = false;
                        StartCoroutine(ImageFadeOut(bg, (float)1));
                        chapter_title.enabled = false;
                        chapter_title.sprite = Resources.Load("UI/chapter/chapter4", typeof(Sprite)) as Sprite;
                        chapter_title.CrossFadeAlpha(0, 0, true);
                    }
                    if (PlayIndex >= 189)
                    {
                        bgm.Stop();
                        txtBoxActive = false;
                        chapterbgActive = false;
                        chapterEndActive = true;
                        chapterNext.gameObject.active = true;
                        chapterActive = false;
                        chapter_title.sprite = Resources.Load("UI/chapter/chapter1", typeof(Sprite)) as Sprite;
                    }
                    LogIndex = PlayIndex;
                    PlayIndex++;
                }
            }

            if (globalVariable.LogBoxActive == true){          
                if (Input.GetAxis("Mouse ScrollWheel") < 0 && LogIndex < PlayIndex-1)
                {               
                    LogIndex++;
                }
                if (Input.GetAxis("Mouse ScrollWheel") > 0 && LogIndex > 4)
                {               
                    LogIndex--;
                }
            }
            if (LogIndex == 0){
                LogBox.transform.FindChild("Log1").GetComponent<Text>().text = "";
                LogBox.transform.FindChild("Log2").GetComponent<Text>().text = "";
                LogBox.transform.FindChild("Log3").GetComponent<Text>().text = "";
                LogBox.transform.FindChild("Log4").GetComponent<Text>().text = "";
            }
            if (LogIndex == 1) {                
                LogBox.transform.FindChild("Log1").GetComponent<Text>().text = GetLineFromDataBase(LogIndex).line;
                LogBox.transform.FindChild("Log2").GetComponent<Text>().text = "";
                LogBox.transform.FindChild("Log3").GetComponent<Text>().text = "";
                LogBox.transform.FindChild("Log4").GetComponent<Text>().text = "";
            }
            if (LogIndex == 2){            
                LogBox.transform.FindChild("Log1").GetComponent<Text>().text = GetLineFromDataBase(LogIndex-1).line;
                LogBox.transform.FindChild("Log2").GetComponent<Text>().text = GetLineFromDataBase(LogIndex).line;
                LogBox.transform.FindChild("Log3").GetComponent<Text>().text = "";
                LogBox.transform.FindChild("Log4").GetComponent<Text>().text = "";
            }
            if (LogIndex == 3){           
                LogBox.transform.FindChild("Log1").GetComponent<Text>().text = GetLineFromDataBase(LogIndex-2).line;
                LogBox.transform.FindChild("Log2").GetComponent<Text>().text = GetLineFromDataBase(LogIndex-1).line;
                LogBox.transform.FindChild("Log3").GetComponent<Text>().text = GetLineFromDataBase(LogIndex).line;
                LogBox.transform.FindChild("Log4").GetComponent<Text>().text = "";
            }
            if (LogIndex >= 4){           
                LogBox.transform.FindChild("Log1").GetComponent<Text>().text = GetLineFromDataBase(LogIndex-3).line;
                LogBox.transform.FindChild("Log2").GetComponent<Text>().text = GetLineFromDataBase(LogIndex-2).line;
                LogBox.transform.FindChild("Log3").GetComponent<Text>().text = GetLineFromDataBase(LogIndex-1).line;
                LogBox.transform.FindChild("Log4").GetComponent<Text>().text = GetLineFromDataBase(LogIndex).line;
            }
            if (LogIndex == 0){            
                LogBox.transform.FindChild("name1").GetComponent<Text>().text = "";
                LogBox.transform.FindChild("name2").GetComponent<Text>().text = "";
                LogBox.transform.FindChild("name3").GetComponent<Text>().text = "";
                LogBox.transform.FindChild("name4").GetComponent<Text>().text = "";
            }
            if (LogIndex == 1)
            {
                LogBox.transform.FindChild("name1").GetComponent<Text>().text = GetLineFromDataBase(LogIndex).character;
                LogBox.transform.FindChild("name2").GetComponent<Text>().text = "";
                LogBox.transform.FindChild("name3").GetComponent<Text>().text = "";
                LogBox.transform.FindChild("name4").GetComponent<Text>().text = "";
            }
            if (LogIndex == 2)
            {
                LogBox.transform.FindChild("name1").GetComponent<Text>().text = GetLineFromDataBase(LogIndex - 1).character;
                LogBox.transform.FindChild("name2").GetComponent<Text>().text = GetLineFromDataBase(LogIndex).character;
                LogBox.transform.FindChild("name3").GetComponent<Text>().text = "";
                LogBox.transform.FindChild("name4").GetComponent<Text>().text = "";
            }
            if (LogIndex == 3)
            {
                LogBox.transform.FindChild("name1").GetComponent<Text>().text = GetLineFromDataBase(LogIndex - 2).character;
                LogBox.transform.FindChild("name2").GetComponent<Text>().text = GetLineFromDataBase(LogIndex - 1).character;
                LogBox.transform.FindChild("name3").GetComponent<Text>().text = GetLineFromDataBase(LogIndex).character;
                LogBox.transform.FindChild("name4").GetComponent<Text>().text = "";
            }
            if (LogIndex >= 4)
            {
                LogBox.transform.FindChild("name1").GetComponent<Text>().text = GetLineFromDataBase(LogIndex - 3).character;
                LogBox.transform.FindChild("name2").GetComponent<Text>().text = GetLineFromDataBase(LogIndex - 2).character;
                LogBox.transform.FindChild("name3").GetComponent<Text>().text = GetLineFromDataBase(LogIndex - 1).character;
                LogBox.transform.FindChild("name4").GetComponent<Text>().text = GetLineFromDataBase(LogIndex).character;
            }
        }
    }
}
 