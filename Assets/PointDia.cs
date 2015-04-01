using UnityEngine;
using System.Collections;

public class PointDia : MonoBehaviour
{
    private float speed = 8;
    public float speedR = 2;
    private Material mat;
    private float alpha = 0;

	// Use this for initialization
	void Start () {
        mat = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speedR));
        if (alpha > 0)
        {
            alpha -= 0.04f;
            if (alpha <= 0)
            {
                Destroy(gameObject);
            }
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, alpha);
            transform.position -= new Vector3(0, -1 * speed * Time.deltaTime, 0);
        }
        else
        {
            if (Master.gameState <= Master._GameStat.OnGame)
                transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        alpha = mat.color.a;
    }
}
