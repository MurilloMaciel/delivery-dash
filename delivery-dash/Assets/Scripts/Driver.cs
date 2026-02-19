using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 200F;
    [SerializeField] private float boostSpeed = 10F;
    [SerializeField] private float regularSpeed = 5F;
    [SerializeField] private float currentSpeed;
    
    [SerializeField] private TMP_Text boostText;

    private void Start()
    {
        currentSpeed = regularSpeed;
        boostText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boost"))
        {
            currentSpeed =  boostSpeed;
            boostText.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        currentSpeed =  regularSpeed;
        boostText.gameObject.SetActive(false);
    }

    private void Update()
    {
        var steer = 0f;
        var move = 0f;
        
        if (Keyboard.current.wKey.isPressed)
        {
            move = currentSpeed;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -currentSpeed;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = steerSpeed;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -steerSpeed;
        }
        
        var moveAmount = move * Time.deltaTime;
        var steerAmount = steer * Time.deltaTime;
        
        transform.Translate(0f, moveAmount, 0f);
        transform.Rotate(0f, 0f, steerAmount);
    }
}
