using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    PlanterUI planterUI;
    public PlantController plant;

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
        GameObject plantObject = Instantiate(Resources.Load<GameObject>("Plants/" + seed.name), transform);
        plantObject.transform.localScale = new Vector3(plantObject.transform.localScale.x / transform.localScale.x, plantObject.transform.localScale.y / transform.localScale.y, plantObject.transform.localScale.z / transform.localScale.z);

        plant = plantObject.GetComponentInChildren<PlantController>();
    }
}
