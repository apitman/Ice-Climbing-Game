using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedBreak : MonoBehaviour
{
    public float delayTime = 1.0f;
    public bool isActive = true;
    public float fallSpeed = 10.0f;

    void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            StartCoroutine(StartCountdown(other));
        }
    }

    void Update()
    {
        if (isActive == false)
        {
            transform.Translate(0, 0, fallSpeed * Time.deltaTime);
        }
        if (transform.position.y < -100)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator StartCountdown(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            yield return new WaitForSeconds(delayTime);
            isActive = false;
            other.gameObject.GetComponent<PlayerBehavior>().state = "falling";
        } else if (other.gameObject.name == "Buddy")
        {
            yield return new WaitForSeconds(delayTime);
            isActive = false;
            other.gameObject.GetComponent<BuddyBehavior>().state = "falling";
        }
    }
}
