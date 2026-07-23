using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public int Wood;
    public int Stone;
    public float Money;


    public Seed[] Seeds;

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
}
