using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour {

    private Vector2 center;
    private Ray ray;
    private RaycastHit hit;

    [SerializeField]
    private Text scoreText;

    private int score;
    public int Score
    {
        get { return score; }
        set {
            score = value;
            scoreText.text = "Score : " + value.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        center = new Vector2(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(center);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Destroy(hit.collider.gameObject);
                Score++;
            }
        }
	}
}
