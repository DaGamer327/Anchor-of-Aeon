using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DialogueSystem
{
    
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; protected set; }
        protected IEnumerator WriteText(string input, Text textholder, Color textcolor, Font textfont, float delay, AudioClip sound, float delayBetweeenLines)
        {
            textholder.color = textcolor;
            textholder.font = textfont;

            for (int i = 0; i < input.Length; i++)
            {
                textholder.text += input[i];
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }
            //yield return new WaitForSeconds(delayBetweeenLines);
            yield return new WaitUntil(()=> Input.GetKeyDown(KeyCode.E));


            finished = true;
        }
    }

}

