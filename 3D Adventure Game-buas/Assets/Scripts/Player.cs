using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] public CameraFollow cameraScript;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Rigidbody rig;

    [SerializeField] private int score;
    [SerializeField] private UI ui;

    [SerializeField] private bool isTwoDimensional;


    void Update()
    {
        if (isTwoDimensional == true)
        {
            float x = Input.GetAxis("Vertical") * -moveSpeed;
            float z = Input.GetAxis("Horizontal") * moveSpeed;
            rig.velocity = new Vector3(x, rig.velocity.y, z);
        }
        else
        {
            float x = Input.GetAxis("Horizontal") * moveSpeed;
            float z = Input.GetAxis("Vertical") * moveSpeed;
            rig.velocity = new Vector3(x, rig.velocity.y, z);
        }

        Vector3 vel = rig.velocity;
        vel.y = 0;

        if (vel.x != 0 || vel.z !=0)
        {
            transform.forward = vel;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (transform.position.y < -10)
        {
            GameOver();
        }

        //temp
        if (isTwoDimensional == true)
        {
            cameraScript.offset = new Vector3(5, 2.5f, 0);
        }
        else
        {
            cameraScript.offset = new Vector3(0, 2.5f, -4);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        ui.SetScore(score);
    }
}
