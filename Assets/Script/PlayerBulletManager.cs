using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletManager : MonoBehaviour {

    [SerializeField]
    private GameObject BulletPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemiH")
        {
            Destroy(BulletPrefab);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(BulletPrefab);
    }
  
}
