using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public void Crash()
    {
        gameObject.SetActive(false);
        menu.SetActive(true);
    }
}
