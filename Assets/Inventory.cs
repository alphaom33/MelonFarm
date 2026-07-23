using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.U2D.Physics;

public class Inventory : MonoBehaviour
{
    public int Wood;
    public int Stone;
    public float Money;


    //List of seeds

    public List<Seed> Seeds;

    [System.Serializable]
    // Class for seeds
    public class Seed
    {
        public string Name;
        public float MoneyMult;
        public int SeedAmount;
        public char Varient;

    }

    private void Start()
    {
        // test line
        Seeds.Add(new Seed() { Name = "Gold", MoneyMult = 2, Varient = 'G' });

        // this would be put in a seed pickup, for example.
        foreach (Seed s in Seeds)
        {
            if (s.Name == "Gold") s.SeedAmount++;
        }
    }
}
