using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Quotizer : MonoBehaviour
{
    public TMP_Text amountDisplay;
    public float amount;
    public int[] levels;
    public int idx;
    public DeathTimer deathTimer;

    void Start()
    {
        UpdateMoneyDisp();
    }

    void UpdateMoneyDisp()
    {
        amount = levels[idx];
        amountDisplay.text = "x" + amount.ToString();
    }

    public void Pay()
    {
        Inventory Inv = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
        float cost = Mathf.Min(amount, Inv.Money);
        amount -= cost;
        Inv.Money -= cost;

        if (amount == 0)
        {
            deathTimer.ResetTime();
            idx++;
            if (idx >= levels.Length)
            {
                SceneManager.LoadScene("Win");
                return;
            }

            UpdateMoneyDisp();
        }
    }
}
