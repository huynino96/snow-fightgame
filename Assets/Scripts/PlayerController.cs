using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool faceLeft;
    public bool faceRight;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;

    public Transform groundCheckPoint;
    public bool isGrounded;

    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D theRB;

    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    public GameObject snowBall;
    public Transform throwPoint;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            faceLeft = true;
            faceRight = false;
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            faceLeft = false;
            faceRight = true;
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(throwBall) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject ballClone = (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if(theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } 
        else if(theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }

    public IEnumerator Knockback(float knockDur, float knockPwr, Vector3 knockDir)
    {
        float timer = 0;
        Debug.Log("Timer: " + timer + "Knock Dur: " + knockDur);

        while (knockDur > timer)
        {
            if(transform.position.x < 1 && transform.position.x > -1)
            {
                Debug.Log("run this close script");
                timer += Time.deltaTime;
                if(transform.position.x > -1 && transform.position.x <= 0)
                {
                    Debug.Log("Face Left: " + faceLeft);
                    theRB.AddForce(new Vector3((knockDir.x + -5) * 1000, knockDir.y * knockPwr, transform.position.z));
                }
                else if (transform.position.x < 1 && transform.position.x >= 0)
                {
                    Debug.Log("Face Right" + faceRight);
                    theRB.AddForce(new Vector3((knockDir.x + 5) * 1000, knockDir.y * knockPwr, transform.position.z));
                }
                
            }
            else
            {
                Debug.Log("run this far script");
                timer += Time.deltaTime;
                theRB.AddForce(new Vector3(knockDir.x * 1000, knockDir.y * knockPwr, transform.position.z));
            }
            
                
        }
        yield return 0;
    }
}