using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenDuck : MonoBehaviour
{
    RandomDuckGenerator duckGen;
    HNSManager minimanger;
    // Start is called before the first frame update
    void Start()
    {
        duckGen = GetComponent<RandomDuckGenerator>();
        minimanger = FindObjectOfType<HNSManager>();
    }
    private void OnMouseDown()
    {
        if(duckGen)
        {
            Debug.Log("CheckDuck");
            minimanger.CheckDuck(duckGen.GetWhichDuck());
        }
    }
}
