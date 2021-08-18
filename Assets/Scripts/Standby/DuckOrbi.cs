using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckOrbi : MonoBehaviour
{

    public float rotateSpeed = 10f;

    bool horizontal = false;
    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0f,2f) >1)
        {
            horizontal = !horizontal;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (horizontal)
        {
            transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
    }
}
