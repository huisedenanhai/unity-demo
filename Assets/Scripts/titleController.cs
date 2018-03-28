using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

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

    private void B()
    {
        string conn = "URI=file:" + Application.dataPath + "/DataBase/test.db";
        Debug.Log(conn);
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        
        

        IDbCommand cmd = dbconn.CreateCommand();
        string sqlInsert = "insert into colorless values (NULL, \"a\", \"b\", \"c\", \"d\", \"e\", \"f\");";
        cmd.CommandText = sqlInsert;
        cmd.ExecuteNonQuery();Debug.Log("test bug3");
        cmd.Dispose();
        cmd = null;
        Debug.Log("test bug2");
        dbconn.Close();
        dbconn = null;
        return;
}

    private void A()
    {
       
    }

    private void C()
    {
        string conn = "URI=file:" + Application.dataPath + "/DataBase/test.db";
        Debug.Log(conn);
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); 

        IDbCommand dbcmd2 = dbconn.CreateCommand();
        string sqlQuery2 = "SELECT line, avatarpath, musicpath from colorless;";
        dbcmd2.CommandText = sqlQuery2;
        IDataReader reader2 = dbcmd2.ExecuteReader();
        string line2 = "";
        string avatarpath2 = "";
        string musicpath2 = "";
        while (reader2.Read())
        {
            line2 = reader2.GetString(0);
            avatarpath2 = reader2.GetString(1);
            musicpath2 = reader2.GetString(2);
            Debug.Log("line2= " + line2 + "  avatarpath2 =" + avatarpath2 + "  musicpath2 =" + musicpath2);
        }
        reader2.Close();
        reader2 = null;
        dbcmd2.Dispose();
        dbcmd2 = null;
        dbconn.Close();
        dbconn = null;

    }



    private DisplayUnit GetLineFromDataBase() {
         DisplayUnit ret = new DisplayUnit {
             line = "",
             avatar = "",
             music = ""
         };
       
        A();B();C();
        return ret;
    }

    // Use this for initialization
    void Start () {
      //   DisplayUnit dpu = GetLineFromDataBase();

    }

    // Update is called once per frame
    void Update () {
        
    }
}
