using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

    [SerializeField]
    GameObject robotPrefanb;

    GameObject robotInstance;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 0f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Spawn()
    {
        float r = Random.Range(60, 100);
        //r = 10;
        float teta = Random.Range(0, 2 * Mathf.PI);

        robotInstance = Instantiate(robotPrefanb);
        robotInstance.transform.Rotate(new Vector3(0, -90 - teta * 180 / Mathf.PI, 0));
        robotInstance.transform.position = new Vector3(r * Mathf.Cos(teta), 0, r * Mathf.Sin(teta));
    }
}
