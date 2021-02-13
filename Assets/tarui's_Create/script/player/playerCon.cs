using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCon : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    bool isFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector3.up * 10.0f;
        }
    }
}
