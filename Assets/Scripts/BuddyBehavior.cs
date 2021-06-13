using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyBehavior : MonoBehaviour
{
    public GameObject player;
    public float followDistance = 3.0f;
    public Material ropeMaterial;
    public float hSpeed = 1.0f;
    public float vSpeed = 1.0f;
    public string state = "climbing"; // climbing, falling, anchoring, hanging
    public float ropeLength = 5f;

    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = ropeMaterial;
        lineRenderer.widthMultiplier = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        string playerState = player.GetComponent<PlayerBehavior>().state;
        if (playerState == "falling" && state == "climbing") {
            state = "anchoring";
        }
        if (state == "climbing")
        {
            if (playerState != "done")
            {
                // Follow the player's position with a slight lag
                float xDiff = player.transform.position.x - transform.position.x;
                float yDiff = player.transform.position.y - transform.position.y - followDistance;
                // transform.position = new Vector3(player.transform.position.x, player.transform.position.y - followDistance, player.transform.position.z);
                transform.Translate(Time.deltaTime * xDiff * hSpeed, Time.deltaTime * yDiff * vSpeed, 0);
            } else
            {
                Debug.Log("Buddy moving to done spot");
                // Special movement to get alongside Player
                transform.Translate((player.transform.position.x - transform.position.x + 2) * Time.deltaTime, (player.transform.position.y - transform.position.y) * Time.deltaTime, 0);
            }
        } else if (state == "falling")
        {
            GetComponent<Rigidbody>().useGravity = true;

            float distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);
            if (distanceFromPlayer > ropeLength && playerState != "falling")
            {
                state = "hanging";
            }
        } else if (state == "anchoring")
        {
            if (playerState == "climbing" && player.transform.position.y - transform.position.y - followDistance > 0)
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

        // Draw a line between buddy and player
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        lineRenderer.SetPosition(1, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
    }
}
