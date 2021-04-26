using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerHealthTwo : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Health controller = other.GetComponent<Health>();

        if (controller != null)
        {
            controller.ChangeHealth(-2);
            Destroy(this);
        }
    }
}
