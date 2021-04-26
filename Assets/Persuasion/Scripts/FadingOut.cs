using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadingOut : MonoBehaviour
{
    public Image fading;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        fading.canvasRenderer.SetAlpha(1.0f);

        FadeOut();
    }

    // Update is called once per frame
    void FadeOut()
    {
        fading.CrossFadeAlpha(0, 2, false);
    }


    public void FadeIn()
    {
        fading.CrossFadeAlpha(1, 1, false);
    }

    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            FadeIn();

        }
    }*/
}
