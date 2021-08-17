using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDuckGenerator : MonoBehaviour
{
    [SerializeField]
    Sprite[] ducks;

    [SerializeField]
    int duckNumber = -1;

    [SerializeField]
    bool randomX = false;

    SpriteRenderer _rend;

    // Start is called before the first frame update
    void Awake()
    {
        _rend = GetComponent<SpriteRenderer>();
        LoadDucks();
        GenerateDuck();
    }

    void LoadDucks()
    {
        object[] loadedIcons = Resources.LoadAll("RandomDucks", typeof(Sprite));
        ducks = new Sprite[loadedIcons.Length];
        //this
        for (int x = 0; x < loadedIcons.Length; x++)
        {
            ducks[x] = (Sprite)loadedIcons[x];
        }
    }
    public int GenerateDuck()
    {
       int index = Random.Range(0, ducks.Length - 1);
        _rend.sprite = ducks[index];
        if(randomX)
        {
            RandomDirection();
        }
        duckNumber = index;
        return index;
    }

    void RandomDirection()
    {
        if (Random.Range(0, 4) >= 2)
            _rend.flipX = !_rend.flipX;
    }

    public int GetWhichDuck()
    {
        return duckNumber;
    }
}
