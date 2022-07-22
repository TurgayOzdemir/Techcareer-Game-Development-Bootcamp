using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;


    [SerializeField] private GameObject ballPosition;

    [SerializeField] private float speed = 3f;

    private Vector3 _movement;
    private int _score = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ballPosition.transform.position = gameObject.transform.position;

        rb.AddForce(_movement.normalized * speed * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        _movement = new Vector3(x, 0f, z);  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            if (_score>=15)
            {
                Scene scene = SceneManager.GetActiveScene();
                if (scene.name == "Level1")
                {
                    SceneManager.LoadScene("Level2");
                }
                else
                {
                    SceneManager.LoadScene("Level1");
                }
                
                
            }     
            
        }
     
        if (other.CompareTag("Gameover"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
        if (other.CompareTag("Coin"))
        {
            _score+=1;
            Destroy(other.gameObject);
        }
    }

}
