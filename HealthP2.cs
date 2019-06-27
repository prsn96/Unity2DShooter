using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthP2 : MonoBehaviour
{

    public float _health;
    public float _currenthealth;
    public float _armor;
    public float maxHP = 100;
    float armourAbsorbtionRate = 0.75f;
    [SerializeField]
    private TMPro.TextMeshProUGUI _HP1;
    [SerializeField]
    private TMPro.TextMeshProUGUI Armor2;
    [SerializeField]
    private SpriteRenderer sprt;
    [SerializeField]
    private BoxCollider2D box;
    [SerializeField]
    private Rigidbody2D body;
    //[SerializeField]
    //private TMPro.TextMeshProUGUI DeathMsg;
    //[SerializeField]
    //private GameObject DeathScreen;
    //[SerializeField]
    //private Button respawn;
    private bool ded;
    private bool spawned = false;
    private StarterProjectile _proj;
    private float reduction = 0.75f;

    private GameManager _manager;
    [SerializeField]
    private BarScript bar;
    
    public float Health
    {
        get => _currenthealth;
        set => _currenthealth = Mathf.Clamp(_health, 0, maxHP);
    }
    // Start is called before the first frame update

    private void Awake()
    {
        
        

    }
    void Start()
    {
      
        _manager = FindObjectOfType<GameManager>();
        _proj = GetComponent<StarterProjectile>();
        //DeathScreen.SetActive(false);
        _currenthealth = _health;
        spawned = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        //string randomMessage = deathMessages[Random.Range(0, deathMessages.Length)];

        //DeathMsg.text = randomMessage.ToString();
        _HP1.text = _currenthealth.ToString();
        bar.HandleBarP2();
        Armor2.text = _armor.ToString();
        if (_currenthealth <= 0)
        {
            
            print("Ded");
            Dead();
            ded = true;
            



        }
    }

    public void Dead()
    {
        
        


        
        
            spawned = false;
        _currenthealth = 100;
        _armor = 0;
        GameManager.ScoreP1 = GameManager.ScoreP1 + 5;
            StartCoroutine(Respawn(gameObject, GameManager.RespawnTime));
            
        
        
       
        
    }
    IEnumerator Respawn(GameObject gameObject, float waitTime)
    {
        
        
            yield return new WaitForSeconds(waitTime);
           

            
            
            //DeathScreen.SetActive(false);
            gameObject.SetActive(true);

            Transform _sp = _manager.SpawnPoints[Random.Range(0, _manager.SpawnPoints.Length)];
            gameObject.transform.position = _sp.position;
            spawned = true;
            ded = false;
        
        


    }
    public void TakeDamage(float damage)
    {
        _armor = Mathf.Max(0, _armor);
        float armourDam = Mathf.Min(_armor, damage * armourAbsorbtionRate);
        float healthDam = damage - armourDam;

        _armor -= armourDam;
        _currenthealth -= healthDam;

        //damage = damage - _armor/ 3;
        // _currenthealth -= damage;
        // print(damage);

    }
}
