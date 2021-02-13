using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
	public int lifeCount;
	public GameObject player1Prefab;
	public GameObject player2Prefab;

	private List<GameObject> player1Life;
	private List<GameObject> player2Life;

	private Canvas canvas;
	// Start is called before the first frame update
	void Start()
    {
		canvas = GetComponent<Canvas>();
		player1Life = new List<GameObject>();
		player2Life = new List<GameObject>();

		for(int i = 0; i < lifeCount; i++)
		{
			player1Life.Add(Instantiate(player1Prefab, new Vector3(40.0f * (float)(i + 1), (float)Screen.height - 20.0f, 0.0f),
				Quaternion.identity, this.gameObject.transform));
			player2Life.Add(Instantiate(player2Prefab, new Vector3((float)Screen.width - 40.0f * (float)(lifeCount - i), (float)Screen.height - 20.0f, 0.0f),
				Quaternion.identity, this.gameObject.transform));
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
