using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
	public float scrollSpeed;
	public float zOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(new Vector3(scrollSpeed, 0.0f, 0.0f));

		if (transform.position.z < zOver)
			Destroy(this.gameObject);
	}
}
