using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPGM.UI
{
    /// <summary>
    /// Sends user input to the correct control systems.
    /// </summary>
    public class InputController : MonoBehaviour
    {
        public float stepSize = 0.5f;
        private Vector3 moveDelta = Vector3.zero;
        public InputAction playerControls;
        private Rigidbody2D rb;


        GameModel model = Schedule.GetModel<GameModel>();

        public enum State
        {
            CharacterControl,
            DialogControl,
            Pause
        }

        State state;

        private void OnEnable()
        {
            playerControls.Enable();
        }
        private void OnDisable()
        {
            playerControls.Disable(); 
        }

        public void ChangeState(State state) => this.state = state;

        void Update()
        {
            switch (state)
            {
                case State.CharacterControl:
                    CharacterControl();
                    break;
                case State.DialogControl:
                    DialogControl();
                    break;
            }
        }

        void DialogControl()
        {
            //Fix me SelectActiveButton
            model.dialog.SelectActiveButton();
            
            model.player.nextMoveCommand = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                model.dialog.FocusButton(-1);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                model.dialog.FocusButton(+1);
        }

        void CharacterControl()
        {   
            moveDelta = playerControls.ReadValue<Vector3>();
            moveDelta = new Vector3(moveDelta.x, moveDelta.y, 0);
            Debug.Log(model.player);
            model.player.nextMoveCommand = moveDelta * stepSize;
        }
    }
}