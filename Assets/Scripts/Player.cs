using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;

    private Vector3 movement;
    private bool simulateInertia;
    private Vector3 velocity;
    private Transform rbTransform;

    private void OnEnable()
    {
        GlobalManager.OnFinishReached.AddListener(ResetPlayer);
    }

    private void Start()
    {
        rbTransform = rb.transform;
    }

    void Update()
    {
        if (Game.IsGameOn)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.z = Input.GetAxis("Vertical");

            movement = Vector3.ClampMagnitude(movement, speed);

            if (simulateInertia)
            {
                rb.AddForce(-velocity * speed * Time.deltaTime);

                if (rb.velocity.magnitude <= 0.1f)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    velocity = Vector3.zero;
                }
            }
            else
            {
                velocity = Vector3.zero;
            }

            if (Input.GetKeyDown(KeyCode.W) ||
                Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.D)
                )
            {
                simulateInertia = false;
            }
            else if (Input.GetKeyUp(KeyCode.W) ||
                Input.GetKeyUp(KeyCode.S) ||
                Input.GetKeyUp(KeyCode.A) ||
                Input.GetKeyUp(KeyCode.D)
                )
            {
                {
                    simulateInertia = true;
                    velocity = rb.velocity;
                }
            }

            if (rbTransform.position.y <= -5f)
            {
                ResetPlayer();
                GlobalManager.SendFallingDown();
            }
        }
    }

    private void FixedUpdate()
    {
        if(Game.IsGameOn && movement != Vector3.zero)
        {
            rb.AddForce(movement * speed * Time.deltaTime);
        }
    }

    private void ResetPlayer()
    {
        gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rbTransform.position = Vector3.zero + Vector3.up * 0.35f;
    }
}
