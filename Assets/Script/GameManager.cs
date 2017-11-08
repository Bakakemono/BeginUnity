using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private int PlayerLifes = 3;
    private int EnemiLifes = 3;


    [SerializeField]
    private GameObject Enemi;


    [SerializeField]
    private Text textLifes;

    private const string TEXT_LIFES = "Life : ";

	// Use this for initialization
	void Start () {
        textLifes.text = TEXT_LIFES + PlayerLifes;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayerDie()
    {
        PlayerLifes--;
        if (PlayerLifes <=0)
        {
            SceneManager.LoadScene("DieMenu");
        }
        else
        {
            textLifes.text = TEXT_LIFES + PlayerLifes;
        }
    }

    public void EnemiDie()
    {
        EnemiLifes--;
        if (EnemiLifes <= 0)
        {
            Destroy(Enemi);
            SceneManager.LoadScene("WinMenu");
        }
        
    }
    public void TakeHeart()
    {
        PlayerLifes++;
        textLifes.text = TEXT_LIFES + PlayerLifes;
    }
}
