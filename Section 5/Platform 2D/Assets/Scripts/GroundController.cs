using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    InputHandler inputHandler;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        inputHandler = player.GetComponent<InputHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            inputHandler.SetIsGrounded(true);
        }
    }
}
