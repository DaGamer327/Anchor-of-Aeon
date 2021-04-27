using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loop : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        /*
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        */
    }
}
