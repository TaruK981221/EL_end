using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
	public int lifeCount;
	public GameObject player1Prefab;
	public GameObject player2Prefab;
	public GameObject player1;
	public GameObject player2;

	private List<GameObject> player1Life;
	private List<GameObject> player2Life;

	private playerCon player1Con;
	private playerCon player2Con;

	private int tmpP1HP;
	private int tmpP2HP;

	private Canvas canvas;
	// Start is called before the first frame update
	void Start()
    {
		canvas = GetComponent<Canvas>();
		player1Life = new List<GameObject>();
		player2Life = new List<GameObject>();

		player1Con = player1.GetComponent<playerCon>();
		player2Con = player2.GetComponent<playerCon>();

		tmpP1HP = player1Con.HP;
		tmpP2HP = player2Con.HP;

		for (int i = 0; i < tmpP1HP; i++)
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
		if(player1Con.HP != tmpP1HP && tmpP1HP != 0)
		{
			Destroy(player1Life[tmpP1HP - 1]);
			player1Life.RemoveAt(tmpP1HP - 1);
			tmpP1HP = player1Con.HP;
		}
		if (player2Con.HP != tmpP2HP && tmpP2HP != 0)
		{
			Destroy(player2Life[tmpP2HP - 1]);
			player2Life.RemoveAt(tmpP2HP - 1);
			tmpP2HP = player2Con.HP;
		}
	}
}
