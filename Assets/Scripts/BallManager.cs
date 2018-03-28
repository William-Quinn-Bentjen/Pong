using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour {
    public float GoalDistance = 9.4f;
    public float StartingForce = 7;
    public float MaxVerticleForce = 7;
    public float MinVel = 3;
    public Text Score1;
    private float p1Score;
    public float P1Score
    {
        get
        {
            return p1Score;
        }
        set
        {
            p1Score = value;
            if (manager != null)
            {
                manager.CheckWin();
            }
            Score1.text = value.ToString();
        }
    }
    public Text Score2;
    private float p2Score;
    public float P2Score
    {
        get
        {
            return p2Score;
        }
        set
        {
            p2Score = value;
            if (manager != null)
            {
                manager.CheckWin();
            }
            Score2.text = value.ToString();
        }
    }
    public GameObject GoalEffect;
    private GameManager manager;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        manager = GameObject.FindObjectOfType<GameManager>();
        manager.Ball = GetComponent<BallManager>();
        P1Score = 0;
        P2Score = 0;
        rb = GetComponent<Rigidbody>();
        Collider col = gameObject.GetComponent<Collider>();
        //ignore collision with goal walls (only run when the ball is first spawned so find is ok
        foreach (GameObject goal in GameObject.FindGameObjectsWithTag("Goal"))
        {
            Physics.IgnoreCollision(goal.GetComponent<Collider>(), col);
        }
        ThrowBall();
    }
	// Update is called once per frame
	void FixedUpdate () {
        // try to stop ball from slowing down too much
        if (rb.velocity.magnitude < MinVel)
        {
            rb.velocity = rb.velocity.normalized * MinVel;
        }
        Vector3 pos = gameObject.transform.position;
        //orignially was going to use ontrigger enter but I am worried about it not detecting colision on the goal if the ball is fast enough 
        if (transform.position.x > Mathf.Abs(GoalDistance))
        {
            //goal right
            if (GameManager.Settings.EnableGoalEffects)
            {
                pos.x--;
                Instantiate(GoalEffect, pos, gameObject.transform.rotation);
            }
            Debug.Log("goal");
            P1Score++;
            ThrowBall(Direction.Left);
        }
        if (transform.position.x < -Mathf.Abs(GoalDistance))
        {
            //goal left
            if (GameManager.Settings.EnableGoalEffects)
            {
                pos.x++;
                Instantiate(GoalEffect, pos, gameObject.transform.rotation);
            }
            Debug.Log("goal");
            P2Score++;
            ThrowBall(Direction.Right);
        }
	}
    enum Direction
    {
        Random,
        Left,
        Right
    }
    void ThrowBall(Direction dir = Direction.Random)
    {
        transform.position = new Vector3(0, 0, 0);
        Vector3 force = new Vector3(StartingForce, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        if (dir == Direction.Random)
        {
            if (Random.Range(0, 2) == 0)
            {
                dir = Direction.Left;
            }
            else
            {
                dir = Direction.Right;
            }
        }
        if (dir == Direction.Left)
        {
            StartingForce *= -1;
        }
        force.y = Random.Range(0, MaxVerticleForce);
        if (Random.Range(0,2) == 0)
        {
            force.y *= -1;
        }
        rb.AddForce(force, ForceMode.Impulse);
    }
}
