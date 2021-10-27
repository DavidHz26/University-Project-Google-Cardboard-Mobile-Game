using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    bool onSight;
    public bool pressed1;

    GameObject Player;
    float _fillAmount;
    string _mName;

    bool isLocked;

    public Animator anim;

    AudioSource AS;

    bool playA = false;

    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Player");
        _fillAmount = Player.GetComponent<VRGaze>().imgGaze.fillAmount;
        _mName = Player.GetComponent<VRGaze>().mName;

        if (_fillAmount == 1 && _mName == gameObject.transform.name)
        {
            onSight = true;
            if (!playA)
            {
                AS.PlayOneShot(AS.clip);
                playA = true;
            }
            ChangeColor();
        }

    }

    void ChangeColor()
    {
        if (onSight && !pressed1 && !isLocked)
        {
            anim.SetBool("Pressed", true);
            pressed1 = true;
            isLocked = true;

        }
        else if (onSight && pressed1 && !isLocked)
        {
            anim.SetBool("Pressed", false);
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
