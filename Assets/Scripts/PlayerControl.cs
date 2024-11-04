using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private float descendForce;
    [SerializeField] private float horizontalPushForce;
    [SerializeField] private float verticalPushForce;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject gameOverPanel;
    private Rigidbody _rigidbody;
    private bool crashed = false;
    private float stunTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();  
    }
    // Update is called once per frame
    void Update()
    {
        PlayerRotation();
        if (transform.position.y < -15 || transform.position.y > 16)
        {
            EndGame();
        }
        if (transform.position.y < -15 || transform.position.y > 16)
        {
            EndGame();
        }
        if (transform.position.x <= -27)
        {
            EndGame();
        }
    }
    void FixedUpdate()
    {
        if (crashed == true)
        {
            if (stunTime < 3)
            {
                stunTime = stunTime + Time.deltaTime;
                _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, _rigidbody.velocity.z);               
            }
            else
            {
                stunTime = 0;
                crashed = false;
            }
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
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("LowObstacle"))
        {
            _rigidbody.AddForce(Vector3.left * horizontalPushForce, ForceMode.Impulse);
            _rigidbody.AddForce(Vector3.up * verticalPushForce, ForceMode.Impulse);
            crashed = true;
        }
        if (collision.CompareTag("HighObstacle"))
        {
            _rigidbody.AddForce(Vector3.left * horizontalPushForce, ForceMode.Impulse);
            _rigidbody.AddForce(Vector3.down * verticalPushForce, ForceMode.Impulse);
            crashed = true;
        }
    }
    private void PlayerRotation()
    {
        float rotationValue = Mathf.Clamp(_rigidbody.velocity.y * rotationSpeed, -65f, 65f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotationValue);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    void EndGame()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
}
