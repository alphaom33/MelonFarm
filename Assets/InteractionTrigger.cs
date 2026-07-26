using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractionTrigger : MonoBehaviour
{
    InputAction interact;
    bool pressed;
    bool lastCanMove;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        if (WatermelonController.canMove != lastCanMove && !lastCanMove && interact.IsPressed())
        {
            pressed = true;
        }
        lastCanMove = WatermelonController.canMove;

        if (interact.WasReleasedThisFrame())
        {
            pressed = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (lastCanMove && !pressed && interact.IsPressed() && other.TryGetComponent(out Interactor interactor))
        {
            interactor.TriggerInteract();
            pressed = true;
        }
    }
   
}
