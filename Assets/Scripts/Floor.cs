using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Floor : MonoBehaviour
{
    GameObject Player;
    string _mName;

    float _fillAmount;
    AudioSource asource;

    public bool isMoving;

    public float speed;
    void Start()
    {
        Player = GameObject.Find("Player");
        asource = gameObject.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        _fillAmount = Player.GetComponent<VRGaze>().imgGaze.fillAmount;
        _mName = Player.GetComponent<VRGaze>().mName;


        if (_fillAmount == 1 && _mName == gameObject.transform.name)
        {
            isMoving = true;
            //Reproduce Audio
            Player.GetComponent<VRGaze>().PlayAudio();
            MovePlayer();
        }


    }

    void MovePlayer()
    {
        if (isMoving)
        {
            Vector3 pos = Player.GetComponent<VRGaze>().objPos;
            Vector3 dir = new Vector3(pos.x, Player.transform.position.y, pos.z);

            Debug.DrawLine(Player.transform.position, pos, Color.red);


            Player.transform.position = Vector3.MoveTowards(Player.transform.position, dir, speed * Time.deltaTime); 
            
        }
    }

    public void NotMoving()
    {
        isMoving = false;
    }
}
