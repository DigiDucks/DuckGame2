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

    [SerializeField]
    int duck2Find = -1;

    // Start is called before the first frame update
    void Start()
    {
        LoadDucks();
        ducksInScene = FindObjectsOfType<RandomDuckGenerator>();

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
