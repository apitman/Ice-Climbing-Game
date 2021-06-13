using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyBehavior : MonoBehaviour
{
    public GameObject player;
    public float followDistance = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y - followDistance, player.transform.position.z);
    }
}
