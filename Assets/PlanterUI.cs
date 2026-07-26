using UnityEngine;
using UnityEngine.InputSystem;

public class PlanterUI : MonoBehaviour
{
    public GameObject child;

    public InputAction closeUI;
    FarmPlot plot;

    public void OpenUI(FarmPlot plot)
    {
        if (plot.plant == null && GameObject.FindWithTag("Inventory").GetComponent<Inventory>().GetSeeds().Length == 0) return;

        child.GetComponentInChildren<PlanterList>().plot = plot;
        child.SetActive(true);
        WatermelonController.canMove = false;
        this.plot = plot;
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
            CloseUI();
        }
    }

    public void CloseUI()
    {
        child.SetActive(false);
        WatermelonController.canMove = true;
    }

    public void SetSeed(Seed seed)
    {
        plot.SetSeed(seed);
        CloseUI();
    }
}
