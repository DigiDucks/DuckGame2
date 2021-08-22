using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckOrbi : MonoBehaviour
{

    public float rotateSpeed = 10f;

    [SerializeField]
    int orientation = 0;

    [SerializeField]
    float direction = 0;

    // Start is called before the first frame update
    void Start()
    { 
        if (orientation < 0)
        orientation = Random.Range(0, 3);

        if (direction == 0)
           direction =  Random.Range(0, 2) > 0 ? 1 : -1; 
    }

    // Update is called once per frame
    void Update()
    {
        switch(orientation)
        {
            case 0: 
            transform.Rotate(rotateSpeed * Time.deltaTime *direction, 0, 0);
                break;

            case 1:
            transform.Rotate(0, rotateSpeed * Time.deltaTime * direction, 0);
                break;

            case 2:
                transform.Rotate(0,0, rotateSpeed * Time.deltaTime * direction);
                break;

        }
    }
}
