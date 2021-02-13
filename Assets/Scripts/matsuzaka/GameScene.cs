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
	public float loadWidth;
	public int raneCount;
	public float loadScroolSpeed;
	public float rockScroolSpeed;
	public int spawnRate;

	private bool spwan;

	private List<GameObject> rocks;
    // Start is called before the first frame update
    void Start()
    {
		Material material = loadObject.GetComponent<MeshRenderer>().material;
		material.SetFloat("_ScrollSpeed", loadScroolSpeed);

		rocks = new List<GameObject>();
		spwan = false;
    }

    // Update is called once per frame
    void Update()
    {
		if(!timer.GetComponent<TimerController>().isStart)
		{
			ReadyState();
		}
		else
		{
			counter.GetComponent<CountController>().isStart = true;
			ActiveState();
		}
    }

	

	private void ReadyState()
	{

	}

	private void ActiveState()
	{
		if (counter.GetComponent<CountController>().milliseconds % spawnRate == 0 && !spwan)
		{
			spwan = true;
			if (spwan)
			{
				GameObject rock = Instantiate(rockPrefab,
					new Vector3(Mathf.Round(Random.Range(-10.0f, 10.0f) * loadWidth / 20.0f * (float)raneCount), 0.0f, 10.0f),
					Quaternion.AngleAxis(90.0f, Vector3.up));
				rock.GetComponent<RockScript>().scrollSpeed = rockScroolSpeed;
				spwan = false;
			}
		}
	}
	IEnumerator SpawnRock()
	{
		spwan = true;
		yield return new WaitForSeconds(0.1f);
		if (spwan)
		{
			GameObject rock = Instantiate(rockPrefab,
				new Vector3(Mathf.Round(Random.Range(-10.0f, 10.0f) * loadWidth / 20.0f * (float)raneCount), 0.0f, 10.0f),
				Quaternion.AngleAxis(90.0f, Vector3.up));
			rock.GetComponent<RockScript>().scrollSpeed = rockScroolSpeed;
			spwan = false;
		}

	}
}
