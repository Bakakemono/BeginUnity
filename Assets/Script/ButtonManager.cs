using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    [SerializeField]
    private Button button;

    // Use this for initialization
    void Start () {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(nextScene);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void nextScene()
    {
        SceneManager.LoadScene("Platform");
    }
}
