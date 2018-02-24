using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

namespace DemoChapter {


    public class chapterEvent : MonoBehaviour {

        public Canvas txtBox;
        public Image chapter_title_bg;
        public Image chapter_title;
        public Image bg;
        public AudioSource bgm;
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
            string sqlQuery = "SELECT line,character,avatarpath, voicepath,musicpath,soundpath from colorless where id = " + id.ToString() + ";";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            string line = "";
            string character = "";
            string avatarpath = "";
            string voicepath = "";
            string musicpath = "";
            string soundpath = "";
            while (reader.Read()) {
                line = reader.GetString(0);
                character = reader.GetString(1);
                avatarpath = reader.GetString(2);
                if (avatarpath == "") avatarpath = "Character/ch_0";
                voicepath = reader.GetString(3);
                musicpath = reader.GetString(4);
                soundpath = reader.GetString(5);
                Debug.Log("line= " + line + "  character =" + character + "  avatarpath =" + avatarpath + "  voicepath =" + voicepath + "  musicpath =" + musicpath + "  soundpath =" + soundpath);
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
                sound = soundpath
            };
            return ret;
        }

        public static int PlayIndex = 0;
        public static float letterPause = 0.2f;
        string bgmPlay;
        void OnEnable() {
            PlayIndex = 1;
            bgmPlay = "";
            chapter_title.enabled = false;
            bg.enabled = false;
        }

        private IEnumerator TypeText(string word, Text T) {
            foreach (char letter in word.ToCharArray()) {
                T.text += letter;
                yield return new WaitForSeconds(letterPause);
            }
        }

        // Use this for initialization
        void Start() {
            string conn = "URI=file:" + Application.dataPath + "/DataBase/test.db";
            Debug.Log(conn);
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open();
        }

        // Update is called once per frame

        void Update() {
            if (Input.GetMouseButtonUp(0) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) {
                if (chapter_title.enabled == false) chapter_title.enabled = true;
                else {
                    bg.enabled = true;
                    txtBox.gameObject.active = true;
                    DisplayUnit dpu = GetLineFromDataBase(PlayIndex);
                    if (bgmPlay != dpu.music) {
                        bgmPlay = dpu.music;
                        bgm.GetComponent<audioController>().PlayMusic(bgm, "Assets/" + dpu.music + ".mp3");
                    }
                    txt.text = "";
                    Debug.Log("txt.text");
                    StartCoroutine(TypeText(dpu.line, txt));
                    Debug.Log("foreach");
                    txt2.text = dpu.character;
                    avatar.sprite = Resources.Load(dpu.avatar, typeof(Sprite)) as Sprite;
                    PlayIndex++;
                    if (PlayIndex == 69) {
                        txtBox.gameObject.active = false;
                        chapterNext.gameObject.active = true;
                        chapterThis.gameObject.active = false;
                    }
                }
            }
        }
    }

}
 