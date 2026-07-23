using UnityEngine;

[CreateAssetMenu(fileName = "Seed", menuName = "Scriptable Objects/Seed")]
public class Seed : ScriptableObject
{
    public Sprite icon;
    public new string name;
    public string perks;
    public int number;
}
