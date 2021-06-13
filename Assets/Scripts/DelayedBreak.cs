using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedBreak : MonoBehaviour
{
    public float delayTime = 1.0f;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(StartCountdown(other));
    }

    public IEnumerator StartCountdown(Collider other)
    {
        yield return new WaitForSeconds(delayTime);
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerBehavior>().state = "falling";
            Destroy(gameObject);
        } else if (other.gameObject.name == "Buddy")
        {
            other.gameObject.GetComponent<BuddyBehavior>().state = "falling";
            Destroy(gameObject);
        }
    }
}
