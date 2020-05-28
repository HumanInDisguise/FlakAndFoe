using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThePlayerBullet
{

    public class PlayerBullet : MonoBehaviour
    {

        [Header("Bullet Settings")]
        public float speed = 30;
        public float bulletLifetime = 1f;


        // Start is called before the first frame update
        void Start()
        {
            //	Gives the bullet forward force when instantiated
            gameObject.GetComponent<Rigidbody>().AddRelativeForce
            (Vector3.forward * speed, ForceMode.Impulse);

            // Destroy the bullet after an amount of time
            Destroy(gameObject, bulletLifetime);
        }

        void OnCollisionEnter(Collision other)
        {
            // Destroy the bullet
            Destroy(gameObject);
        }
    }

 





































   
}

    
	

    
