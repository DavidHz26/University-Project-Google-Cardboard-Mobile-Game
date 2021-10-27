using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VRGaze : MonoBehaviour
{
    public Image imgGaze;
    public Image imgGaze2;

    public float totalTime;
    bool gvrStatus;
    float gvrTimer;

    private RaycastHit _hit;
    [HideInInspector] public string mName;
    public Vector3 objPos;

    AudioSource AS;
    bool playAudio = false;


    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
            imgGaze2.fillAmount = gvrTimer / totalTime;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 05f));

        if (Physics.Raycast(ray, out _hit, 10))
        {
            mName = _hit.collider.name;

            objPos = new Vector3(_hit.collider.gameObject.transform.position.x, 0, _hit.collider.transform.position.z);
        
        } else
        {
            mName = "";
        }
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
        imgGaze2.fillAmount = 0;

        AS.Stop();
        playAudio = false;
    }

    public void PlayAudio()
    {
        if (!playAudio)
        {
            AS.PlayOneShot(AS.clip);
            playAudio = true;
        }
    }
}
