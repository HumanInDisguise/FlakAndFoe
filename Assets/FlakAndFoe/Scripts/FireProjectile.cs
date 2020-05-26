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
        public Transform bulletOrigin01;
        public GameObject bullet;

        [Header("Settings")]
        public float timeBetweenBullets = 0.15f;

        // Private variables:
        float timer;

        // Update is called once per frame
        void Update()
        {
            // Tie 'timer' to the game clock
            timer += Time.deltaTime;


            // If fire1 input is received
            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)

            {
                // We use a method to fire the bullet
                FireBullet();
                // reset timer for next bullet
                timer = 0;

            }
        }

        void FireBullet()
        {
            //Testing that the fire method is being called
            // Debug.Log("FIring bullet");

            // Instantiate the bullet at the point of origin
            Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);
            Instantiate(bullet, bulletOrigin01.position, bulletOrigin01.rotation);


        }



    }
}
