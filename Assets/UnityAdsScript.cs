using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAdsScript : MonoBehaviour {

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
	
	// Update is called once per frame
    void Update()
    {
	}
}
