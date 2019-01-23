using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {

    [SerializeField]
    GameObject robotPrefanb;

    [SerializeField]
    GameObject loseScreen;

    GameObject robotInstance;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text bestScoreText;

    [SerializeField]
    Transform cameraTransform;

    [SerializeField]
    float minSpawnRange, maxSpawnRange;

    private int bestScore;
    public int BestScore
    {
        get { return bestScore; }
        set
        {
            bestScore = value;
            bestScoreText.text = "Best : " + value.ToString();
        }
    }

    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = "Score : " + value.ToString();
            if (score > BestScore)
            {
                BestScore = score;
            }
        }
    }

    // Use this for initialization
    void Start () {

        // Recover Best score
        BestScore = PlayerPrefs.HasKey("Best") ? PlayerPrefs.GetInt("Best") : 0;

        // Enemies spawn
        InvokeRepeating("Spawn", 0f, 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
	}

    // Enemies spawning
    private void Spawn()
    {
        float r = Random.Range(35, 40);
        float teta = Random.Range(0, 2 * Mathf.PI);
        float height = Random.Range(-5, 5);

        robotInstance = Instantiate(robotPrefanb);
        robotInstance.transform.position = new Vector3(r * Mathf.Cos(teta), height, r * Mathf.Sin(teta));
        robotInstance.transform.LookAt(this.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        loseScreen.SetActive(true);
        IEnumerator waitForMenu = WaitForMenu(2.5f);
        StartCoroutine(waitForMenu);

        //Save best score
        if (!PlayerPrefs.HasKey("Best") || PlayerPrefs.GetInt("Best") < BestScore)
            PlayerPrefs.SetInt("Best", BestScore);
    }

    private IEnumerator WaitForMenu(float seconds)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(seconds);
        
        SceneManager.LoadScene("Menu");
    }
}
