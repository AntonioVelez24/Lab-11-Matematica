using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float descendForce;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();  
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (transform.position.y < -5 || transform.position.y > 5)
        {
            EndGame();
        }
    }
    public void ReadJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }        
    public void ReadDescend(InputAction.CallbackContext context)
    {      
        if (context.performed)
        {
            _rigidbody.AddForce(Vector3.down * descendForce, ForceMode.Impulse);
        }
    }
    void EndGame()
    {
        Time.timeScale = 0; 
    }
}
