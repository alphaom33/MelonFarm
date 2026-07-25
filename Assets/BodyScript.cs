using UnityEngine;

public class BodyScript : MonoBehaviour
{
    public int stone;
    public int wood;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<WatermelonController>() != null)
        {
            Debug.Log("gotem");
            Inventory Inv = other.gameObject.GetComponentInChildren<Inventory>();
            Inv.Stone += stone;
            Inv.Wood += wood;
            //add in something after we figure out how seeds in the inventory work.
            Destroy(this.gameObject);

        }
    }
}
