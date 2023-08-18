/*編集履歴
ライフをゲームマネージャーで管理するように
ダメージを受けた後の一定時間の無敵時間を追加
→無敵時間の長さはinvincibilityTime_maxで管理

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class player_controller : MonoBehaviour
{

	
	public GameObject bulletPlayerPrefab;
    public GameObject bladePrefab;
    public GameObject Gamemanager_obj;
    public GameObject player_death_effect;
    private SpriteRenderer sprite;
    public AudioClip se_shoot;
    public AudioClip se_slash;
    public AudioClip se_hitted;
    private Animator animator; 
    AudioSource audioSource;
    

    public int radius = 1;
    public float speed = 3f;
	public float fireRate = 0.2f;
    public float slash_cooldown;
    public float slash_cooldownmax = 5f;
    public float invincibilityTime_max = 1f;
    public float invincibilityTime;
    private int flash_i;
    private float MoveRange_x = 8.6f;
    private float MoveRange_y = 4.5f; 
    private float nextfire = 0f;
    


    [SerializeField]private float speed_tmp = 3f; 
    [SerializeField]private bool Is_slow = false;
    private Rigidbody2D rb;	
    private gamemanager Gamemanager;
    /*空中戦(メインステージ)かの判定*/
    public bool Is_airBattle;

    /*地上戦のみで使用*/
    public int jump_max = 1;
    [SerializeField]private int jump_now = 0;
    [SerializeField]private float jump_force = 100f; 
	[SerializeField]private bool Is_grounded = false;
    [SerializeField]private bool Is_jumping = false;

	

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        Gamemanager_obj = GameObject.Find("Gamemanager");
        Gamemanager = Gamemanager_obj.GetComponent<gamemanager>();


        rb=GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        rb.gravityScale = 30;
        
        CircleCollider2D collider = GetComponent<CircleCollider2D> ();
        collider.radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
        if(Gamemanager.Is_paused == false)
        {            
            
            player_move();
            player_shoot();
            player_slash();
            limitate_move_range();
            player_gravity();
            /*地上戦*/
            if(Is_airBattle == false)
            {
                player_jump();            
                grounding_evaluation();
            }
        }
    }

    void FixedUpdate()
    {
        if(invincibilityTime > 0) 
        {
            invincibilityTime -= Time.deltaTime;
        }
    }
    
    void player_move()
    {
        /*上下左右の入力による移動*/
        if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-Time.deltaTime*speed, 0, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Time.deltaTime*speed, 0, 0);
		}
        if ((Input.GetKey (KeyCode.UpArrow))&&(Is_airBattle==true)) {
			transform.Translate (0, Time.deltaTime*speed, 0);
		}
		if (Input.GetKey ((KeyCode.DownArrow))&&(Is_airBattle==true)) {
			transform.Translate ( 0, -Time.deltaTime*speed, 0);
		}



        /*低速移動*/
        if(Is_slow==false) speed_tmp=speed;	

		if(Input.GetKey(KeyCode.LeftControl)) {
			speed=1f;
			Is_slow=true;
		}

		if(Input.GetKeyUp(KeyCode.LeftControl)) {
		speed=speed_tmp;
		Is_slow=false;
		}


    /*没処理

        /*着陸
        if((Input.GetKeyDown(KeyCode.S))&&(Is_grounded==true)&&(Is_landing==false)){ 
		Is_landing=true;
		SpeedUp(3f);	
			}

        /*飛行
		else if((Input.GetKeyDown(KeyCode.S))&&(Is_grounded==false)&&(Is_landing==true)){
			Is_landing=false;
			SpeedUp(-3f);
			}
    */

    }

    void player_shoot()
    {
        
        if (Input.GetKey (KeyCode.Space)&&nextfire<=0f) {
             audioSource.PlayOneShot(se_shoot);
			Instantiate (bulletPlayerPrefab, transform.position, Quaternion.identity);
			nextfire=fireRate;
		}
		if(nextfire>=0f){
			nextfire-=Time.deltaTime;
	        }
        
    }

    void player_slash()
    {
        slash_cooldown -=Time.deltaTime;
        if((Input.GetKeyDown(KeyCode.X))&&(slash_cooldown < 0f))
        {
            audioSource.PlayOneShot(se_slash);
            Instantiate(bladePrefab,new Vector3(transform.position.x + 0.5f,transform.position.y,transform.position.z), Quaternion.identity);   
            slash_cooldown = slash_cooldownmax;
        }
                
    }
    void limitate_move_range()
    {    /*プレイヤーの移動範囲の制限*/
    	float x = Mathf.Clamp(transform.position.x,-MoveRange_x,MoveRange_x);
		float y = Mathf.Clamp(transform.position.y,-MoveRange_y,MoveRange_y);        
		transform.position=new Vector3(x,y,transform.position.z);
    }


    void player_gravity()
    {
        /*着陸中の重力の有効化*/
        if(Is_airBattle==false) rb.bodyType = RigidbodyType2D.Dynamic;
        /*飛行時の重力の無効化*/
        else rb.bodyType = RigidbodyType2D.Static;
    }

    /*接地判定(着陸ではない)*/
    void grounding_evaluation(){
        if (transform.position.y <= -MoveRange_y) 
        {
            Is_grounded=true;
            if(rb.velocity.y<=0) rb.velocity = new Vector2(rb.velocity.x , 0);

        }
        else Is_grounded=false;

    }
    void player_jump()
    {
        if((Input.GetKeyDown(KeyCode.UpArrow))&&(jump_now<jump_max))
        {
            if(rb.velocity.y<0) rb.velocity = new Vector2(rb.velocity.x,0);
            rb.AddForce(Vector2.up * jump_force,ForceMode2D.Impulse);
            jump_now++;
        
        }
        if ((Is_grounded==true)&&!(Input.GetKey(KeyCode.UpArrow))) jump_now=0;
        else Is_jumping=false;
    }

    IEnumerator flash()
    {
        while(invincibilityTime > 0)
        {
            yield return null;
        }
        animator.SetBool("flashing", false);
    }




/*～～～ここから他の構造体からの操作が可能～～～*/
    public void SpeedUp(float rise_speed)
    {
		if(Is_slow==true) speed_tmp+=rise_speed;
		else			  speed+=rise_speed;
	}

    public void FireRateUp(float rise_firerate)
    {
        fireRate+=rise_firerate;
    }
    public void MaxJumpNumberUp(int rise_max_jump)
    {
        jump_max += rise_max_jump;
    }
    public void hit ()
    {
        if(invincibilityTime <= 0)
        {
            Gamemanager.PC_Life -=1;

            if(Gamemanager.PC_Life > 0)
            {
                audioSource.PlayOneShot(se_hitted);
                invincibilityTime = invincibilityTime_max;
                animator.SetBool("flashing", true);
                StartCoroutine("flash");
            }
            else
            {
                Instantiate(player_death_effect, transform.position, Quaternion.Euler(0f, 0f, 0));
                Gamemanager.SendMessage("onPlayerDeath");
                Destroy(gameObject);
            }
            
        }
    }

    public void LifeUp()
    {
    if(Gamemanager.PC_Life_MAX > Gamemanager.PC_Life) Gamemanager.PC_Life +=1;
    }
}

	

