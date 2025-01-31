using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{ 
    public DressChanger dressChanger; 
    [SerializeField]private Player_Movement _playerMovement;
   [SerializeField] private Player_Interaction _playerInteraction;
   [SerializeField] private Button settings;
   [SerializeField] private Button pause;
   [SerializeField] private Button reload;

    void Awake()
    {
        // Initialize dependencies
        _playerMovement = GetComponent<Player_Movement>();
        _playerInteraction = GetComponent<Player_Interaction>();
        dressChanger = GetComponent<DressChanger>();
    }

    void Update()
    {
        _playerMovement.HandleMovement();
    }

    void OnTriggerEnter(Collider other)
    {
        _playerInteraction.HandleInteraction(other, _playerMovement);
    }

    
}


    
