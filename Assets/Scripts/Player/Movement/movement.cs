using System;
using UnityEngine;

namespace Movement
{
    public class movement : MonoBehaviour
    {
        public float moveSpeed = 5f;

        public Rigidbody2D rb;
        Vector2 gameMovement;    

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            gameMovement.x = Input.GetAxisRaw("Horizontal");
            gameMovement.y = Input.GetAxisRaw("Vertical");
        }
        void FixedUpdate()
        {
            rb.MovePosition(rb.position + gameMovement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
