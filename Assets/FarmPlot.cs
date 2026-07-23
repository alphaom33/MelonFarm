using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    PlanterUI planterUI;
    Seed seed;

    void Start()
    {
        planterUI = GameObject.FindWithTag("PlanterUI").GetComponent<PlanterUI>();
    }

    public void Plant()
    {
        planterUI.OpenUI(this);
    }

    public void SetSeed(Seed seed)
    {
        this.seed = seed;
        Instantiate(Resources.Load<GameObject>("Plants/" + seed.name), transform).transform.localScale = Vector3.one * 10;
    }
}
