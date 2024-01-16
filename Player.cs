using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private UnityEngine.Vector3 direction;

    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;

    private void Awake()
    {
        character = GetComponent<CharacterController>();

    }

    private void OnEnable()
    {
        direction = new UnityEngine.Vector3(-3,-1,0);
    }

    private void Update()
    {
        direction += gravity * Time.deltaTime * UnityEngine.Vector3.down;

        if (character.isGrounded)

        {
            direction = UnityEngine.Vector3.down;

            if (Input.GetButton("Jump")) 
            {

                direction = UnityEngine.Vector3.up * jumpForce;

            }

        }

        character.Move(direction * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Obstacle")) {

            GameManager.Instance.GameOver();

        }

    }

}
