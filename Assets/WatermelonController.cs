using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class WatermelonController : MonoBehaviour
{
    InputAction move;
    public float moveSpeed;

    public Transform child;

    IEnumerator rotator;
    public float rotSpeed;
    public string WatermelonType;

    //char varient would be first letter of varient, G for gold for example.
    public char Varient;

    private Vector2 lastMove;
    private Rigidbody rb;
    private Vector3 targetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position;
        WatermelonType = "Normal";
    }

    public void RemoveVarient()
    {
        //this would run when you are wanting to change varients, before you change the variable "Varient"
        char Var = Varient;

        switch (Varient)
        {
            case 'G':
                //reverse effect if varient
                break;



        }
    }
    public void AddVarient()
    {
        //this would run when you are wanting to change varients, after you change the variable "Varient"

        switch (Varient)
        {
            case 'G':
                // add effect of varient
                break;

        }
    }


        // Update is called once per frame
        void Update()
        {
            Vector2 moveInput = move.ReadValue<Vector2>().normalized;
            targetPosition = transform.position + moveSpeed * Time.deltaTime * new Vector3(moveInput.x, 0, moveInput.y);

            if (moveInput != Vector2.zero)
            {
                if (moveInput != lastMove) DoRotate(moveInput);
            }
            else if (rotator != null)
            {
                StopCoroutine(rotator);
            }
            lastMove = moveInput;

        }

        void FixedUpdate()
        {
            if (!GetComponentInChildren<Caster>().Cast())
            {
                rb.MovePosition(targetPosition);
            }
            else
            {
                Debug.Log("Hit ground");
            }
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

