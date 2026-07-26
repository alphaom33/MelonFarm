using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractionTrigger : MonoBehaviour
{
    InputAction interact;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
    }

    void OnTriggerStay(Collider other)
    {
        if (interact.WasPressedThisFrame() && other.TryGetComponent(out Interactor interactor))
        {
            interactor.TriggerInteract();
        }

    }
   
}
