using UnityEngine;
using System.Collections;

public class RingControl : MonoBehaviour
{
    public int typeNum = 3;
    public GameObject diaPrefab;
    public GameObject ringPrefab;
    public GameObject minoPrefab;
    public GameObject wavePrefab;
    public float intervalTime = 3f;

    private float befTime;
    private bool swit = false;

	// Use this for initialization
	void Start () {
        befTime = Time.time - intervalTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (Master.gameState <= Master._GameStat.OnGame && befTime < Time.time - intervalTime)
        {
            Debug.Log("Stat:" + (int)Master.gameState);
            if (swit)
            {
                SetDia();
            }
            else
            {
                float rnd = UnityEngine.Random.Range(1, 100);
                if (rnd < 45){
                    SetRing();
                }else if(rnd < 90){
                    SetMino();
                }else{
                    SetWave();
                }
            }
            befTime = Time.time;
            Debug.Log("befTime" + befTime);
            swit = !swit;
        }
	}

    void SetDia()
    {
        float posX = 1f;
        if (UnityEngine.Random.Range(1, 3) <= 1)
        {
            posX *= -1;
        }
        int num = UnityEngine.Random.Range(-1,4);
        for (int i = 0; i < num; i++)
        {
            GameObject go = Instantiate(diaPrefab, new Vector3(posX, 2.5f, transform.position.z + i*2), Quaternion.identity) as GameObject;
            go.transform.Rotate(new Vector3(90, 0, 0));
            go.transform.parent = transform;
        }
    }

    void SetRing()
    {
        GameObject go = Instantiate(ringPrefab, transform.position, Quaternion.identity) as GameObject;
        go.transform.parent = transform;
        go.GetComponent<Wall>().dis = UnityEngine.Random.Range(-1f, 1f);
        go.GetComponent<Wall>().angle = UnityEngine.Random.Range(-90, 90);
    }
    void SetMino()
    {
        GameObject go = Instantiate(minoPrefab, transform.position, Quaternion.identity) as GameObject;
        go.transform.parent = transform;
        go.GetComponent<Wall>().dis = 0;
        go.GetComponent<Wall>().angle = UnityEngine.Random.Range(-90, 90);
    }
    void SetWave()
    {
        GameObject go = Instantiate(wavePrefab, transform.position, Quaternion.identity) as GameObject;
        go.transform.parent = transform;
        go.GetComponent<Wall>().dis = 0;
        go.GetComponent<Wall>().angle = UnityEngine.Random.Range(-90, 90);
    }
}
