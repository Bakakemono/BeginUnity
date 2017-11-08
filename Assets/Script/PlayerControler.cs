using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    [Header("Physics")]
    [SerializeField]
    private float force = 10;
    [Header("Jump")]
    [SerializeField]
    private Transform positionRaycastJump;
    [SerializeField]
    private float radiusRaycastJump;
    [SerializeField]
    private LayerMask layerMaskJump;
    [SerializeField]
    private float forceJump = 5;
    [Header("Frie gun super sonic lol boom")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gunTransform;
    [SerializeField]
    private float bulletVelocity = 2;
    [SerializeField]
    private float timeToFire = 2;
    private float lastTimeFire = 0;

    [SerializeField]
    private GameObject Heart;


    private Transform spawnTranform;

    private Rigidbody2D rigid;

    private GameManager gameManager;
    

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        spawnTranform = GameObject.Find("Spawn").transform;
        gameManager = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 forceDirection = new Vector2(horizontalInput,0);
        forceDirection *= force;
        rigid.AddForce(forceDirection);

        bool touchFloor = Physics2D.OverlapCircle(positionRaycastJump.position, radiusRaycastJump, layerMaskJump);

        if(Input.GetAxis("Jump")>0 && touchFloor)
        {
            rigid.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
        }
        if (Input.GetAxis("Fire1")>0)
        {
            Fire();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Limit")
        {
            transform.position = spawnTranform.position;
            gameManager.PlayerDie();
        }
        if (collision.tag == "Heart")
        {
            Destroy(Heart);
            gameManager.TakeHeart();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BEnemi")
        {
            gameManager.PlayerDie();
        }
    }


    private void Fire()
    {
        if (Time.realtimeSinceStartup - lastTimeFire > timeToFire)
        {
            GameObject Bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
            Bullet.GetComponent<Rigidbody2D>().velocity = gunTransform.right * bulletVelocity;
            Destroy(Bullet, 5);
            lastTimeFire = Time.realtimeSinceStartup;
        }
    }
}
