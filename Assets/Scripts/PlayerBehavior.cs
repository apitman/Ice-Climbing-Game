using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float hSpeed = 1.0f;
    public float vSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1 * Input.GetAxis("Horizontal") * Time.deltaTime * hSpeed, Time.deltaTime * vSpeed, 0);
    }
}
