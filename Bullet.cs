using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Rigidbody rb;
    public float speed;

	void Start () {
        Invoke("selfDestruct", 2f);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
	}

    void selfDestruct()
    {
        Destroy(gameObject);
    }

}
