using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    public BallManager Ball;
    public Text text;
    public float TotalTime;
    public float TimeLeft;
    // Use this for initialization
    void Start () {

		if (GameManager.Settings.EnableTimeLimit && GameManager.Settings.TimeLimit > 0)
        {
            TotalTime = GameManager.Settings.TimeLimit;
            TimeLeft = TotalTime;
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0)
        {
            if (Ball.P1Score > Ball.P2Score)
            {
                GameManager.Winner = 1;
            }
            else if (Ball.P1Score < Ball.P2Score)
            {
                GameManager.Winner = 2;
            }
            else
            {
                GameManager.Winner = 0;
            }
            SceneManager.LoadScene("Win");
        }
        else
        {
            text.text = TimeLeft.ToString();
        }
	}
}
