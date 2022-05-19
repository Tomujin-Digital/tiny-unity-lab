using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPGM.UI
{
    public class MessageBar : MonoBehaviour
    {
        public TextMeshProUGUI textMeshPro;
        Image spriteRenderer;

        static MessageBar instance;
        Queue<string> messages = new Queue<string>();

        void Awake()
        {
            instance = this;
            spriteRenderer = GetComponent<Image>();
        }

        IEnumerator Start()
        {
            var delay = new WaitForSeconds(2);
            while (true)
            {
                yield return null;
                if (messages.Count > 0)
                {
                    textMeshPro.text = messages.Dequeue();
                    spriteRenderer.color = new Color(1, 1, 1, 0);
                    textMeshPro.color = new Color(0, 0, 0, 0);
                    var T = 0f;
                    while (T < 1)
                    {
                        T += Time.deltaTime;
                        spriteRenderer.color = new Color(1, 1, 1, T);
                        textMeshPro.color = new Color(0, 0, 0, T);
                        yield return null;
                    }
                    spriteRenderer.color = Color.white;
                    textMeshPro.color = Color.black;
                    yield return delay;
                    while (T > 0)
                    {
                        T -= Time.deltaTime;
                        spriteRenderer.color = new Color(1, 1, 1, T);
                        textMeshPro.color = new Color(1, 1, 1, T);
                        yield return null;
                    }
                    spriteRenderer.color = new Color(1, 1, 1, 0);
                    textMeshPro.color = new Color(1, 1, 1, 0);
                }
            }

        }

        public static void Show(string text)
        {
            instance.messages.Enqueue(text);
        }
    }
}