using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class chapterEvent : MonoBehaviour {

    public Canvas txtBox;
    public Image chapter_title_bg;
    public Image chapter_title;
    public Image bg;
    public AudioSource bgm;
    public Text txt;
    public Image avatar;

    private struct DisplayUnit
    {
        public string line;
        public string avatar;
        public string music;
    }

    private enum MainTitleStates
    {
        mtvoid = 0,
        mttitle = 1,
        mtchapter = 2,
    };

    private MainTitleStates state;
    private MainTitleStates stateNext;
    private IDbConnection dbconn;

    private DisplayUnit GetLineFromDataBase()
    {     
       

        IDbCommand dbcmd = dbconn.CreateCommand();
        int id = (int)(Random.value * 1000) %3+1;
        string sqlQuery = "SELECT line, avatarpath, musicpath from colorless where id = " + id.ToString() + ";";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        string line = "";
        string avatarpath = "";
        string musicpath = "";
        while (reader.Read())
        {
            line = reader.GetString(0);
            avatarpath = reader.GetString(1);
            musicpath = reader.GetString(2);
            Debug.Log("line= " + line + "  avatarpath =" + avatarpath + "  musicpath =" + musicpath);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;     
        Debug.Log("test bug");

        DisplayUnit ret = new DisplayUnit
        {
            line = line,
            avatar =avatarpath,
            music=musicpath
        };
        return ret;
    }

    void OnEnable() {
        chapter_title.enabled = false;
        bg.enabled = false;
    }

	// Use this for initialization
	void Start () {
        string conn = "URI=file:" + Application.dataPath + "/DataBase/test.db";
        Debug.Log(conn);
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
    }

    // Update is called once per frame
    int i=0;
    void Update(){    
       if (Input.GetMouseButtonUp(0) == true){
            if (chapter_title.enabled == false) chapter_title.enabled = true;
            else {
                bg.enabled = true;
                txtBox.gameObject.active = true;
                bgm.GetComponent<audioController>().PlayMusic(bgm,"Assets/BGM/1.mp3");
                DisplayUnit dpu = GetLineFromDataBase();
                txt.text = dpu.line;
                avatar.sprite = Resources.Load(dpu.avatar, typeof(Sprite)) as Sprite;
             //   PlayMusic(dpu.music);
            } 
        }

     //   if (Input.GetMouseButtonUp(0) == true)
    //       {
          //  if ((state == MainTitleStates.mtchapter) && (stateNext == MainTitleStates.mtchapter))
         //   {
               // DisplayUnit dpu = GetLineFromDataBase();
            //      txt.text = dpu.line;
            
        //    }
//RefreshState();
        //}
    }
}
