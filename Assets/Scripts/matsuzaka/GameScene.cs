using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
	public GameObject rockPrefab;
	public GameObject loadObject;
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
		if (Input.GetKeyDown(KeyCode.Z))
		{
			GameObject rock = Instantiate(
				rockPrefab,
				new Vector3(Mathf.Round(Random.Range(-0.5f, 0.5f) * loadWidth * (float)raneCount), 0.5f, 8.0f),
				Quaternion.identity);
			rock.GetComponent<RockScript>().scrollSpeed = rockScroolSpeed;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene("ResultScene");
		}
    }

	
}
