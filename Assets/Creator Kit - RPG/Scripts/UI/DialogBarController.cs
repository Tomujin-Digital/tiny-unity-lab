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
        public TextMeshProUGUI dialogBarText;
        private GameObject dialogIcon;
        private GameObject[] dialogButtons;
        public int selectedButton = 0;
        public int buttonCount = 0;
        private bool showed = false;
        public string conversationItemKey;
        public SpriteUIElement spriteUIElement;
        public Camera mainCamera;

        private void Awake()
        {
            dialogBar = GameObject.Find("DialogBar");
            dialogIcon = GameObject.Find("Icon");
            dialogButtons = GameObject.FindGameObjectsWithTag("DialogButton");
            dialogBarText = GameObject.Find("ConversationText").GetComponent<TextMeshProUGUI>();

            ButtonSetClean();

            dialogButtons[0].GetComponentInChildren<SpriteButton>().onClickEvent += () =>
                OnButton(0);
            dialogButtons[1].GetComponentInChildren<SpriteButton>().onClickEvent += () =>
                OnButton(1);

            spriteUIElement = GetComponent<SpriteUIElement>();
            mainCamera = Camera.main;

            if (dialogIcon != null)
                dialogIcon.SetActive(false);
            dialogBar.SetActive(false);
        }

        public void ButtonSetClean()
        {
            foreach (GameObject button in dialogButtons)
            {
                button.SetActive(false);
            }
        }

        public void SetText(string text)
        {
            dialogBarText.color = Color.Lerp(Color.clear, Color.black, 0.5f);
            dialogBarText.text = text;
        }

        public void ShowAndHide()
        {
            dialogBar.SetActive(!showed);
            showed = !showed;
        }

        public void Show(string text)
        {
            dialogBar.SetActive(true);
            SetText(text);
        }

        public void FocusButton(int direction)
        {
            if (buttonCount > 0)
            {
                if (selectedButton < 0)
                    selectedButton = 0;
                dialogButtons[selectedButton].GetComponentInChildren<SpriteButton>().Exit();
                selectedButton += direction;
                selectedButton = Mathf.Clamp(selectedButton, 0, buttonCount - 1);
                dialogButtons[selectedButton].GetComponentInChildren<SpriteButton>().Enter();
            }
        }

        public void SelectActiveButton()
        {
            if (buttonCount > 0)
            {
                if (selectedButton >= 0)
                {
                    model.input.ChangeState(InputController.State.CharacterControl);
                    dialogButtons[selectedButton].GetComponentInChildren<SpriteButton>().Click();
                    selectedButton = -1;
                }
                // Hide();
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
            dialogIcon.SetActive(false);
            ButtonSetClean();
        }

        public void SetIcon(Sprite icon)
        {
            dialogIcon.GetComponent<Image>().sprite = icon;
            dialogIcon.SetActive(true);
        }

        void OnButton(int index)
        {
            if (onButton != null)
                onButton(index);
            onButton = null;
        }

        public void SetButton(int index, string text)
        {
            dialogButtons[index].SetActive(true);
            dialogButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = text;
            buttonCount = Mathf.Max(buttonCount, index + 1);
        }
    }
}
