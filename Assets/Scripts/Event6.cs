using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class Event6 : MonoBehaviour
{
    public Transform Pivot;
    public float rSpeed;

    public bool isOpen;
    public bool locked;

    GameObject Player;
    float _fillAmount;
    string _mName;

    Vector3 myPos;

    Animator anim;

    AudioSource AS;
    public AudioClip openDoor;
    public AudioClip closeDoor;

    private void Start()
    {
        myPos = gameObject.transform.position;
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
            MoveDoor();
        }
    }

    void MoveDoor()
    {
        if (!isOpen && !locked)
        {
            isOpen = true;
            locked = true;
            AS.clip = openDoor;
            AS.PlayOneShot(AS.clip);
            anim.SetBool("Open", true);
            //gameObject.transform.RotateAround(Pivot.transform.position, new Vector3(0f, 1f, 0f), -90);


        }
        else if (isOpen && !locked)
        {
            isOpen = false;
            locked = true;
            AS.clip = closeDoor;
            AS.PlayOneShot(AS.clip);
            anim.SetBool("Open", false);
            //gameObject.transform.RotateAround(Pivot.transform.position, new Vector3(0f, 1f, 0f), 90);


        }
    }

    public void dOpen()
    {
        locked = false;

    }
}
