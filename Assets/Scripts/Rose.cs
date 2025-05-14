using UnityEngine;

public class Rose : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private RoseManager roseManager;

    private void Start()
    {
        roseManager = RoseManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collusion)
    {
        if(collusion.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            roseManager.ChangeRoses(value);
            Destroy(gameObject);
        }
    }
}
