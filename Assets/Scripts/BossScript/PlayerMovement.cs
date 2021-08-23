using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rb;
	[SerializeField] float speed;
	[SerializeField] float drag;
	[SerializeField]
	private float xForce, yForce;

	private bool onGround;

	[SerializeField] private GameObject[] duckHeads;
	[SerializeField] private int duckHP = 5;

	AudioSource flapSound;



	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		flapSound = GetComponent<AudioSource>();

        switch (GameManager.instance.difficulty)
        {
			case 1: duckHP = 5;
				break;
			case 2: duckHP = 4;
				break;
			case 3: duckHP = 3;
				break;
        }
		HealthUpdate();
	}

    // Update is called once per frame
    void Update()
    {
		
		if(duckHP == 0)
		{
			Lost();
		}
    }

	void HealthUpdate()
	{
		int i = 0;
		foreach (GameObject go in duckHeads)
		{
			if(i != duckHP)
			{
				go.SetActive(true);
				i++;
			}
			else
			{
				go.SetActive(false);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("SeagullBlast"))
		{
			duckHP--;
			HealthUpdate();
			Destroy(collision.gameObject);
		}
	}

	private void FixedUpdate()
	{
		if(Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f)
        {
			xForce = speed* Input.GetAxis("Horizontal");
        }else if (xForce != 0)
        {
			float sign = xForce / Mathf.Abs(xForce);
			xForce = (Mathf.Abs(xForce) - drag * Time.deltaTime) *sign;
        }

		if (Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Vertical")< -0.5f)
		{
			yForce = speed * Input.GetAxis("Vertical");
		}
		else if (yForce != 0)
		{
			float sign = yForce / Mathf.Abs(yForce);
			yForce = (Mathf.Abs(yForce) - drag*Time.deltaTime) * sign;
		}

		rb.velocity = new Vector2(xForce * Time.deltaTime, yForce * Time.deltaTime);

		//if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		//{
		//	rb.AddForce(Vector2.up * jumpForce);
		//	flapSound.PlayOneShot(flapSound.clip);
		//}

		//if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		//{
		//	rb.velocity = Vector2.up * fallForce;
		//}
	}

	void Lost()
	{
		FindObjectOfType<GameManager>().Lost();
	}

	
}
