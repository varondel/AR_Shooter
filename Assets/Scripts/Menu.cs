using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
	}

    public void OnPlay()
    {
        SceneManager.LoadScene("Shooter");
    }

    public void OnExit()
    {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
