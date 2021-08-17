using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //singleton object

    public int lives = 3;
    public int score = 0;

    public int currentLevel = 1; 
    int lastLevel= 0;

    public int pointGoal = 5;

   // AudioSource musicPlayer;


    [SerializeField]
    List<int> levelIndexes = new List<int>();
    List<int> playedGames = new List<int>();

    [SerializeField]
    AudioClip[] clips;

    [SerializeField]
    bool debugging = false;

    //Awake is called when the object is activated, before when the scene is loaded
    private void Awake()
    {

        ///Checks to see if there is already a GameManager in Scene
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        for (int index = 4; index < SceneManager.sceneCountInBuildSettings; index++ )
        { 
            levelIndexes.Add(index);
        }

        //musicPlayer = GetComponent<AudioSource>();

        if (debugging)
        {
            StartCoroutine(RulesDropDown());
        }
    }

    private void Update()
    {

    }

    public IEnumerator BeginTransission()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Transition");
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(PullLevel());
        StartCoroutine(RulesDropDown());
    }

    int PullLevel()
    {
        //If all the levels have been played, shuffle the order and play em again

        if (levelIndexes.Count <= 0)
        {
            Shuffle();
        }
        

       int nextLevel = RandomLevel();

        if(nextLevel == lastLevel)
        {
            nextLevel = RandomLevel();
        }
        playedGames.Add(nextLevel);
        levelIndexes.Remove(nextLevel);
        //Debug.Log(levelIndexes.Count);
        lastLevel = nextLevel;

        return nextLevel;
    }

    void Shuffle()
    {
        Debug.Log("Shuffled");
        if (playedGames.Count != 0)
        {
            foreach (int num in playedGames)
            {
                levelIndexes.Add(num);
            }
        }
        playedGames = new List<int>();
        for (int i = 0; i < levelIndexes.Count - 1; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, levelIndexes.Count);
            int tempNum = levelIndexes[randomIndex];
            levelIndexes[randomIndex] = levelIndexes[i];
            levelIndexes[i] = tempNum;
        }
    }

    int RandomLevel()
    {
        int pulledIndex = UnityEngine.Random.Range(0, levelIndexes.Count - 1);
        return levelIndexes[pulledIndex];
    }


    public void Won()
    {
        score++;
        Debug.Log("Won");
        //musicPlayer.PlayOneShot(clips[0]);
        StartCoroutine(BeginTransission());
    }

    public void Lost()
    {
        lives--;
        if (lives > 0)
        {
            Debug.Log("Lost");
            //musicPlayer.PlayOneShot(clips[1]);
            StartCoroutine(BeginTransission());
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    public void MainMenu()
    {
        lives = 3;
        score = 0;
        currentLevel = 1;

        SceneManager.LoadScene("TitleScreen");

    }


    public IEnumerator RulesDropDown()
    {
        yield return new WaitForSeconds(0.05f);
        GameObject rules = GameObject.FindGameObjectWithTag("UI");
        if (rules != null)
        {
            rules.GetComponent<Animator>().Play("RulesDropDown");
        }
        yield return new WaitForSeconds(0.5f);
        if (FindObjectOfType<GameTemplate>() != null) FindObjectOfType<GameTemplate>().Begin();
        yield return new WaitForSeconds(3f);
        rules.SetActive(false);
    }



}
