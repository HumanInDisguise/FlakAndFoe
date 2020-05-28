using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClarkJustin
{

    public class PlayerControl : MonoBehaviour
    {
        public Rigidbody rb;
        public float thrust = 300f;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // FixedUpdate is called once per physics solve
        void FixedUpdate()
        {
            // This declares a private variable of type 'float', names
            // it 'vertical' and get the vertical axis values, i.e.
            // up and down arrows or w and s keys
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            // if vertical DOES NOT equal zero (as a float)


            rb.AddForce(new Vector3(horizontal, 0f, vertical) * thrust);


            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouseHit;

            // if the raycast hits layer 8 (MouseTracker), then…
            if (Physics.Raycast(mouseRay, out mouseHit, Mathf.Infinity, 1 << 9))
            {
                // make the character point towards the mouse
                transform.LookAt(new Vector3(mouseHit.point.x, transform.position.y, mouseHit.point.z));
            }


        }


        

    }
}
