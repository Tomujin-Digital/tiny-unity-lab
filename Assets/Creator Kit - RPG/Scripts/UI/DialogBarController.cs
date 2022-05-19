using System;
using RPGM.Core;
using RPGM.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPGM.UI
{
    public class DialogBarController : MonoBehaviour
    {
        GameModel model = Schedule.GetModel<GameModel>();
        SpriteButton[] buttons;
        public System.Action<int> onButton;
        private GameObject dialogBar;
        public Text dialogBarText;
        private GameObject dialogIcon;
        private GameObject[] dialogButtons;
        public int selectedButton = 0;
        public int buttonCount = 0;
        private bool showed = false;

        private void Awake()
        {
            dialogBar = GameObject.Find("DialogBar");
            dialogIcon = GameObject.Find("Icon");
            dialogButtons = GameObject.FindGameObjectsWithTag("DialogButton");
            dialogBarText = GameObject.Find("ConversationText").GetComponent<Text>();

            print(dialogBarText);
            if (dialogIcon != null) dialogIcon.SetActive(false);
            if(dialogButtons != null) {
                foreach(GameObject button in dialogButtons) {
                    button.SetActive(false);
                }
            };
            dialogBar.SetActive(false);
        }

        public void Show(string text)
        {
            dialogBar.SetActive(true);
            print(dialogBarText.text);
        }

        public void ShowAndHide() {

            if (showed == false)
            {
                Show("hahah");
            }
            else
            {
                Hide();
            }
            showed = !showed;
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
            dialogBar.SetActive(false);
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
