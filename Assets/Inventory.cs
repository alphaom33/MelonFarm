using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public int Wood;
    public int Stone;
    public float Money;
    public float PlotCost;


    public Seed[] Seeds;
    public List<PlantController> plants = new();

    public void Start()
    {
        Seeds = Resources.LoadAll<Seed>("Seeds");
        foreach (Seed seed in Seeds)
        {
            seed.number = 0;
        }
    }

    public Seed[] GetSeeds()
    {
        return Seeds.Where(s => s.number > 0).ToArray();
    }

    public void AddPlant(PlantController plant)
    {
        plants.Add(plant);
    }

    public float SellPlants()
    {
        return plants.Sum(p => p.sellPrice);
    }
}
