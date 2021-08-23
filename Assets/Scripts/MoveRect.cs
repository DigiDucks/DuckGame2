using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRect : MonoBehaviour
{
    Vector3 movVec;
    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private bool usingArrows;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movVec = Vector3.zero;

        if(usingArrows)
		{
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movVec.x = -1 * moveSpeed;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                movVec.x = 1 * moveSpeed;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                movVec.y = -1 * moveSpeed;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                movVec.y = 1 * moveSpeed;
            }
        }
        else
		{
            if (Input.GetKey(KeyCode.A))
            {
                movVec.x = -1 * moveSpeed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                movVec.x = 1 * moveSpeed;
            }

            if (Input.GetKey(KeyCode.S))
            {
                movVec.y = -1 * moveSpeed;
            }

            if (Input.GetKey(KeyCode.W))
            {
                movVec.y = 1 * moveSpeed;
            }
        }

        this.transform.position += movVec;
    }
}
