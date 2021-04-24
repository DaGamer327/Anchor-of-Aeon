using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DialogueSystem
{

    public class DialogueLine : DialogueBaseClass
    {
        private Text textholder;

        [Header ("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color textcolor;
        [SerializeField] private Font textfont;

        [Header("Time parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweeenLines;


        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        [Header("Character Image")]
        [SerializeField] private Sprite CharacterImage;
        [SerializeField] private Image ImageHolder;

        private IEnumerator lineAppear;


        private void Awake()
        {
           

            ImageHolder.sprite = CharacterImage;
            ImageHolder.preserveAspect = true;
        }

        private void OnEnable()
        {
            ResetLine();
            lineAppear = WriteText(input, textholder, textcolor, textfont, delay, sound, delayBetweeenLines);
            StartCoroutine(lineAppear);

        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                if (textholder.text != input)
                {
                    StopCoroutine(lineAppear);
                    textholder.text = input;

                }
                else
                    finished = true;
            }
            
        }

        private void ResetLine()
        {
            textholder = GetComponent<Text>();
            textholder.text = "";
            finished = false;
        }
    }
}

