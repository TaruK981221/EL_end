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

	private List<GameObject> rocks;
    // Start is called before the first frame update
    void Start()
    {
		Material material = loadObject.GetComponent<MeshRenderer>().material;
		material.SetFloat("_ScrollSpeed", loadScroolSpeed);

		rocks = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
		if(timer.GetComponent<TimerController>().isStart)
		{
			ReadyState();
		}
		else
		{
			ActiveState();
		}
    }

	

	private void ReadyState()
	{

	}

	private void ActiveState()
	{
		if (counter.GetComponent<CountController>().seconds % 4 == 0)
		{
			GameObject rock = Instantiate(rockPrefab,
				new Vector3(Mathf.Round(Random.Range(-0.5f, 0.5f) * loadWidth) * (float)raneCount, 0.0f, 10.0f),
				Quaternion.AngleAxis(90.0f, Vector3.up));
			rock.GetComponent<RockScript>().scrollSpeed = rockScroolSpeed;
		}
	}
}
