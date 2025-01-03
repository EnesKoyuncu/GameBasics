using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class characterControl : MonoBehaviour
{



    public float speed = 1.0f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector3 charPos;
    [SerializeField] private GameObject _camera;
    private SpriteRenderer _spriteRenderer;

    public float jumpForce = 5.0f;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();  
        charPos = transform.position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal")  == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", speed);
            transform.position = new Vector3(
            transform.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime),
            transform.position.y,
            transform.position.z);
            //UnityEngine.Debug.Log("Anlýk Hýz Degeri:  " + (Input.GetAxis("Horizontal") * speed * Time.deltaTime));
        }

        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }


        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            _animator.SetTrigger("jump");
            _rigidbody2D.velocity = new Vector3(_rigidbody2D.velocity.x, jumpForce);
            grounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Eðer zemin ile çarpýþma olursa grounded true yapýlýr
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            _animator.SetBool("grounded", true); // Animator'a yerde olduðunu bildir
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        // Eðer zemin ile temas kesilirse grounded false yapýlýr
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            _animator.SetBool("grounded", false); // Animator'a havada olduðunu bildir
        }
    }


private void LateUpdate()
    {
        _camera.transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
        
    }
}
