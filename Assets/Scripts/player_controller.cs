using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class playercontoller : MonoBehaviour
{

	
	public GameObject bulletPrefab;

    public int jump_max = 1;
	public float speed = 0.02f;
	public float fireRate = 0.2f;
    [SerializeField]private int jump_now = 0;
    private float MoveRange_x = 7f;
    private float MoveRange_y = 4.5f; 
    private float nextfire = 0f;
    [SerializeField] private float speed_tmp=0f; 
    [SerializeField] private float jump_force=100f;
	[SerializeField]private  bool Is_grounded = false;
	[SerializeField]private bool Is_slow=false;
    [SerializeField]private bool Is_jumping=false;
    [SerializeField]private bool Is_landing = false;

    private Rigidbody2D rb;
    /*Rigidbody2DのGravity Scaleをある程度大きくする必要がある*/
	

	

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        player_move();
        player_shoot();
        player_jump();
        player_gravity();
        grounding_evaluation();
        player_slash();
    }
    
    void player_move()
    {
        /*上下左右の入力による移動*/
        if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-speed, 0, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (speed, 0, 0);
		}
        if ((Input.GetKey (KeyCode.UpArrow))&&(Is_landing==false)) {
			transform.Translate (0, speed, 0);
		}
		if (Input.GetKey ((KeyCode.DownArrow))&&(Is_landing==false)) {
			transform.Translate ( 0, -speed, 0);
		}

        /*プレイヤーの移動範囲の制限*/
    	float x = Mathf.Clamp(transform.position.x,-MoveRange_x,MoveRange_x);
		float y = Mathf.Clamp(transform.position.y,-MoveRange_y,MoveRange_y);        
		transform.position=new Vector3(x,y,transform.position.z);

        /*低速移動*/
        if(Is_slow==false) speed_tmp=speed;	

		if(Input.GetKey(KeyCode.LeftControl)) {
			speed=0.01f;
			Is_slow=true;
		}

		if(Input.GetKeyUp(KeyCode.LeftControl)) {
		speed=speed_tmp;
		Is_slow=false;
		}

        /*着陸*/
        if((Input.GetKeyDown(KeyCode.S))&&(Is_grounded==true)&&(Is_landing==false)){ 
		Is_landing=true;
		SpeedUp(0.04f);	
			}

        /*飛行*/
		else if((Input.GetKeyDown(KeyCode.S))&&(Is_grounded==false)&&(Is_landing==true)){
			Is_landing=false;
			SpeedUp(-0.04f);
			}
    }

    void player_shoot()
    {
        if (Input.GetKey (KeyCode.Z)&&nextfire<=0f) {
			Instantiate (bulletPrefab, transform.position, Quaternion.identity);
			nextfire=fireRate;
		}
		if(nextfire>=0f){
			nextfire-=Time.deltaTime;
	        }
    }

    void player_gravity()
    {
        /*着陸中の重力の有効化*/
        if(Is_landing==true) rb.bodyType = RigidbodyType2D.Dynamic;
        /*飛行時の重力の無効化*/
        else rb.bodyType = RigidbodyType2D.Static;
    }



    /*接地判定(着陸ではない)*/
    void grounding_evaluation(){
        if (transform.position.y<=-4.5f) /*||*乗れる設置物に乗っていたら*/
        {
            Is_grounded=true;
            if((rb.velocity.y<=0)&&(Is_landing==true)) rb.velocity = new Vector2(rb.velocity.x , 0);

        }
        else Is_grounded=false;

    }
    void player_jump()
    {
        if((Input.GetKeyDown(KeyCode.UpArrow))&&(Is_jumping==false)&&(jump_now<jump_max)&&(Is_landing==true))
        {
            if(rb.velocity.y<0) rb.velocity = new Vector2(rb.velocity.x,0);
            rb.AddForce(Vector2.up * jump_force,ForceMode2D.Impulse);
            jump_now++;
        
        }
        if((rb.velocity.y>1)&&(Is_landing==true)) Is_jumping=true;
        if ((Is_grounded==true)&&!(Input.GetKey(KeyCode.UpArrow))) jump_now=0;
        else Is_jumping=false;
    }

    void player_slash()
    {

        /*If((Input.GetKeyDown(KeyCode.X))&&(IS_landing==true))
        {
        }    
        */
    
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
}

	

