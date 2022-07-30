using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    CollisionController collisionController;

    [SerializeField] TMP_Text appleCount = null;

    private int _appleCount;

    private void Awake()
    {
        collisionController = GetComponent<CollisionController>();
    }

    private void Update()
    {
        _appleCount = collisionController.GetApple();
        appleCount.text = _appleCount + " / 10";
    }
}
