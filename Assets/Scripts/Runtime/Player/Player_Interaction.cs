using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Player_Interaction : MonoBehaviour
{
    public PlayerData playerData1;
     [SerializeField] private Animator _characterAnimator;
   public Groom_Interaction groom_Interaction;
 public Player_Movement player_Movement;
   [SerializeField] private ParticleSystem confetti1; 
   [SerializeField] private ParticleSystem confetti2; 
    private int _cashCollected = 0;
    private int _badChoices = 0;
    public GameObject failUI;
    [SerializeField] private GameObject gemchoice;
    [SerializeField] private GameObject safechoice;
    [SerializeField] private GameObject bookchoice;
    [SerializeField] private GameObject bedchoice;
    [SerializeField] private GameObject weddingchoice;
    [SerializeField] private GameObject casualchoice;
    [SerializeField] private TMPro.TMP_Text scoreText;
    private int score;
    public int maxBeauty = 10;
    public int currentBeauty;
    public BeautyBar beautyBar;
    public GameObject healthbar;
    void Start()
    {
        
        currentBeauty = maxBeauty;
        beautyBar.SetMaxBeauty(maxBeauty);
    }
    


    public void HandleInteraction(Collider other, Player_Movement playerMovement)
    {
        
        PlayerData playerData = new PlayerData();
        if (other.CompareTag("Stagenew"))
        {
            healthbar.SetActive(false);
            playerMovement.StopMovement();
            camerafollow camerafollow1 = FindObjectOfType<camerafollow>();
            camerafollow1.StartRotate();
            TriggerConfetti();

            if (score >= 30)
            {
                _characterAnimator.SetTrigger("StageReached");
                groom_Interaction.GroomAnimation();
            }
            else if (score < 30)
            {
                _characterAnimator.SetTrigger("StageReached2");
              groom_Interaction.GroomAnimation2();
              
              failUI.SetActive(true);
            }
        }
        else if (other.CompareTag("Dustbin") || other.CompareTag("cone"))
        {
            _characterAnimator.SetTrigger("Stumble");
        }
        else if (other.CompareTag("end"))
        {
            _characterAnimator.SetTrigger("stop");
            playerMovement.StopMovement();
           StartCoroutine(playerMovement.WaitAndResumeMovement());
          
           
        }
        else if (other.CompareTag("cash"))
        {
            _cashCollected++;
            score += 10;
            saveScore(score);
            scoreText.text = score.ToString();
            AddBeauty(2);
            
            GameObject.Destroy(other.gameObject);
            
            if (score>=30)
            {
                _characterAnimator.SetTrigger("CashCollect");
            }
        }
        else if (other.CompareTag("gem_choice"))
        {
           Destroy(gemchoice);
           gemchoice.SetActive(false);
        }
        else if (other.CompareTag("safe_choice"))
        {
            Destroy(safechoice);
            safechoice.SetActive(false);
        }
        else if (other.CompareTag("bed_choice"))
        {
            Destroy(bedchoice);
            bedchoice.SetActive(false);
        }
        else if (other.CompareTag("book_choice"))
        {
            Destroy(bookchoice);
            bookchoice.SetActive(false);
        }
        else if (other.CompareTag("casual_choice"))
        {
            if (score > 0)
            {
                score -= 10;
                saveScore(score);
                scoreText.text = score.ToString();
            }
            TakeDamage(1);
            Destroy(casualchoice);
            casualchoice.SetActive(false);
        }
        else if (other.CompareTag("wedding_choice"))
        {
            score += 10;
            saveScore(score);
            scoreText.text =score.ToString();
            
            Destroy(weddingchoice);
            weddingchoice.SetActive(false);
            AddBeauty(2);
        }
       
        else if (other.CompareTag("baditem"))
        {
            _badChoices++;
            GameObject.Destroy(other.gameObject);

            if (score > 0)
            {
                score -= 10;
                saveScore(score);
                scoreText.text = score.ToString();
                TakeDamage(1);
            }

          
            if (score < 30)
            {
                _characterAnimator.SetTrigger("Sad");
            }
        }
    }

    public void TriggerConfetti()
    {
        if(confetti1!=null&&confetti2!=null)
        {
            confetti1.Play();
            confetti2.Play();
        }
    }

    public void StartWalking()
    {
        _characterAnimator.SetTrigger("isWalking");
      
    }


    public class PlayerData
    {
        public int score;
    }

    public void saveScore(int score)
    {
        PlayerData playerData = new PlayerData();
        playerData.score = score;
        string json = JsonUtility.ToJson(playerData);
       File.WriteAllText(Application.dataPath + "/Data/savefile.txt", json);
       Debug.Log("/playerData.json");
       PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
       Debug.Log(json);
      
    }

    void TakeDamage(int damage)
    {
        currentBeauty -= damage;
        beautyBar.SetMaxBeauty(currentBeauty);
    }

    void AddBeauty(int amount)
    {
        currentBeauty += amount;
        beautyBar.SetMaxBeauty(currentBeauty);
    }
}
