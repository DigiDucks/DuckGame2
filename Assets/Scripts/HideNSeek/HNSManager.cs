using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HNSManager : MonoBehaviour
{
    Sprite[] duckPics;

    [SerializeField]
    SpriteRenderer FindDuckSprite;

    [SerializeField]
    RandomDuckGenerator[] ducksInScene;

    DuckOrbi[] spinners;

    [SerializeField]
    int duck2Find = -1;

    // Start is called before the first frame update
    void Start()
    {
        LoadDucks();
        ducksInScene = FindObjectsOfType<RandomDuckGenerator>();
        if (GameManager.instance.difficulty > 1)
        {
            spinners = FindObjectsOfType<DuckOrbi>();
            int randNum = Random.Range(0, spinners.Length);
            for(int i = 0; i<= randNum; ++i)
            {
                spinners[Random.Range(0, spinners.Length)].rotateSpeed = Random.Range(10f, 50f);
            }
            if(GameManager.instance.difficulty >2)
            {
                for (int i = 0; i <= randNum; ++i)
                {
                    spinners[Random.Range(0, spinners.Length)].rotateSpeed = Random.Range(20f, 60f);
                }
            }
        }

        duck2Find = ducksInScene[Random.Range(0, ducksInScene.Length)].GetWhichDuck();
        if(FindDuckSprite)
        {
            FindDuckSprite.sprite = duckPics[duck2Find];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckDuck(int foundDuck)
    {
        if(foundDuck == duck2Find)
        {
            Debug.Log("Win");
            //Win Game
            GameManager.instance.Won();
        }
    }

    void LoadDucks()
    {
        object[] loadedIcons = Resources.LoadAll("RandomDucks", typeof(Sprite));
        duckPics = new Sprite[loadedIcons.Length];
        //this
        for (int x = 0; x < loadedIcons.Length; x++)
        {
            duckPics[x] = (Sprite)loadedIcons[x];
        }
    }
}
