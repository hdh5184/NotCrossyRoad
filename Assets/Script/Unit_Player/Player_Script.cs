using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Player_Script : MonoBehaviour
{
    public GameManager gm;

    Rigidbody rg;
    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        //rg.useGravity = new Vector3(0, -19.62f, 0);
    }

  
    // Update is called once per frame
    void Update()
    {
        // if (!isJumping && rg.velocity.y == 0)
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
        {
            rg.velocity = new Vector3(-10, 1.5f, 0);
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isJumping)
        {
            isJumping = true;
            rg.velocity = new Vector3(10, 1.5f, 0);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isJumping)
        {
            isJumping = true;
            rg.velocity = new Vector3(0, 1.5f, -10);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isJumping)
        {
            isJumping = true;
            rg.velocity = new Vector3(0, 1.5f, 10);

        }

        //if (isJumping && rg.velocity.y == 0)
        //   isJumping = false;

    }

    public void OnTriggerEnter(Collider scoreObj)
    {
        if (scoreObj.CompareTag("Score"))
        {
            scoreObj.gameObject.SetActive(false);
            gm.IncreaseScore();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("River") || other.CompareTag("Car"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Boat"))
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("WallLeft")) rg.velocity = new Vector3(0, 0, 2f);
        if (collision.gameObject.CompareTag("WallRight")) rg.velocity = new Vector3(0, 0, -2f);
        if (collision.gameObject.CompareTag("WallBack")) rg.velocity = new Vector3(-2f, 0, 0);

        if (transform.position.x < -176 ) rg.velocity = new Vector3(100f, 20f, 0);


    }
}
