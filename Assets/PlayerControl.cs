using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class PlayerControl : MonoBehaviour {
    public Text scoreText;
    public GameObject restartButton;
    private Vector3 _OriginalScale;
    private Vector3 _DownPos;
    private int ctype = 1;
    private Camera cam;

    private float startTime = 0;
    private int score;
    private int _Score;
    private bool dead = false;

    public GameObject floor;
    public Color[] colors;

    // Use this for initialization
    void Awake()
    {
        if (Advertisement.isInitialized == false)
        {
            // ゲームIDを入力して、Unity Adsを初期化する
            if (Advertisement.isSupported)
            {
                Advertisement.allowPrecache = true;
                Advertisement.Initialize("29440");
            }
            else
            {
                Debug.Log("Platform not supported");
            }
        }
    }
	void Start () {
        _OriginalScale = transform.localScale;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        score = 0;
    }
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (dead)
        {
            transform.Rotate(new Vector3(0, 5, 0));
            iTween.ScaleTo(gameObject,new Vector3(0,0,0),2f);
            return;
        }
        if (Master.gameState == Master._GameStat.OnGame)
        {
            if (startTime == 0)
                startTime = Time.time * 10;
            _Score = (int)(Time.time * 10 - startTime + score);
            scoreText.text = "SCORE:" + _Score.ToString("0,000,000");

            for (int i = 0; i < colors.Length; i++)
            {
                if (_Score >= (i + 1) * 2000)
                {
                    floor.GetComponent<MeshRenderer>().material.SetColor("_Color", colors[i]);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            _DownPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            if (ctype == 0)
            {
                Vector3 dif = Input.mousePosition - _DownPos;
                float dis = Mathf.Clamp(dif.magnitude - Screen.width / 3, 0, 10000);
                float sclX = Mathf.Clamp(_OriginalScale.x - dis * 5 / Screen.width, 0.2f, 4f);
                float sclY = Mathf.Clamp(_OriginalScale.y + dis * 5 / Screen.width, 0.2f, 4f);
                transform.localScale = new Vector3(sclX, sclY, Mathf.Min(sclX,sclY));

                if (_DownPos.y <= Input.mousePosition.y)
                {
                    transform.rotation = Quaternion.FromToRotation(Vector3.down, dif);
                }
                else
                {
                    transform.rotation = Quaternion.FromToRotation(Vector3.down, dif);
                }
            }
            else
            {
                Vector3 plPos = cam.WorldToScreenPoint(transform.position);
                Vector3 dif = Input.mousePosition - plPos;
                float dis = Mathf.Clamp(dif.magnitude * 1.1f - Screen.width / 5, 0, 10000);
                float sclX = Mathf.Clamp(_OriginalScale.x - dis * 5 / Screen.width, 0.2f, 4f);
                float sclY = Mathf.Clamp(_OriginalScale.y + dis * 5 / Screen.width, 0.2f, 4f);
                transform.localScale = new Vector3(sclX, sclY, Mathf.Min(sclX, sclY));

                transform.rotation = Quaternion.FromToRotation(Vector3.up, dif);
                //transform.rotation *= Quaternion.Euler(0, dif.magnitude, 0);
            }


        }

        if (Input.GetMouseButtonUp(0))
        {
            transform.localScale = _OriginalScale;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Point")
        {
            score += 100;
            col.GetComponent<AudioSource>().Play();
        }
        else if (col.tag != "Dest")
        {
            Debug.Log("Hit");
            Master.gameState = Master._GameStat.GameOver;
            Invoke("ActivateRestartButton", 2f);
            dead = true;
            GetComponent<AudioSource>().Play();
        }
    }

    void ActivateRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        Master.RetryCount++;
        if (Master.RetryCount % 5 == 0)
        {
            // Unity Adsを表示する準備ができているか確認する
            if (Advertisement.isReady())
            {
                // Unity Adsを表示する
                Advertisement.Show(null, new ShowOptions
                {
                    pause = true,
                    resultCallback = result =>
                    {
                        Debug.Log(result.ToString());
                    }
                });
            }
        }
        Master.gameState = Master._GameStat.Nothing;
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void TweetResult()
    {
        // WebブラウザのTwitter投稿画面を開く
        Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL("I made " + _Score.ToString() + " #CTB"));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
