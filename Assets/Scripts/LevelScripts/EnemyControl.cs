using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement;

public class EnemyControl : MonoBehaviour
{
    public static EnemyControl SharedInstance;
    public GameObject player;
    Transform target;
    public Bullet_Spawn spawnBullet;
    public Game_Control game_Control;
    public Text enemyHealth;
    public Animator anim;
    public GameObject Explosion;
    private AudioSource myAud;

    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        Explosion = GameObject.Find("Explosion");
        myAud = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        game_Control = FindObjectOfType<Game_Control>();
        player = GameObject.Find("Player");
        target = player.transform;    
        Fire();
    }


    void Update()
    {
        if(MenuManager.Instance.LevelNum > 1) //if (Game_Control.SharedInstance.Level > 1) //move enemy when level 3 starts.        
        {
            anim.SetBool("Stop", true);
        }
        else
        {
            anim.SetBool("Stop", false);
        }
        //rotate towards player.
        var offset = 90f;
        Vector2 direction = target.position - transform.position; //get the direction of the target.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// to set angle wrt to position of target.
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));//rotate towards target with initial offset.

    }

    void Fire()
    {
        myAud.Play();
        spawnBullet.Spawn();
        Invoke("Fire", 5f);// start firing every 5 seconds to the player
    }

    public void DestroEnemy()
    {
        Explosion.transform.position = this.transform.position;
        Explosion.GetComponent<ParticleSystem>().Play();
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "PlayerBullet")
        {

            game_Control.EnemyHealth();
            other.gameObject.SetActive(false);

        }

    }
}
