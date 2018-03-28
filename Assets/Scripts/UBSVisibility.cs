using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OnOffToggle
{
    On,
    Off,
    Toggle
}
public class UBSVisibility : MonoBehaviour
{
    [Tooltip("tells the renderer to be on or off when the object is created\nThis can be used to make objects visible in editor only easly")]
    public bool VisibleAtStart = false;
    //gameobjects renderer
    private Renderer rend;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (VisibleAtStart)
        {
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }
    }

    //set
    public void SetVisibility(OnOffToggle set)
    {
        if (set == OnOffToggle.On)
        {
            rend.enabled = true;
        }
        else if (set == OnOffToggle.Off)
        {
            rend.enabled = false;
        }
        else if (set == OnOffToggle.Toggle)
        {
            rend.enabled = !rend.enabled;
        }
    }

    //get
    public bool GetVisibility()
    {
        return rend.enabled;
    }
}
