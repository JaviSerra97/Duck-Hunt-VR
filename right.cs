using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right : MonoBehaviour {
    public float moveSpeed;
    private Vector2 rot;
    // Use this for initialization

    private void OnCollisionStay(Collision collision)
    {
        collision.transform.eulerAngles = new Vector2(0, 148);
        collision.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
