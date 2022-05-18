using System;
using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace RPGM.UI
{
    public class DialogBarController : MonoBehaviour
    {
        GameModel model = Schedule.GetModel<GameModel>();
        SpriteButton[] buttons;
        public System.Action<int> onButton;
        private GameObject dialogBackground;
        public int selectedButton = 0;
        public int buttonCount = 0;

        private void Start()
        {
            dialogBackground = GameObject.Find("DialogBar");
            dialogBackground.SetActive(false);
            // Image image = dialogBackground.GetComponent<Image>();
            // print(image.color);
        }

        public void Show(Vector3 position, string text)
        {
            dialogBackground.SetActive(true);
            // d.SetText(text);
            // SetPosition(position);
            // model.input.ChangeState(InputController.State.DialogControl);
            // buttonCount = 0;
            // selectedButton = -1;
        }

        public void FocusButton(int direction)
        {
            // if (buttonCount > 0)
            // {
            //     if (selectedButton < 0) selectedButton = 0;
            //     buttons[selectedButton].Exit();
            //     selectedButton += direction;
            //     selectedButton = Mathf.Clamp(selectedButton, 0, buttonCount - 1);
            //     buttons[selectedButton].Enter();
            // }
        }

        public void SelectActiveButton()
        {
            if (buttonCount > 0)
            {
                if (selectedButton >= 0)
                {
                    model.input.ChangeState(InputController.State.CharacterControl);
                    buttons[selectedButton].Click();
                    selectedButton = -1;
                }
            }
            else
            {
                model.input.ChangeState(InputController.State.CharacterControl);
                Hide();
            }
        }

        public void Hide()
        {
            UserInterfaceAudio.OnHideDialog();
            dialogBackground.SetActive(false);
        }

        public void SetIcon(Sprite icon)
        {
            print("set icon");
        }

        void OnButton(int index)
        {
            if (onButton != null)
                onButton(index);
            onButton = null;
        }

        public void SetButton(int index, string text)
        {
            print(text);
            // d.SetButtonText(index, text);
            // buttonCount = Mathf.Max(buttonCount, index + 1);
        }
    }
}