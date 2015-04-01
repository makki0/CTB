using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
    private Vector3 _OriginalScale;
    private float speed = 8;
    public float speedR = 0;
    public float dis = 0;
    public float angle = 0;
    public MeshRenderer[] meshs;
    private float alpha = 0;

	// Use this for initialization
    void Start()
    {
        _OriginalScale = transform.localScale;
        //speed = UnityEngine.Random.Range(5, 25);
        //speedR = UnityEngine.Random.Range(2, 10);

        TransForm();
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, speedR, 0));

        if (alpha > 0)
        {
            alpha -= 0.02f;
            if (alpha <= 0)
            {
                Destroy(gameObject);
            }
            foreach (MeshRenderer mesh in meshs)
            {
                Material mat = mesh.material;
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, alpha);
                mat.SetFloat("_Metallic", alpha);
                transform.localScale *= 1.01f;
                mesh.transform.tag = "Dest";
            }
        }
        else
        {
            if (Master.gameState <= Master._GameStat.OnGame)
                transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
        if (transform.position.z < -30)
        {
            Destroy(gameObject);
        }
	    if (Master.gameState == Master._GameStat.OnGame && transform.position.z < -8)
        {
            alpha = meshs[0].material.color.a;
        }
	}

    void TransForm()
    {
        float sclX = Mathf.Clamp(_OriginalScale.x - dis, 0.2f, 2f);
        float sclY = Mathf.Clamp(_OriginalScale.y + dis, 0.2f, 2f);
        transform.localScale = new Vector3(sclX, sclY, transform.localScale.z);
        transform.Rotate(new Vector3(0, 0, angle));
    }
    void OnTriggerEnter(Collider col)
    {
        alpha = meshs[0].material.color.a;
    }
}
