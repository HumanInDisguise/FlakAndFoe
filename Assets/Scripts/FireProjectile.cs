using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectiles

{
    public class FireProjectile : MonoBehaviour
    {
        // The header is simply a label that will appear in the Inspector.
        [Header("Public references")]
        public Transform bulletOrigin; // where to instantiate bullet
        public Transform mineOrigin; // where to place
        public GameObject bullet;
        public GameObject mine;
        public AudioClip gunSound;
        public AudioClip landMineSound;
        public GameObject impactEffect; // what to instantiate where bullet hits shootable object



        [Header("Settings")]
        public float timeBetweenBullets = 0.15f;
        public float timeBetweenLandMines = 0.5f;
        public float effectsDisplayTime = 0.08f;
        public float lineRange = 100f; // length of line drawn

        // Private variables:
        float timer;
        float effectsTimer;
        AudioSource audioSource;
        LineRenderer lineRenderer;   // ref to line renderer
        Ray shootRay = new Ray();    // a ray cast from projectile origin forwards
        RaycastHit hitResult;
        int shootableMask;

        void Start()
        {
            // Give 'audiosource' a value
            audioSource = bulletOrigin.GetComponent<AudioSource>();

            // Give 'lineRenderer' a value
            lineRenderer = bulletOrigin.GetComponent<LineRenderer>();

            // Give 'shootableMask' a value
            // Returns the number of our 'shootable' layer
            shootableMask = LayerMask.GetMask("Shootable");
        }

        // Update is called once per frame
        void Update()
        {
            // Tie 'timer' to the game clock
            timer += Time.deltaTime;        // counts up
            effectsTimer -= Time.deltaTime; // counts down


            // If fire1 input is received
            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)

            {

                // Set 'gunSound' as the current audio clip
                audioSource.clip = gunSound;


                // We use a method to fire the bullet
                FireBullet();
                // reset timer for next bullet
                timer = 0;

                // start the effects timer
                effectsTimer = effectsDisplayTime;

            }

            // If Fire2 input is received
            if (Input.GetButton("Fire2")&& timer >= timeBetweenLandMines)

            {
                // Set 'landminesound' as the current audio clip
                audioSource.clip = landMineSound;

                // call the 'placemine' method below
                PlaceMine();

                // Reset the timer for the next mine
                timer = 0;
            }


                // when the effects timer reaches zero
                if (effectsTimer <= 0)
            {
                // Run DisableEffects method below
                    DisableEffects();
            }
        }

        void FireBullet()
        {
            //Testing that the fire method is being called
            // Debug.Log("FIring bullet");

            // Instantiate the bullet at the point of origin
            Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);

            // stop the particle system (if its already playing)
            bulletOrigin.GetComponent<ParticleSystem>().Stop();

            // play the particle system

            bulletOrigin.GetComponent<ParticleSystem>().Play();

            // turn on the light
            bulletOrigin.GetComponent<Light>().enabled = true;

            // Turn on the line renderer 
            lineRenderer.enabled = true;

            // Set the point at which to begin drawing the line
            lineRenderer.SetPosition(0, bulletOrigin.position);

            // Set the point at which to begin the raycast
            shootRay.origin = bulletOrigin.forward;

            // If the raycast hits something
            if (Physics.Raycast(shootRay, out hitResult, lineRange, shootableMask))
            {
                // Set end position of line to be the point where the raycast hit
                lineRenderer.SetPosition(1, hitResult.point);

                // Instantiate the bullet impact effect at the ppint of the impact
                Instantiate(impactEffect, hitResult.point, Quaternion.identity);


            }

            else // if we dont hit anything
            {
                // Draw a 100-unit line (lineRange) in the forward direction
                lineRenderer.SetPosition(1, shootRay.origin + shootRay.direction * lineRange);
            }

            // Play the bang sound
            audioSource.Play();

        }

        void PlaceMine()
        {
            // Play the landmine sound
            audioSource.Play();

            // Instantiate the mine prefab at the referencec location
            Instantiate(mine, mineOrigin.position, mineOrigin.rotation);
        }

        void DisableEffects()
        {
            // Turn off the light
            bulletOrigin.GetComponent<Light>().enabled = false;

            // turn off the line renderer
            lineRenderer.enabled = false;


        }


    }
}
