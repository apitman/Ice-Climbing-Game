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
        // Follow the player's position with a slight lag
        float xDiff = player.transform.position.x - transform.position.x;
        float yDiff = player.transform.position.y - transform.position.y - followDistance;
        // transform.position = new Vector3(player.transform.position.x, player.transform.position.y - followDistance, player.transform.position.z);
        transform.Translate(Time.deltaTime * xDiff * hSpeed, Time.deltaTime * yDiff * vSpeed, 0);

        // Draw a line between buddy and player
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        lineRenderer.SetPosition(1, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
    }
}
