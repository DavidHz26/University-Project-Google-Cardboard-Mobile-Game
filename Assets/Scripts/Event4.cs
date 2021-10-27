using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event4 : MonoBehaviour
{
    public bool isActive;

    public GameObject pos1;
    public GameObject pos2;

    GameObject Player;
    float _fillAmount;
    string _mName;

    public bool isLocked;

    void Start()
    {
        if (pos1 != null) 
        gameObject.transform.position = pos1.transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Player");
        _fillAmount = Player.GetComponent<VRGaze>().imgGaze.fillAmount;
        _mName = Player.GetComponent<VRGaze>().mName;

        if (_fillAmount == 1 && _mName == gameObject.transform.name)
        {
            ChangePos();
        }
      
    }

    void ChangePos()
    {
        if (!isActive && !isLocked) { 
            gameObject.transform.position = pos2.transform.position;
            isActive = true;
            isLocked = true;
        }

        else if(isActive && !isLocked)
        {
            gameObject.transform.position = pos1.transform.position;
            isActive = false;
            isLocked = true;
        }
    }

    public void NotActive()
    {
        isLocked = false;
    }
    
}
