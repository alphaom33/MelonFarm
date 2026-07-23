using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    PlanterUI planterUI;

    void Start()
    {
        planterUI = GameObject.FindWithTag("PlanterUI").GetComponent<PlanterUI>();
    }

    public void Plant()
    {
        planterUI.OpenUI();
    }
}
