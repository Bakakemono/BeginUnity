using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiController : MonoBehaviour {
    [SerializeField]
    private Transform[] gunsTransformList;
    [SerializeField]
    private float TimeToFire = 2;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletVelocity = 10;

    private Color colorStart = Color.red;
    private Color colorEnd = Color.green;
    private float flashingTime = 2.1f;
    private Renderer rend;
    private float flashBegin = 1.1f;

    

    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        StartCoroutine(Fire());
        gameManager = FindObjectOfType<GameManager>();
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (flashBegin >= flashingTime)
        {
            float lerp = Mathf.PingPong(Time.time, flashingTime) / flashingTime;
            rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        }
	}

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeToFire);
            foreach (Transform t in gunsTransformList) {
                GameObject bullet = Instantiate(bulletPrefab,t.position,t.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = t.right * bulletVelocity;
                Destroy(bullet, 5);
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BPlayer")
        {
            flashingTime--;
            gameManager.EnemiDie();
        }
    }
}
