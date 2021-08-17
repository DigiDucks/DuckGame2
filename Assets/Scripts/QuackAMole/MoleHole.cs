using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleHole : MonoBehaviour
{
    Animator _anim;
    Collider2D _col;

    bool Up = false;

    QuackAMoleManager minimangaer;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _col = GetComponent<Collider2D>();
        minimangaer = FindObjectOfType<QuackAMoleManager>();
    }

    //Called when the mouse clicks an attached collider
    private void OnMouseDown()
    {
        Up = false;
        Debug.Log("Bonk");
        minimangaer.Whacked();
        _col.enabled = false;
        _anim.Play("QuackAMole_Bonk");
    }

    public void PopUp( float speed)
    {
        if (!Up)
        {
            _anim.SetFloat("PopSpeed", speed);
            Up = true;
            _anim.Play("QuackAMole_DuckPopUp");
            StartCoroutine(PopDown());
        }
        _col.enabled = true;
    }

    public bool IsUp()
    {
        return Up;
    }

    IEnumerator PopDown()
    {
        yield return new WaitForSeconds(Random.Range(1.25f, 2f));
        if (Up)
        {
            _anim.Play("QuackAMole_DuckPopDown");
            Up = false;
            _col.enabled = false;
        }
    }    
}
