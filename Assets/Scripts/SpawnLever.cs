using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLever : MonoBehaviour
{
    public GameObject ItemPrefab;

    public GameObject PrefabSpawn;

    public List<GameObject> Positions;

    GameObject[] Points;

    int numRandom;

    public int numPos;
    // Start is called before the first frame update
    void Start()
    {
        int temp = PrefabSpawn.transform.childCount;

        Points = new GameObject[temp];

        for (int i = 0; i <= temp - 1; i++)
        {
            Points[i] = PrefabSpawn.transform.GetChild(i).gameObject;
        }

        //for (int j = 0; j <= Positions.Count; j++)
        //{
        //    Positions[j] = PrefabLevPos.transform.GetChild(j).gameObject;
        //}

        numRandom = Random.Range(0, temp);
        numPos = Random.Range(0, Positions.Count / 2);

        GameObject Item = Instantiate(ItemPrefab);
        Item.transform.position = Points[numRandom].transform.position;

        if (numPos == 0)
        {
            Debug.Log("0");
            Item.GetComponent<Event4>().pos1 = Positions[0];
            Item.GetComponent<Event4>().pos2 = Positions[1];
        }

        if(numPos == 1)
        {
            Debug.Log("1");
            Item.GetComponent<Event4>().pos1 = Positions[2];
            Item.GetComponent<Event4>().pos2 = Positions[3];
        }

        if (numPos == 2)
        {
            Item.GetComponent<Event4>().pos1 = Positions[4];
            Item.GetComponent<Event4>().pos2 = Positions[5];
        }


    }
}
