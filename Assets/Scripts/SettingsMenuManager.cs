using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class SettingsMenuManager : MonoBehaviour {
    public InputField ScoreToWin;
    public InputField TimeLimit;
    public Toggle EnableTimeLimit;
    public Toggle GoalEffects;
    public Toggle SprintEnabled;
    public bool Differences()
    {
        //verify data
        int x;
        float a;
        if (!Int32.TryParse(ScoreToWin.text, out x) || !float.TryParse(TimeLimit.text, out a))
        {
            return false;
        }
        if (x != GameManager.Settings.ScoreToWin ||
            a != GameManager.Settings.TimeLimit || 
            GoalEffects.isOn != GameManager.Settings.EnableGoalEffects || 
            EnableTimeLimit.isOn != GameManager.Settings.EnableTimeLimit || 
            SprintEnabled.isOn != GameManager.Settings.EnableSprint)
        {
            return true;
        }
        return false;
    }
    public void ChangeSettings()
    {
        if (Differences())
        GameManager.Settings.ScoreToWin = Int32.Parse(ScoreToWin.text);
        GameManager.Settings.TimeLimit = Int32.Parse(TimeLimit.text);
        GameManager.Settings.EnableGoalEffects = GoalEffects.isOn;
        GameManager.Settings.EnableTimeLimit = EnableTimeLimit.isOn;
        GameManager.Settings.EnableSprint = SprintEnabled.isOn;
    }
    void OnDisable()
    {
        SyncText();
    }
    //void OnAwake()
    //{
    //    SyncText();
    //}
    public void SyncText()
    {
        ScoreToWin.text = GameManager.Settings.ScoreToWin.ToString();
        TimeLimit.text = GameManager.Settings.TimeLimit.ToString();
        EnableTimeLimit.isOn = GameManager.Settings.EnableTimeLimit;
        GoalEffects.isOn = GameManager.Settings.EnableGoalEffects;
        SprintEnabled.isOn = GameManager.Settings.EnableSprint;
    }
    // Use this for initialization
    void Start () {
        SyncText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnDestroy()
    {
        //ChangeSettings();
    }
}
