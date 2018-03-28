using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
        if (GameManager.Winner == 0)
        {
            text.text = "Tie";
        }
        else
        {
            text.text = "Winner Player " + GameManager.Winner;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
