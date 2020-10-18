using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    public bool final = false;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!final || transform.position.y < 130)
            transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}