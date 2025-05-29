using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    public GameObject hintText;

    void Start()
    {
        hintText.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PlayerMovement>())
        {
            hintText.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<PlayerMovement>())
        {
            hintText.SetActive(false);
        }
    }
}

