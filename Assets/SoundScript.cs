using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundScript : MonoBehaviour {
    private Image _Image;
    public Sprite[] splites;

	// Use this for initialization
	void Start () {
        _Image = GetComponent<Image>();
        if (AudioListener.volume == 0f)
        {
            _Image.sprite = splites[1];
        }
        else
        {
            _Image.sprite = splites[0];
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SoundOnOff()
    {
        if (AudioListener.volume == 0f)
        {
            AudioListener.volume = 1f;
            _Image.sprite = splites[0];
        }
        else
        {
            AudioListener.volume = 0f;
            _Image.sprite = splites[1];
        }
        PlayerPrefs.SetFloat("SoundVol", AudioListener.volume);
    }
}
