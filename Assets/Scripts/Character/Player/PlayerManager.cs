using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BO
{
    public class PlayerManager : CharacterManager
    {

        Vector3 camOffset = new Vector3(0, 2, -2);

        PlayerLocomotionManager playerLocomotionManager;
        protected override void Awake()
        {
            base.Awake();

            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }
        private void Start()
        {
            Transform camera = Camera.main.transform;
            camera.parent = this.transform;
            camera.localPosition = camOffset;

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

