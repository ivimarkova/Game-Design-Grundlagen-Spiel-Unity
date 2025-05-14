using UnityEngine;
using TMPro;

public class RoseManager : MonoBehaviour
{
    public static RoseManager instance;

    private int roses;
    [SerializeField] private TMP_Text rosesDisplay;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    private void OnGUI()
    {
        rosesDisplay.text = roses.ToString();
    }

    public void ChangeRoses(int amount)
    {
        roses += amount;
    }
}
