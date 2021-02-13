using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
	public GameObject rockPrefab;
	public GameObject loadObject;
	public GameObject timer;
	public GameObject counter;
	public GameObject player1;
	public GameObject player2;
	public float loadWidth;
	public int raneCount;
	public float loadScroolSpeed;
	public float rockScroolSpeed;
	public int spawnRate;

	private bool spwan;

	public int winner = 0;

	private playerCon player1Con;
	private playerCon player2Con;

	private List<GameObject> rocks;

	private DataSaver dataSaver;
	private TimerController timerc;
	private CountController counterc;
    // Start is called before the first frame update
    void Start()
    {
		dataSaver = GetComponent<DataSaver>();
		player1Con = player1.GetComponent<playerCon>();
		player2Con = player1.GetComponent<playerCon>();
		Material material = loadObject.GetComponent<MeshRenderer>().material;
		material.SetFloat("_ScrollSpeed", loadScroolSpeed);

		rocks = new List<GameObject>();
		spwan = false;

		timerc = timer.GetComponent<TimerController>();
		counterc = counter.GetComponent<CountController>();
    }

    // Update is called once per frame
    void Update()
    {
		if(!timerc.isStart)
		{
			ReadyState();
		}
		else
		{
			counterc.isStart = true;
			ActiveState();
		}
    }

	

	private void ReadyState()
	{

	}

	private void ActiveState()
	{
		if (counterc.milliseconds % spawnRate == 0 && !spwan)
		{
			spwan = true;
			if (spwan)
			{
				GameObject rock = Instantiate(rockPrefab,
					new Vector3(Mathf.Round(Random.Range(-10.0f, 10.0f) * loadWidth / 20.0f * (float)raneCount), 0.0f, 18.0f),
					Quaternion.AngleAxis(90.0f, Vector3.up));
				rock.GetComponent<RockScript>().scrollSpeed = rockScroolSpeed;
				spwan = false;
			}
		}

		if(player1Con.HP == 0)
		{
			winner = 0;
			DataSaver.winner = winner;
			Debug.Log(winner);
			SceneManager.LoadScene("ResultScene");
		}

		if(player2Con.HP == 0)
		{
			winner = 1;
			DataSaver.winner = winner;
			Debug.Log(winner);
			SceneManager.LoadScene("ResultScene");
		}

		if(counterc.seconds == 0)
		{
			winner = 2;
			DataSaver.winner = winner;
			Debug.Log(winner);
			SceneManager.LoadScene("ResultScene");
		}
	}
}
