using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    [SerializeField] private TMP_Text ballCountText = null;

    [SerializeField] private List<GameObject> balls = new List<GameObject>();

    [SerializeField] private float moveSpeed;

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float horizontalLimit;

    private float _horizontal;
    private bool _click;

    private PlayerInput _playerInput;
    private InputAction _clickAction;

    private int _gateValue;
    private int _targetCount;

    Scene scene;



    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _clickAction = _playerInput.actions["Click"];
    }
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    private void Update()
    {
        horizontalBallMove();
        forwardBallMove();
        updateBallCountText();
    }

    private void horizontalBallMove()
    {
        if (_click)
        {
            float _newX;
            _horizontal = Mouse.current.delta.x.ReadValue();
            _newX = transform.position.x + _horizontal * horizontalSpeed * Time.deltaTime;
            _newX = Mathf.Clamp(_newX, -horizontalLimit, horizontalLimit);
            transform.position = new Vector3(_newX, transform.position.y, transform.position.z);
        }
    }

    private void forwardBallMove()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void updateBallCountText()
    {
        ballCountText.text = balls.Count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StackBall"))
        {
            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(0, 0, balls[balls.Count - 1].transform.localPosition.z - 1f);
            balls.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("Gate"))
        {
            _gateValue = other.gameObject.GetComponent<GateController>().GetGateValue();
            _targetCount = balls.Count + _gateValue;
            if (_gateValue > 0)
            {
                increaseBallCount();
            }
            else if (_gateValue < 0)
            {
                decraseBallCount();
            }
        }
        if (other.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(scene.name);
        }
    }

    private void increaseBallCount()
    {
        for (int i = 0; i < _gateValue; i++)
        {
            GameObject _newBall = Instantiate(ballPrefab);
            _newBall.transform.SetParent(transform);
            _newBall.GetComponent<SphereCollider>().enabled = false;
            _newBall.transform.localPosition = new Vector3(0, 0, balls[balls.Count - 1].transform.localPosition.z - 1f);
            balls.Add(_newBall);
        }
    }

    private void decraseBallCount()
    {
        if (_targetCount >= 1)
        {
            for (int i = balls.Count - 1; i >= _targetCount; i--)
            {
                balls[i].SetActive(false);
                balls.RemoveAt(i);

            }
        }
        else
        {
            for (int i = balls.Count - 1; i > 0; i--)
            {
                balls[i].SetActive(false);
                balls.RemoveAt(i);

            }
        }
        
    }

    private void OnEnable()
    {
        _clickAction.started += _ => StartClick();
        _clickAction.canceled += _ => CancelClick();
    }


    private void OnDisable()
    {
        _clickAction.started -= _ => StartClick();
        _clickAction.canceled -= _ => CancelClick();
    }

    private void StartClick()
    {
        _click = true;
    }
    private void CancelClick()
    {
        _click = false;
    }

}
