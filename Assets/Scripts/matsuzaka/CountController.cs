using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountController : MonoBehaviour
{
	public Text timerText;

	public int seconds;
	public int maxTime;
	public bool isStart;

	private float totalTime;
	// Start is called before the first frame update
	void Start()
    {
		totalTime = (float)maxTime;
		isStart = false;
    }

	// Update is called once per frame
	void Update()
	{
		if (isStart)
		{
			totalTime -= Time.deltaTime;
			seconds = (int)totalTime;
			timerText.text = seconds.ToString();
		}
	}
}
