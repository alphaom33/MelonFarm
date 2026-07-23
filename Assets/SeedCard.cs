using UnityEngine;
using UnityEngine.UI;

public class SeedCard : MonoBehaviour
{

    public Seed seed;
    public Image icon;

    public void SetSeed(Seed seed)
    {
        this.seed = seed;
        icon.sprite = seed.icon;
    }
}
