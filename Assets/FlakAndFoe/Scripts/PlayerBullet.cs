using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThePlayerBullet
{

    public class PlayerBullet : MonoBehaviour
    {

        [Header("Bullet Settings")]
        public float speed = 30;


        // Start is called before the first frame update
        void Start()
        {
            //	Gives the bullet forward force when instantiated
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        }

    }
}