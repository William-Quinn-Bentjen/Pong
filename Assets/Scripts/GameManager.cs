using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public struct GameSettings
{
    public int ScoreToWin;
    public float TimeLimit;
    public bool EnableTimeLimit;
    public bool EnableGoalEffects;
    public bool EnableSprint;
}
public class GameManager : MonoBehaviour {
    [SerializeField]
    public static GameSettings Settings = new GameSettings { ScoreToWin = 7 , TimeLimit = 0, EnableTimeLimit = false, EnableGoalEffects = true, EnableSprint = true};
    public static int Winner = 0;
    public BallManager Ball;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CheckWin()
    {
        if (Ball.P1Score >= Settings.ScoreToWin)
        {
            Winner = 1;
            LoadScene("Win");
        }
        if (Ball.P2Score >= Settings.ScoreToWin)
        {
            Winner = 2;
            LoadScene("Win");
        }
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
