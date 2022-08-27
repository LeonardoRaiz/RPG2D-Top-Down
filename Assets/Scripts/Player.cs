using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rollSpeed;
    
    private Rigidbody2D theRB;


    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private Vector2 _direction;
    

    #region Getters and Setters
    //Create a prop
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool IsRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        initialSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        OnInput();
        OnRun();
        OnRolling();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement
    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void OnMove()
    {
        theRB.MovePosition(theRB.position + _direction * moveSpeed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = initialSpeed;
            _isRunning = false; 
        }
        
    }

    void OnRolling()
    {
        if(Input.GetMouseButtonDown(1))
        {
            moveSpeed = rollSpeed;
            _isRolling = true;
        }

        if(Input.GetMouseButtonUp(1))
        {
            moveSpeed = initialSpeed;
            _isRolling = false;
        }
    }
    #endregion
}
