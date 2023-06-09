using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BO
{
    public class PlayerLocomotionManager : CharacterLocomotionManager
    {
        PlayerManager player;
        public float verticalMovement;
        public float horizontalMovement;
        public float moveAmount;

        private Vector3 moveDirection;
        [SerializeField] float walkingSpeed = 2f;
        [SerializeField] float runningSpeed = 5f;


        protected override void Awake()
        {
            base.Awake();

            player = GetComponent<PlayerManager>();
        }


        public void HandleAllMovement()
        {
            HandleGroundedMovement();
        }

        private void GetVerticalAndHorizontalInputs()
        {
            verticalMovement = PlayerInputManager.instance.verticalInput;
            horizontalMovement = PlayerInputManager.instance.horizontalInput;

            //CLAMP THE MOVEMENTS
        }

        private void HandleGroundedMovement()
        {
            GetVerticalAndHorizontalInputs();
            moveDirection = PlayerCamera.instance.transform.forward * verticalMovement;
            moveDirection = moveDirection + PlayerCamera.instance.transform.right * horizontalMovement;
            moveDirection.Normalize();
            moveDirection.y = 0;


            if(PlayerInputManager.instance.moveAmount > 0.5f)
            {
                player.characterController.Move(moveDirection * runningSpeed * Time.deltaTime);
            }
            else if(PlayerInputManager.instance.moveAmount <= 0.5f)
            {
                player.characterController.Move(moveDirection * walkingSpeed * Time.deltaTime);

            }
        }
    }
}
