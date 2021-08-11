using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDuckGenerator : MonoBehaviour
{
    [SerializeField]
    Sprite[] ducks;

    SpriteRenderer _rend;

    // Start is called before the first frame update
    void Awake()
    {
        _rend = GetComponent<SpriteRenderer>();
        GenerateDuck();
    }

    public void LoadDucks()
    {
        object[] loadedIcons = Resources.LoadAll("RandomDucks", typeof(Sprite));
        ducks = new Sprite[loadedIcons.Length];
        //this
        for (int x = 0; x < loadedIcons.Length; x++)
        {
            ducks[x] = (Sprite)loadedIcons[x];
        }
    }
    public void GenerateDuck()
    {
        _rend.sprite = ducks[Random.Range(0, ducks.Length-1)];
    }
}
