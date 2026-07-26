using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int Wood;
    public int Stone;
    public float Money;
    public float PlotCost;


    public Seed[] Seeds;
    public float sellAmount;

    public TMP_Text moneyDisp;

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

    public void AddPlant(PlantConroller plant)
    {
        Money += plant.sellPrice;
    }

    void Update()
    {
        moneyDisp.text = Money.ToString();
    }
}
