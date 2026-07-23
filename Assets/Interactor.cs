using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    public UnityEvent interactEvent;

    public void TriggerInteract()
    {
        interactEvent.Invoke();
    }
}
