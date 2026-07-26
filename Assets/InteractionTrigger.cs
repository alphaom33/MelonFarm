using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractionTrigger : MonoBehaviour
{
    InputAction interact;
    bool pressed;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        if (interact.WasReleasedThisFrame())
        {
            pressed = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!pressed && interact.IsPressed() && other.TryGetComponent(out Interactor interactor))
        {
            interactor.TriggerInteract();
            pressed = true;
        }
    }
   
}
