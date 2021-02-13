using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
	private Text text;
    // Start is called before the first frame update
    void Start()
    {
		text = GetComponent<Text>();
		if (DataSaver.winner == 0)
			text.text = "Player1 WIN";
		else if (DataSaver.winner == 1)
			text.text = "Player2 WIN";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
