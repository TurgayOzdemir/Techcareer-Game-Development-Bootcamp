using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    private int _appleCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            _appleCount++;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (collision.gameObject.CompareTag("End"))
        {
            if (_appleCount>=10)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public int GetApple()
    {
        return _appleCount;
    }




}
