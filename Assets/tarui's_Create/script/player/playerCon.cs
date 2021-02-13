using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

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

    bool isDamage = false;
    float DamageTime = 0.0f;
    [SerializeField]
    float DamageTimeLimit = 3.0f;

    public int HP = 5;

    [SerializeField]
    Material material;

    bool isLR = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Color color = material.color;
        color.a = 1.0f;
        material.color = color;
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
                    isLR = true;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    isLR = false;
                }
                //else
                //{
                //    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                //}

                if (isLR)
                {
                    rb.velocity = new Vector3(Vector3.left.x * 1.0f, rb.velocity.y, 0);
                }
                else
                {
                    rb.velocity = new Vector3(Vector3.right.x * 1.0f, rb.velocity.y, 0);
                }

                if (Input.GetKeyDown(KeyCode.UpArrow) && rb.velocity.y == 0.0f)
                {
                    rb.velocity += Vector3.up * JumpPower;
                    SEManager.Instance.Play(SEPath.SE_JUMP1, 1, 0, Random.Range(0.5f, 1.5f));
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    isLR = true;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    isLR = false;
                }
                //else
                //{
                //    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                //}

                if (isLR)
                {
                    rb.velocity = new Vector3(Vector3.left.x * 1.0f, rb.velocity.y, 0);
                }
                else
                {
                    rb.velocity = new Vector3(Vector3.right.x * 1.0f, rb.velocity.y, 0);
                }

                if (Input.GetKeyDown(KeyCode.W) && rb.velocity.y == 0.0f)
                {
                    rb.velocity += Vector3.up * JumpPower;
                    SEManager.Instance.Play(SEPath.SE_JUMP1, 1, 0, Random.Range(0.5f, 1.5f));
                }
            }
        }

        if(isDamage)
        {
            Color color = material.color;
            if (DamageTime < DamageTimeLimit)
            {
                DamageTime += Time.deltaTime;

                if (DamageTime % 0.2f < 0.1f)
                {
                    color.a = 0.2f;
                    material.color = color;
                }
                else
                {
                    color.a = 1.0f;
                    material.color = color;
                }
            }
            else
            {
                color.a = 1.0f;
                material.color = color;
                DamageTime = 0.0f;
                isDamage = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.velocity = Vector3.zero;

            if (collision.transform.position.x < transform.position.x)
            {
                rb.velocity += new Vector3(1, 1.5f, 0) * 1.0f;
            }
            else
            {
                rb.velocity += new Vector3(-1, 1.5f, 0) * 1.0f;
            }

            isBound = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Block" && !isDamage)
        {
            SEManager.Instance.Play(SEPath.SE_PDAMAGE, 1, 0, Random.Range(0.5f, 1.5f));

            HP -= 1;

            isDamage = true;
        }
    }
}
