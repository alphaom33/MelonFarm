using UnityEngine;

public class PlanterList : MonoBehaviour
{
    GameObject seedCard;

    void OnEnable()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Seed seed in GameObject.FindWithTag("Farm").GetComponent<FarmController>().GetSeeds())
        {
            Instantiate(seedCard, transform);
        }
    }
}
