using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractionTrigger : MonoBehaviour
{
    InputAction interact;
    Interactor interactor;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        if (interact.WasPerformedThisFrame() && interactor != null)
        {
            interactor.TriggerInteract();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Interactor interactor))
        {
            this.interactor = interactor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Interactor interactor))
        {
            this.interactor = null;
        }
    }
   
}
