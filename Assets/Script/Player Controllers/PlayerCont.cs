using System.Collections;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float[] lanePosition = {-6.0f,-3.0f, 0, 3, 6.0f};
    private int currentLane = 4;
    public float laneChangeSpeed = 10.0f;
    public float forwardSpeed = 10.0f;
    private Vector3 targetPositon = Vector3.zero;

    private bool isGrounded = true;
    private Rigidbody rb;
    public float jumpForce;

    private float crouchHeight = 0.5f;
    private float normalHeight = 2.0f;
    public CharacterController characterController;

    public Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator.applyRootMotion = false;
    }
    void Update()
    {
        CharacterMovement();

        if (Input.GetKeyDown(KeyCode.B))
        {
            characterController.height = crouchHeight;
            StartCoroutine("Retrieval");

        }
    }

    void CharacterMovement()
    { 
        // x pos
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < lanePosition.Length - 1)
            {
                currentLane++;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 0)
            {
                currentLane--;
            }
        }
        // jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
            isGrounded = false;
        }

        targetPositon = new Vector3(lanePosition[currentLane], transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPositon, laneChangeSpeed * Time.deltaTime);

        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
    }
    IEnumerator Retrieval()
    {
        yield return new WaitForSeconds(1.0f);
        characterController.height = normalHeight;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("road"))
        {
            isGrounded = true;
        }
    }

}
