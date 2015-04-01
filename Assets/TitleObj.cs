using UnityEngine;
using System.Collections;

public class TitleObj : MonoBehaviour {
    public GameObject[] objs;
    private GameObject obj;

	// Use this for initialization
    void Awake()
    {
        if (PlayerPrefs.HasKey("SoundVol") && PlayerPrefs.GetFloat("SoundVol") == 0)
        {
            AudioListener.volume = 0;
        }
    }
    void Start () {
        Master.gameState = Master._GameStat.GameOver;
        int n = UnityEngine.Random.Range(0, objs.Length);
        obj = Instantiate(objs[n], transform.position, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        obj.transform.Rotate(new Vector3(0.678f, 0.5f, 0.2f));
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    public void StartGame()
    {
        Application.LoadLevel("GameScene");
    }
}
