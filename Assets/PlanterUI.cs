using UnityEngine;
using UnityEngine.InputSystem;

public class PlanterUI : MonoBehaviour
{
    public GameObject child;

    public InputAction closeUI;

    public void OpenUI()
    {
        child.SetActive(true);
        child.transform.LookAt(Camera.main.transform);
        WatermelonController.canMove = false;
    }

    void Start()
    {
        child.SetActive(false);
        closeUI = InputSystem.actions.FindAction("Cancel");
    }

    void Update()
    {
        if (closeUI.triggered)
        {
            child.SetActive(false);
            WatermelonController.canMove = true;
        }
    }
}
