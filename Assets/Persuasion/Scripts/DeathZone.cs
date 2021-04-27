using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform respawnPoint;

    

    void OnTriggerEnter2D(Collider2D other)
    {
        Health controller = other.GetComponent<Health>();
        if (controller != null)
        {
            controller.ChangeHealth(-1);
            player.transform.position = respawnPoint.transform.position;
            Debug.Log("You have fallen");
        }
    }
}
