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

    // Use this for initialization
    void Start () {
        center = new Vector2(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(center);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Lasers);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject _go = Instantiate(explosionPrefab, hit.point, Quaternion.identity);
                Destroy(_go, 3);
                Destroy(hit.collider.gameObject);
                GameMgr.Score++;
            }
        }
	}
}
