using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject player_runner;
    private bool play_start = false;
    private float jumpForce = 500.0f;
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
    private float speedbytime = 1f;
    private bool waterdrop_trigger = false;
    private float timeCount = 0;
>>>>>>> Stashed changes
=======
    private float speedbytime = 1f;
>>>>>>> main
    // Start is called before the first frame update
    void Start()
    {
        player_runner = GameObject.Find("turtle");
    }

    // Update is called once per frame
    void Update()
    {
        //speedbytime += Time.deltaTime;
        player_runner.GetComponentInChildren<Animator>().SetInteger("player_velocity", (int)player_runner.GetComponent<Rigidbody2D>().velocity.y);
        if (play_start)
        {
            Player_Move();
            Player_Jump();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
                play_start = true;
        }
        //Player_Respawn();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "waterDrop")
        {
            waterdrop_trigger = true;
            Destroy(collision.gameObject);
        }
    }
    void Player_Move()
    {
        player_runner.GetComponentInChildren<Animator>().SetBool("running", true);
<<<<<<< HEAD
<<<<<<< Updated upstream
        //Vector3 moveVelocity = Vector3.zero;
        //if (Input.GetAxisRaw("Horizontal") < 0)
        //{
        //    moveVelocity = Vector3.left;
        //    player_runner.GetComponent<SpriteRenderer>().flipX = true;
        //}
        //else if (Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    moveVelocity = Vector3.right;
        //    player_runner.GetComponent<SpriteRenderer>().flipX = false;
        //}
        //else
        //{
        //    player_runner.GetComponentInChildren<Animator>().SetBool("running", false);
        //}
        //player_runner.transform.position += moveVelocity * moveSpeed * Time.deltaTime;
        grid_transform.position -= Vector3.right * moveSpeed * Time.deltaTime * 0.5f;
=======
        if (waterdrop_trigger)
        {
            timeCount += Time.deltaTime;
            if (timeCount <= 1)
            {
                player_runner.transform.position += Vector3.right * 3f * Time.deltaTime;
                player_runner.GetComponentInChildren<Animator>().SetFloat("animation_speed", 4f);
                player_runner.GetComponentInChildren<Animator>().SetBool("runfast", true);
            }
            else
            {
                player_runner.GetComponentInChildren<Animator>().SetBool("runfast", false);
                waterdrop_trigger = false;
                timeCount = 0;
            }
        }
        else
        {
            player_runner.transform.position += Vector3.right * 0.2f * Time.deltaTime;
            player_runner.GetComponentInChildren<Animator>().SetFloat("animation_speed", 2f);
        }
>>>>>>> Stashed changes
=======
        //player_runner.transform.position += Vector3.right * 0.7f * speedbytime;
        player_runner.transform.position += Vector3.right * 0.75f * Time.deltaTime;
        player_runner.GetComponentInChildren<Animator>().SetFloat("animation_speed", 3f);
       
>>>>>>> main
    }
    void Player_Jump()
    {
        if(player_runner.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                player_runner.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
            }
        }
    }
}
