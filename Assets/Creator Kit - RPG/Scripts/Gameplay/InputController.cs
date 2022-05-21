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
        private Vector2 moveDelta = Vector2.zero;
        public PlayerInputAction playerControls;
        private InputAction move;
        private InputAction fire;
        private Rigidbody2D rb;


        GameModel model = Schedule.GetModel<GameModel>();

        public enum State
        {
            CharacterControl,
            DialogControl,
            Pause
        }

        State state;

        private void Awake()
        {
            playerControls = new PlayerInputAction();
        }

        private void OnEnable()
        {
            move = playerControls.Player.Move;
            move.Enable();

            fire = playerControls.Player.Fire;
            fire.Enable();

            fire.performed += Fire;
        }
        private void OnDisable()
        {
            move.Disable(); 
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
            print("DialogControl");
            model.player.nextMoveCommand = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                model.dialog.FocusButton(-1);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                model.dialog.FocusButton(+1);
        }

        void CharacterControl()
        {   
            moveDelta = move.ReadValue<Vector2>();
            model.player.nextMoveCommand = new Vector3(moveDelta.x, moveDelta.y, 0) * stepSize;
        }

        void Fire(InputAction.CallbackContext context)
        {
            model.dialog.SelectActiveButton();
        }
    }
}