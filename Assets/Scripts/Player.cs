using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D theRB;
    private Vector2 _direction;

    //Create a prop
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        theRB.MovePosition(theRB.position + _direction * moveSpeed * Time.fixedDeltaTime);
    }
}
