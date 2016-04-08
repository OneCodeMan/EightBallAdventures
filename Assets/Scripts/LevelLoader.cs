using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadStage()
    {
        int i = Application.loadedLevel;
        Application.LoadLevel(i + 1);
    }

    public void StartAgain()
    {
        Application.LoadLevel(0);
    }
}
