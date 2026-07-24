using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class WatermelonController : MonoBehaviour
{
    InputAction move;
    public float moveSpeed;
    public Camera camera;
    public Transform child;
    public float time;
    IEnumerator rotator;
    public float rotSpeed;

    private Vector2 lastMove;
    private Rigidbody rb;
    private Vector3 targetPosition;

    public static bool canMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = move.ReadValue<Vector2>().normalized;
        targetPosition = transform.position + moveSpeed * Time.deltaTime * new Vector3(moveInput.x, 0, moveInput.y);

        if (canMove && moveInput != Vector2.zero)
        {
            if  (moveInput != lastMove) DoRotate(moveInput);
        }
        else if (rotator != null)
        {
            StopCoroutine(rotator);
        }
        lastMove = moveInput;
        RaycastHit hit;
        Debug.DrawRay(transform.position, -transform.up*10f, Color.red);

        
        // check if player is on the farm land or not
        // its not working right now and I have no clue why, a debug draw ray shows the ray goes through the tiles, so I have no clue why this is not working.
        // if you find a solution, leave what you did in a comment so I can know for the future.
        if (Physics.Raycast(this.transform.position, -transform.up, out hit, 10f))
        {
            Debug.Log(time);
            if (!hit.collider.CompareTag("Farm")) time--;
            
        }



        
        if (time <= 0) Die();
    }
    private void Die()
    {

    }

    void FixedUpdate()
    {
        if (canMove && !GetComponentInChildren<Caster>().Cast())
        {
            rb.MovePosition(targetPosition);
        }
        rb.linearVelocity = Vector3.zero;
    }

    void DoRotate(Vector2 moveInput)
    {
        float target = Mathf.Rad2Deg * Mathf.Atan2(moveInput.y, -moveInput.x) + 90;

        if (rotator != null) StopCoroutine(rotator);
        rotator = DoRotate();
        StartCoroutine(rotator);

        IEnumerator DoRotate()
        {
            while (Mathf.Abs(child.rotation.eulerAngles.y - target) > 0) 
            {
                child.rotation = Quaternion.Euler(0, Mathf.MoveTowardsAngle(child.rotation.eulerAngles.y, target, rotSpeed * Time.deltaTime), 0);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
