using System;
using UnityEngine;

namespace Animation
{
    public class animation : MonoBehaviour
    {
        public Animator animator;
        Vector2 gameMovement;
        

        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
            gameMovement.x = Input.GetAxisRaw("Horizontal");
            gameMovement.y = Input.GetAxisRaw("Vertical");
            
            animator.SetFloat("horizontal", gameMovement.x);
            animator.SetFloat("vertical", gameMovement.y);
            animator.SetFloat("speed", gameMovement.sqrMagnitude);
        }
    }
}
