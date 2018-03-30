using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class titleController : MonoBehaviour {

    public Canvas title;

    // Use this for initialization
    void Start () {
        //   DisplayUnit dpu = GetLineFromDataBase();
        title.GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update () {
       if(title.GetComponent<CanvasGroup>().alpha!=1) title.GetComponent<CanvasGroup>().alpha += (float) 0.3*Time.deltaTime;
    }
}
