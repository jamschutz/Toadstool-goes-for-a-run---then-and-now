using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsch
{
    public class PlayerCharacterController : MonoBehaviour
    {
    // =============================================================== //
    // =========     Variables              ========================== //
    // =============================================================== //

        // ----- public vars ----------- //
        [Header("Movement")]
        public float moveSpeed;
        public Camera camera;

        [Header("Physics")]
        public LayerMask groundLayerMask;
        public Transform feetPosition;


        // ----- private vars ----------- //
        private Rigidbody rb;

        // movement helpers
        private float currentMoveLerp;
        private int numJumpsUsed;

        // physics helpers
        private const float MAX_IS_GROUNDED_DISTANCE = 0.1f;
        private float verticalVelocity;
        private bool isGrounded;
        private bool justJumped;


    // =============================================================== //
    // =========     Lifecycle Methods      ========================== //
    // =============================================================== //

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            currentMoveLerp = 0;
            verticalVelocity = 0;
            numJumpsUsed = 0;
            justJumped = false;
        }


        void Update()
        {
            // perform grounded check once per frame
            isGrounded = IsGrounded();
            if(isGrounded && !justJumped) numJumpsUsed = 0;

            if(Input.GetKey(KeyCode.Space)) {
                float rotation = Camera.main.transform.eulerAngles.y;
                transform.eulerAngles = new Vector3(0, rotation, 0);
            }
        }


        void FixedUpdate()
        {
            Move();
        }


        void Move()
        {
            Vector3 currentMovement = Vector3.zero;

            // if we're currently moving, move!
            if(Input.GetKey(KeyCode.Space)) {
                currentMovement = Vector3.forward * moveSpeed;
            }

            Vector3 movement = camera.transform.right * currentMovement.x;
            movement += camera.transform.forward * currentMovement.z;
            movement.y = 0;
            Vector3 newPos = transform.position + (movement * Time.deltaTime);
            rb.position = newPos;
        }


        void AllowJumpsAgain()
        {
            justJumped = false;
        }


    // =============================================================== //
    // =========     Physics Methods        ========================== //
    // =============================================================== //

        public bool IsGrounded()
        {
            // set feet position to center of object, minus half the character controller's height
            // Vector3 feetPosition = transform.position - (Vector3.up * (controller.height * 0.5f));
            // check if we're grounded
            return Physics.CheckSphere(feetPosition.position, MAX_IS_GROUNDED_DISTANCE, groundLayerMask);
        }
    }
}