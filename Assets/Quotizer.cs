using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Quotizer : MonoBehaviour
{
    public TMP_Text amountDisplay;
    public int amount;
    public int[] levels;
    public int idx;

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
        if (GameObject.FindWithTag("Inventory").TryGetComponent(out Inventory inv) && inv.Money >= amount)
        {
            inv.Money -= amount;
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
