using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using DemoChapter;

namespace DemoLib {

    public class SaveAndLoad : MonoBehaviour {

        static string save_path = Application.dataPath + "/1.sl";

        public int Save() {
            FileStream fs = new FileStream(save_path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            chapterEvent.PlayIndex.ToString();
            sw.Write(chapterEvent.PlayIndex.ToString() + "\n");

            sw.Flush();
            sw.Close();
            fs.Close();
            Debug.Log("writed");
            return 0;
        }

        public int Load() {
            StreamReader objReader = new StreamReader(save_path);
            string sLine = "";
            ArrayList LineList = new ArrayList();
            while (sLine != null) {
                sLine = objReader.ReadLine();
                if (sLine != null && !sLine.Equals(""))
                    LineList.Add(sLine);
            }
            objReader.Close();
            for (int i = 0; i < LineList.Count; i++) {
                Debug.Log(LineList[i]);
            }
            chapterEvent.PlayIndex = int.Parse(LineList[0].ToString());
            return 0;
        }
    }
}
