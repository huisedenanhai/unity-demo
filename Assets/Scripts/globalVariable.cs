using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

namespace BoxActive { 

public class globalVariable : MonoBehaviour {

        public static bool saveBoxAcive = false;
        public static bool loadBoxAcive = false;
        public static bool LogBoxActive = false;
        public static bool skipTxtOn = false;
        public static bool pointerInButton = false;
        public static bool autoTxtOn = false;
        public static bool autoFrame = false;
        // Use this for initialization
        void Start () {
            saveBoxAcive = false;
            loadBoxAcive = false;
            LogBoxActive = false;
            skipTxtOn = false;
            pointerInButton = false;
            autoTxtOn = false;
            autoFrame = false;
        }
	
	// Update is called once per frame
	void Update () {
		
	}
  }
}