using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectiles

{
    public class FireProjectile : MonoBehaviour
    {
        // The header is simply a label that will appear in the Inspector.
        [Header("Public references")]
        public Transform bulletOrigin;
        public GameObject bullet;

        // Update is called once per frame
        void Update()
        {
            // If fire1 input is received
            if (Input.GetButton("Fire1"))
            {
                // We use a method to fire the bullet
                FireBullet();
            }
        }

        void FireBullet()
        {
            //Testing that the fire method is being called
            // Debug.Log("FIring bullet");

            // Instantiate the bullet at the point of origin
            Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);

        }



    }
}
