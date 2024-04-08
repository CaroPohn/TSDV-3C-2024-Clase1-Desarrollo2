using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class InputReader : MonoBehaviour
    {
        public CharacterMovement characterMovement;
        public JumpBehaviour jumpBehaviour;

        public void HandleMoveInput(InputAction.CallbackContext context)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

            if(characterMovement != null )
            {
                characterMovement.Move(moveDirection);
            }
        }

        public void HandleJumpInput(InputAction.CallbackContext context)
        {
            if(jumpBehaviour && context.started)
            {
                jumpBehaviour.Jump();
            }
        }
    }

}
