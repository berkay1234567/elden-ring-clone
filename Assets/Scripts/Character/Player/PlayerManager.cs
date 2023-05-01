using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BO
{
    public class PlayerManager : CharacterManager
    {

        PlayerLocomotionManager playerLocomotionManager;
        protected override void Awake()
        {
            base.Awake();

            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }

        protected override void Update()
        {
            base.Update();

            //IF WE ARE NOT THE OWNER, WE DO NOT CONTROL
            if (!IsOwner) return;
            playerLocomotionManager.HandleAllMovement();
        }
    }
}

