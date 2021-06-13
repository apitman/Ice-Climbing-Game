using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float hSpeed = 1.0f;
    public float vSpeed = 1.0f;
    public string state = "climbing"; // climbing, falling, anchoring, hanging
    public GameObject buddy;
    public float ropeLength = 5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        string buddyState = buddy.GetComponent<BuddyBehavior>().state;
        float followDistance = buddy.GetComponent<BuddyBehavior>().followDistance;
        if (buddyState == "falling" && state == "climbing") {
            state = "anchoring";
        }

        if (state == "climbing")
        {
            transform.Translate(-1 * Input.GetAxis("Horizontal") * Time.deltaTime * hSpeed, Time.deltaTime * vSpeed, 0);
        } else if (state == "falling")
        {
            GetComponent<Rigidbody>().useGravity = true;

            float distanceFromBuddy = Vector3.Distance(buddy.transform.position, transform.position);
            if (distanceFromBuddy > ropeLength)
            {
                state = "hanging";
            }
        } else if (state == "anchoring")
        {
            if (buddyState == "climbing" && transform.position.y - buddy.transform.position.y > followDistance)
            {
                state = "climbing";
            }
        } else if (state == "hanging")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            state = "climbing";
        }
    }
}
