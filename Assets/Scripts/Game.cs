using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public bool Button1;
    public bool Switch1;
    public bool Switch2;
    public bool Switch3;

    GameObject Btn1;
    GameObject St1;
    GameObject St2;
    GameObject St3;

    public GameObject Door1;
    public GameObject Door2;
    public GameObject Door3;
    public GameObject Door4;

    public GameObject Panel_GO;
    public GameObject Panel2_GO;

    public float _FA;
    public string _N;

    public GameObject ExitDoor;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        _FA = GameObject.Find("Player").GetComponent<VRGaze>().imgGaze.fillAmount;
        _N = GameObject.Find("Player").GetComponent<VRGaze>().mName;

        if (_FA == 1 && _N == "Door10")
        {
            GameOver();
        }

            Btn1 = GameObject.Find("Button(Clone)");
        St1 = GameObject.Find("Switch1(Clone)");
        St2 = GameObject.Find("Switch2(Clone)");
        St3 = GameObject.Find("Switch3(Clone)");

        Button1 = Btn1.GetComponent<myButton>().pressed1;
        Switch1 = St1.GetComponent<Switch2>().pressed1;
        Switch2 = St2.GetComponent<Switch2>().pressed1;
        Switch3 = St3.GetComponent<Switch2>().pressed1;

        if (Switch1)
        {
            Door1.GetComponent<Event6>().enabled = true;
        } else
        {
            Door1.GetComponent<Event6>().enabled = false;
        }

        if (Button1)
        {
            Door2.GetComponent<Event6>().enabled = true;
        } else {
            Door2.GetComponent<Event6>().enabled = false;
        }

        if (Switch3)
        {
            Door3.GetComponent<Event6>().enabled = true;
        }
        else
        {
            Door3.GetComponent<Event6>().enabled = false;
        }

        if (Switch2)
        {
            Door4.GetComponent<Event6>().enabled = true;
            ExitDoor.SetActive(true);
        } else
        {
            Door4.GetComponent<Event6>().enabled = false;
            ExitDoor.SetActive(false);
        }

    }

    public void GameOver()
    { 
   
            Panel_GO.SetActive(true);
        Panel2_GO.SetActive(true);
            Time.timeScale = 0;
     
    }
}
