using System.Collections;
using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    public PlantConroller plant;
    public bool growing;

    void Start()
    {
    }

    public void Plant()
    {
        if (!growing) GameObject.FindWithTag("PlanterUI").GetComponent<PlanterUI>().OpenUI(this);
    }

    public void SetSeed(Seed seed)
    {
        StartCoroutine(SetSeed());
        IEnumerator SetSeed() {
            yield return new WaitForSeconds(5);
            GameObject plantObject = Instantiate(Resources.Load<GameObject>("Plants/" + seed.name), transform);
            plantObject.transform.localScale = new Vector3(plantObject.transform.localScale.x / transform.localScale.x, plantObject.transform.localScale.y / transform.localScale.y, plantObject.transform.localScale.z / transform.localScale.z);

            plant = plantObject.GetComponentInChildren<PlantConroller>();
            plant.seed = seed;
        }
    }
}
