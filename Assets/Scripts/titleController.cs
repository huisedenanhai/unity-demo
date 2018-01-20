using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class titleController : MonoBehaviour {

    public Canvas title;

    private struct DisplayUnit {
        public string line;
        public string avatar;
        public string music;
    }

    private enum MainTitleStates {
        mtvoid = 0,
        mttitle = 1,
        mtchapter = 2,
    };

    private MainTitleStates state;
    private MainTitleStates stateNext;
    private IDbConnection dbconn;

    private DisplayUnit GetLineFromDataBase() {
        IDbCommand dbcmd = dbconn.CreateCommand();
        int id = (int)(UnityEngine.Random.value * 1000) % (2) + 1;
        string sqlQuery = "SELECT line, avatarpath, musicpath from colorless where id = " + id.ToString() + ";";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        string line = "";
        string avatarpath = "";
        string musicpath = "";
        while (reader.Read()) {
            line = reader.GetString(0);
            avatarpath = reader.GetString(1);
            musicpath = reader.GetString(2);
            Debug.Log("line= " + line + "  avatarpath =" + avatarpath + "  musicpath =" + musicpath);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;

        DisplayUnit ret = new DisplayUnit {
            line = line,
            avatar = avatarpath,
            music = musicpath
        };
        return ret;
    }

    // Use this for initialization
    void Start () {
        string conn = "URI=file:" + Application.dataPath + "/DataBase/test.db";
        Debug.Log(conn);
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
    }

// Update is called once per frame
    void Update () {
        DisplayUnit dpu = GetLineFromDataBase();
    }
}
