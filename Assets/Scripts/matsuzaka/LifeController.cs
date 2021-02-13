using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
	public bool active;

	private RawImage image;

    // Start is called before the first frame update
    void Start()
    {
		active = true;
		image = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!active)
		{
			image.enabled = false;
		}
    }
}
