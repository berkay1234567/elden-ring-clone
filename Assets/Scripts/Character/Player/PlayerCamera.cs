using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BO
{
    public class PlayerCamera : MonoBehaviour
    {
        public static PlayerCamera instance;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }


        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

