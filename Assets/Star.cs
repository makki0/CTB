using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
    private float speed = 5;
    private float speedR = 5;

	// Use this for initialization
    void Start()
    {
        speed = UnityEngine.Random.Range(5, 25);
        speedR = UnityEngine.Random.Range(2, 10);
	    
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        transform.Rotate(new Vector3(speedR, 0, 0));

        if (transform.position.z < -13)
        {
            Destroy(gameObject);
        }
	}
}
