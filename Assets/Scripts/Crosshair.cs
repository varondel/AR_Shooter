using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour {

    private Vector2 center;
    private Ray ray;
    private RaycastHit hit;

    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private GameMgr GameMgr;

    [SerializeField]
    GameObject Lasers;

    AudioSource audioSource;
    [SerializeField]
    AudioClip laserShoot, destroySound;

    // Use this for initialization
    void Start () {
        center = new Vector2(Screen.width / 2, Screen.height / 2);
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            // Update ray with camera pos
            ray = Camera.main.ScreenPointToRay(center);

            // Laser sound
            audioSource.PlayOneShot(laserShoot);

            // Instantiate and rotate laser with camera
            GameObject goLasers = Instantiate(Lasers);
            goLasers.transform.eulerAngles = Camera.main.transform.eulerAngles;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                audioSource.PlayOneShot(destroySound);
                GameObject _go = Instantiate(explosionPrefab, hit.point, Quaternion.identity);

                // Destroy explosion animation when finished (should be a trigger)
                Destroy(_go, 3);

                // Destroy ennemi target
                GameMgr.RemoveRobot(hit.collider.gameObject);
                
                // Update score
                GameMgr.Score++;
            }
        }
	}
}
