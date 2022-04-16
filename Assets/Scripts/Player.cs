using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]Transform groundCheckTransform;
    private Rigidbody2D rigidbodyComponent = null;
    private bool aPressed;
    private bool dPressed;
    private bool sPressed;
    private bool wPressed;
    [SerializeField] LayerMask playerMask;
    private IEnumerator coroutine;

    IEnumerator MyCoroutine(Collider2D other)
    {
        yield return new WaitForSeconds(5f);
        other.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            wPressed = true;

        }
        if (Input.GetKeyDown(KeyCode.D) == true)
        {
            dPressed = true;

        }
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            aPressed = true;

        }
        if (Input.GetKeyDown(KeyCode.S) == true)
        {
            sPressed = true;

        }

    }

    private void FixedUpdate()
    {

        if (dPressed == true)
        {
            rigidbodyComponent.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
            dPressed = false;
        }
        if (aPressed == true)
        {
            rigidbodyComponent.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
            aPressed = false;
        }
        if (sPressed == true)
        {
            rigidbodyComponent.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            sPressed = false;
        }
        if (rigidbodyComponent.position.y < -2f)
        {
            Debug.Log("fell");
            FindObjectOfType<GameEnd>().EndGame();
        }
        if (Physics2D.OverlapCircleAll(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
            
        }
        if (wPressed == true)
        {
            
                rigidbodyComponent.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            wPressed = false;

        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        
        

        if (other.gameObject.layer == 7) 
        {
            
            other.gameObject.SetActive(false);

            coroutine = MyCoroutine(other);
            StartCoroutine(coroutine);
        }
    }
}
