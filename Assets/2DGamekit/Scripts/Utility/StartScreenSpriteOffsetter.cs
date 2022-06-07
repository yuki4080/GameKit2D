using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class StartScreenSpriteOffsetter : MonoBehaviour {

        Controls input;
        public float spriteOffset;
        Vector3 initialPosition;
        Vector3 newPosition;

        private void Start()
        {
            input = new Controls();
            input.Enable();

            initialPosition = transform.position;
        }

        void Update ()
        {
            transform.position = new Vector3 ((initialPosition.x + (spriteOffset * input.UI.Point.ReadValue<Vector2>().x)), (initialPosition.y + (spriteOffset * input.UI.Point.ReadValue<Vector2>().y)), initialPosition.z);
            //transform.position = new Vector3((initialPosition.x + (spriteOffset * Input.mousePosition.x)), (initialPosition.y + (spriteOffset * Input.mousePosition.y)), initialPosition.z);
        }
    }
}