using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Caption : MonoBehaviour {
    private Text cpText;
    private float befTime;

	// Use this for initialization
	void Start () {
        cpText = GetComponent<Text>();
        befTime = Time.time;
        Master.gameState = Master._GameStat.Start;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - befTime > 1.5f && Time.time - befTime <= 4)
        {
            cpText.text = "GO";
            if (Time.time - befTime > 3)
            {
                if (cpText.text != "")
                {
                    cpText.text = "";
                    Master.gameState = Master._GameStat.OnGame;
                }
            }
        }
	}
}
