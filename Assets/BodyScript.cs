using UnityEngine;

public class BodyScript : MonoBehaviour
{
    [System.Serializable]
    public class SeedAdd
    {
        public Seed seed;
        public int amount = 1;
    }

    public int stone;
    public int wood;
    public SeedAdd[] seeds;
    public bool pickup;

    public void AddToInventory()
    {
        Inventory inv = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
        inv.Stone += stone;
        inv.Wood += wood;
        foreach (SeedAdd seedAdd in seeds)
        {
            seedAdd.seed.number += seedAdd.amount;
        }
        Destroy(gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        if (pickup && other.gameObject.TryGetComponent(out Inventory _))
        {
            AddToInventory();
        }
    }
}
