using UnityEngine;

public class DressChanger : MonoBehaviour
{
    public GameObject weddingDress; 
    public GameObject casualDress; 
    
    [SerializeField] private GameObject currentDress; 

    void Start()
    {
        if (currentDress == null)
        {
            Debug.LogWarning("Current dress is not set. Please assign it in the Inspector.");
        }
        else
        {
            currentDress.SetActive(true); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wedding dress"))
        {
            Debug.Log("Collided with Wedding Dress");
            ChangeDress(weddingDress, "Wedding");
            Destroy(other.gameObject); 
        }
       
        else if (other.CompareTag("casual dress"))
        {
            Debug.Log("Collided with Casual Dress");
            ChangeDress(casualDress, "Casual"); 
            Destroy(other.gameObject); 
        }
        else
        {
            Debug.Log("Triggered object is not a  dress.");
        }
    }

    void ChangeDress(GameObject newDress, string dressType)
    {
      
        if (currentDress != null)
        {
            Debug.Log($"Deactivating current dress: {currentDress.name}");
            currentDress.SetActive(false); 
        }
        else
        {
            Debug.LogWarning("No current dress to deactivate.");
        }

        newDress.SetActive(true);
        currentDress = newDress;
  
    }
}
