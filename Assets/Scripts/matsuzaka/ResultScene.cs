using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour
{
	public GameObject player1Prefab;
	public GameObject player2Prefab;
	private GameObject player;
	int winner;
	// Start is called before the first frame update
	void Start()
    {
		winner = DataSaver.winner;
		Debug.Log(winner);
		if (winner == 0)
		{
			player = Instantiate(player1Prefab,
				Vector3.zero,
				Quaternion.AngleAxis(180.0f, Vector3.up));
		}
		else if(winner == 1)
		{
			player = Instantiate(player2Prefab,
				Vector3.zero,
				Quaternion.AngleAxis(180.0f, Vector3.up));
		}
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene("TitleScene");
		}
    }
}
