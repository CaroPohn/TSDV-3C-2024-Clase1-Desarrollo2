using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class InputReader : MonoBehaviour
    {
        public CharacterMovement characterMovement;

        public void HandleMoveInput(InputAction.CallbackContext context)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

            if(characterMovement != null )
            {
                characterMovement.Move(moveDirection);    
            }
        }
    }

}
