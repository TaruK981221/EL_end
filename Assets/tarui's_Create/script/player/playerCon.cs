using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCon : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    bool isFlg = false;

    [SerializeField]
    float JumpPower = 5.0f;

    bool isBound = false;
    float BoundTimeLimit = 0.5f;
    float BoundTime = 0.0f;

    //bool is

    public int HP = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isBound)
        {
            if (BoundTime < BoundTimeLimit)
            {
                BoundTime += Time.deltaTime;
            }
            else
            {
                BoundTime = 0.0f;
                isBound = false;
            }
        }
        else
        {
            if (isFlg)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.velocity = new Vector3(Vector3.left.x * 1.0f, rb.velocity.y, 0);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    rb.velocity = new Vector3(Vector3.right.x * 1.0f, rb.velocity.y, 0);
                }
                else
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb.velocity += Vector3.up * JumpPower;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    rb.velocity = new Vector3(Vector3.left.x * 1.0f, rb.velocity.y, 0);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    rb.velocity = new Vector3(Vector3.right.x * 1.0f, rb.velocity.y, 0);
                }
                else
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    rb.velocity += Vector3.up * JumpPower;
                }
            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag== "Player")
    //    {
    //        rb.velocity = Vector3.zero;

    //        if (collision.transform.position.x < transform.position.x)
    //        {
    //            rb.velocity += new Vector3(1, 1.5f, 0) * 1.0f;
    //        }
    //        else
    //        {
    //            rb.velocity += new Vector3(-1, 1.5f, 0) * 1.0f;
    //        }

    //        isBound = true;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Block")
        {
            HP -= 1;


        }
    }
}
