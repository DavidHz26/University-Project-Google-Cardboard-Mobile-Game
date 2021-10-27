using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myButton : MonoBehaviour
{
    bool onSight;
    public bool pressed1;

    GameObject Player;
    float _fillAmount;
    string _mName;

    bool isLocked;

    public Animator anim;

    AudioSource AS;
    bool playA;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        AS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Player");
        _fillAmount = Player.GetComponent<VRGaze>().imgGaze.fillAmount;
        _mName = Player.GetComponent<VRGaze>().mName;

        if (_fillAmount == 1 && _mName == gameObject.transform.name)
        {
            if (!playA)
            {
                AS.PlayOneShot(AS.clip);
                playA = true;
            }
            onSight = true;
            ChangeColor();
        }
        
    } 

    void ChangeColor()
    {
        if (onSight && !pressed1 && !isLocked)
        {
            anim.SetTrigger("Pressed");
            pressed1 = true;
            isLocked = true;

        }
        else if (onSight && pressed1 && !isLocked)
        {
            anim.SetTrigger("Pressed");
            pressed1 = false;
            isLocked = true;

        }
    }

    public void LockON()
    {
        isLocked = true;
    }
    
    public void LockOFF()
    {
        isLocked = false;
        playA = false;
    }

}

