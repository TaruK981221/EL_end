using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
	public Text timerText;

	public int seconds;

	public bool isStart;

	private float totalTime;

	// Start is called before the first frame update
	void Start()
    {
		initTimer();
		isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (!isStart)
		{
			totalTime -= Time.deltaTime;
			seconds = (int)totalTime;
			timerText.text = seconds.ToString();

		}
		if (seconds == 0)
		{
			timerText.text = "Start";
			isStart = true;
			StartCoroutine("TimerOff");
		}
	}

	public void initTimer()
	{
		totalTime = 6.0f;
		isStart = false;
	}

	IEnumerator TimerOff()
	{
		yield return new WaitForSeconds(1.0f);

		timerText.enabled = false;
	}
}
