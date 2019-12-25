using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        	
	}
	
	// Update is called once per frame
	void Update ()
    {
        	
	}

    public void jogar()
    {
         SceneManager.LoadScene("Play");
    }
}
