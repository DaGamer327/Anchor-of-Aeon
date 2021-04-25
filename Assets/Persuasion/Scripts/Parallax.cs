using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float length;
    [SerializeField] float startpos;
    public GameObject camera;
    public float Parallaxeffect;
    public float second;

     void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        second = 1;
    }

     void FixedUpdate()
    {
        float temp = (camera.transform.position.x  * (1 - Parallaxeffect));
        float dist = (camera.transform.position.x  * Parallaxeffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }

    }
}
