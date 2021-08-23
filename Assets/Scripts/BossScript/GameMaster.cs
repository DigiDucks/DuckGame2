using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject Rect1;
    [SerializeField] private GameObject Rect2;
    [SerializeField] private float dis;
    private bool DidWin = false;

    [SerializeField] private Transform Border1;
    [SerializeField] private Transform Border2;

    [SerializeField] private Text timertext;
    private float timer = 10f;


    // Start is called before the first frame update
    void Start()
    {
        target.transform.position = inWorldSpace();
        Rect1.transform.position = inWorldSpace();
        Rect2.transform.position = inWorldSpace();
    }

    Vector3 inWorldSpace()
	{
        return new Vector3(Random.Range(Border1.position.x, Border2.position.x), Random.Range(Border1.position.y, Border2.position.y), 0);
	}

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        //print(Vector3.Distance(Rect1.transform.position, Rect2.transform.position));
        timertext.text = timer.ToString();

        if(timer <= 0.0f)
		{
            LoseGame();

        }

        if(
              Vector3.Distance(Rect1.transform.position, Rect2.transform.position) < dis
           && Vector3.Distance(Rect1.transform.position, target.transform.position) < dis
           && Vector3.Distance(target.transform.position, Rect2.transform.position) < dis
            )
		{
            if(!DidWin)
                WinGame();
		}
    }

    void LoseGame()
	{

	}

    void WinGame()
	{
        print("WIN");
        DidWin = true;
	}
}
