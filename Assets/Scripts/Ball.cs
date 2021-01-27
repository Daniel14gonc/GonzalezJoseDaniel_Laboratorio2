using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public float force = 5.0f;
    Rigidbody rb;
    float positionY;
    



    static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreManager.setScore(score);
        rb = GetComponent<Rigidbody>();
        positionY = rb.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (rb)
        {
            if(Input.GetKeyDown(KeyCode.Space) && (Mathf.Abs(rb.velocity.y) <= 0.05f))
                rb.AddForce(0, force, 0, ForceMode.Impulse); 
        }
    }

    private void FixedUpdate()
    {
        if (rb)
            rb.AddForce(Input.GetAxis("Horizontal")*force, 0, Input.GetAxis("Vertical")*force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            if(score < 6)
            {
                score = 0;
                ScoreManager.setScore(score);
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Gem"))
        {
            score++;
            ScoreManager.setScore(score);
            other.gameObject.SetActive(false);
        }
    }

}
