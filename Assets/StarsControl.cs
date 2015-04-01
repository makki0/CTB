using UnityEngine;
using System.Collections;

public class StarsControl : MonoBehaviour {
    private int _StarsCount;
    public int maxStarsNum = 30;
    public GameObject starPrefab;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < maxStarsNum; i++)
        {
            SetStar();
        }
	}
	
	// Update is called once per frame
	void Update () {
        int count = maxStarsNum - transform.childCount;
        for (int i = 0; i < count; i++)
        {
            SetStar();
        }
	}

    void SetStar()
    {
        int angle = UnityEngine.Random.Range(-180,180);
        float distance = UnityEngine.Random.Range(8,20);
        Vector3 setPos = new Vector3(distance * Mathf.Sign(angle), distance * Mathf.Cos(angle), 100 + UnityEngine.Random.Range(-50,50));
        GameObject go = Instantiate(starPrefab, setPos,Quaternion.identity) as GameObject;
        go.transform.Rotate(new Vector3(270, 0, 0));
        go.transform.localScale *= UnityEngine.Random.Range(0.1f, 1);
        go.transform.parent = transform;
    }
}
