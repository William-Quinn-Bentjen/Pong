using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int playerNumber = 1;
    public float SprintMultiplyer = 1.5f;
    public float MoveStrength = 1;
    private string hor
    {
        get
        {
            if (playerNumber == 2)
            {
                return "2Horizontal";
            }
            return "Horizontal";
        }
    }
    private string vert
    {
        get
        {
            if (playerNumber == 2)
            {
                return "2Vertical";
            }
            return "Vertical";
        }
    }
    private string sprint
    {
        get
        {
            if (playerNumber == 2)
            {
                return "2Sprint";
            }
            return "Sprint";
        }
    }
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate()
    {
        //movement
        Vector3 force = new Vector3();
        force.y = Input.GetAxis(vert);
        force.x = Input.GetAxis(hor);
        if (Input.GetButton(sprint) && GameManager.Settings.EnableSprint)
        {
            force *= SprintMultiplyer;
        }
        force *= MoveStrength;
        rb.AddForce(force, ForceMode.Impulse);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
