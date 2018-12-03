using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour {
    public float moveSpeed;
    // Use this for initialization
    
    private void OnCollisionStay(Collision collision)
    {
        collision.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
