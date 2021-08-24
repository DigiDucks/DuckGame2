using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandbyManager : MonoBehaviour
{
    int misses = 0;
    float timer = 10f;
    bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(10f, 16f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.anyKey)
            ++misses;

        if (misses > 3)
            GameManager.instance.Lost();
        if(timer <= 0 && !won)
        {
            GameManager.instance.Won();
            won = true;
        }
    }
}
