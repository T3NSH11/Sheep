using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepPen : MonoBehaviour
{
    GameObject[] AllSheep;
    public List<GameObject> EnteredSheep;
    public int NumOfSheepLeft;
    void Start()
    {
        AllSheep = GameObject.FindGameObjectsWithTag("Sheep");
        NumOfSheepLeft = AllSheep.Length;
    }

    void Update()
    {
        if(NumOfSheepLeft == 0)
        {
            Debug.Log("Win");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sheep")
        {
            EnteredSheep.Add(other.gameObject);
            NumOfSheepLeft--;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sheep")
        {
            EnteredSheep.Remove(other.gameObject);
            NumOfSheepLeft++;
        }
    }
}