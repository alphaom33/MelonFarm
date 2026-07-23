using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    public void Plant()
    {
        GameObject.FindWithTag("PlanterUI").GetComponent<PlanterUI>().OpenUI();
    }
}
