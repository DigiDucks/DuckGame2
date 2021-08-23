using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuackAMoleManager : MonoBehaviour
{
    static int numbHoles = 8;

    GameManager manager;

    float timer = 15f;

    int goal = 5;
    int whacked = 0;

    bool won = false;

    float multiplier = 1f;


    MoleHole[] holes = new MoleHole[numbHoles];

    float delay = 3f;

    int difficulty = 1; //debug = 1, Easy mode =1 , med = 2, hard =3 
    int pattern = 0;

    int[] easyMode = { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4 };
    int[] medMode = { 1, 1, 1, 3, 3, 3, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
    int[] hardMode = { 1, 1, 3, 3, 3, 3, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4 };



    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
        holes = GameObject.FindObjectsOfType<MoleHole>();

        switch (manager.difficulty)
        {
            case 0:
            case 1:
                multiplier = 1f;
                timer = 20f;
                break;
            case 2:
                multiplier = 1.25f;
                timer = 18f;
                break;
            case 3:
                multiplier = 1.75f;
                timer = 15f;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!won)
        {
            if (delay > 0)
            {
                delay -= Time.deltaTime;
            }
            else
            {
                SwitchDifficulty();

                SwitchPattern();
            }
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            manager.Lost();
        }

    }


    void SwitchDifficulty()
    {
        switch (manager.difficulty)
        {
            case 0:
                pattern = 4;
                break;
            case 1:
                pattern = easyMode[Random.Range(0, easyMode.Length)];
                break;
            case 2:
                pattern = medMode[Random.Range(0, medMode.Length)];
                break;
            case 3:
                pattern = hardMode[Random.Range(0, hardMode.Length)];
                break;
        }
    }

    void SwitchPattern()
    {
        switch (pattern)
        {
            case 1: // single
                Debug.Log("Single");
                PopOne(1f);
                delay = Random.Range(2, 4);
                break;
            case 2: // rapid
                Debug.Log("Rapid");
                StartCoroutine(RapidPop());
                delay = Random.Range(2, 4);
                break;
            case 3: // fake out
                Debug.Log("Fakeout");
                PopOne(3f);
                delay = Random.Range(1, 2);
                break;
            case 4: // all out
                Debug.Log("All Out");
                PopAll();
                delay = Random.Range(3, 5);
                break;
        }
    }

    public void Whacked()
    {
        ++whacked;
        if(whacked >= goal)
        {
            //Win
            Debug.Log("Win");
            won = true;
            GameManager.instance.Won();
        }
    }


    //------------Paterns-----------------------------//
    void PopOne(float speed)
    {
        int pop = Random.Range(0, numbHoles);
        while (holes[pop].IsUp())
        {
            pop = Random.Range(0, numbHoles);
        }
        holes[Random.Range(0, numbHoles)].PopUp(speed * multiplier);
    }
    void PopAll()
    {
        foreach(MoleHole h in holes )
        {
            h.PopUp(Random.Range(1.2f, 2f));
        }
    }

    IEnumerator RapidPop()
    {
        PopOne(1.5f);
        yield return new WaitForSeconds(Random.Range(0.3f, 1.5f));
        PopOne(1f);
    }
}
