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

    private List<GameObject> robotList = new List<GameObject>();

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
        InvokeRepeating("Spawn", 1, 2f);
	}
	
	// Update is called once per frame
	void Update () {
	}

    // Enemies spawning
    private void Spawn()
    {
        float r = Random.Range(minSpawnRange, maxSpawnRange);
        float teta = Random.Range(0, 2 * Mathf.PI);
        float height = Random.Range(-5, 5);

        GameObject robotInstance = Instantiate(robotPrefanb);
        AddRobot(robotInstance);

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

    public void AddRobot(GameObject robot)
    {
        robotList.Add(robot);
        Debug.Log(robotList.Count);

        // Play sound of first robot
        if (robotList.Count == 1)
        {
            robotList[0].GetComponent<AudioSource>().Play();
        }
    }

    public void RemoveRobot(GameObject robot)
    {
        if (robotList.Count == 0)
            return;

        // Play sound on next root if first one was destroyed
        if (robotList[0] == robot && robotList.Count > 1)
            robotList[1].GetComponent<AudioSource>().Play();

        robotList.Remove(robot);
        Destroy(robot);
        
    }
}
