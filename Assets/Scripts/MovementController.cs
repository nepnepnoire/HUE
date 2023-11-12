using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    private bool Iscanjump = true;//是否能跳跃，默认不能
    Rigidbody2D rb2D;
    public float dropConst;//下坠常数
    public float speed;//地面移动速度
    public float jumpspeedUp;//上升速度
    public float jumpspeedVertiacal;//空中左右移动速度
    
    Animator animator;
    string animationState = "AnimationState";

   

    enum CharStates
    {
        walkEast=1,
        walkSouth=2,
        walkWest=3,
        walkNorth=4,
        idleSouth=5
    }
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateState();
    }
  
    void FixedUpdate()
    {
        MoveCharacter();
    }
    private void MoveCharacter()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //跳跃
        if (Input.GetKey(KeyCode.Space) && Iscanjump == true)
        {
            rb2D.velocity = new Vector2(0, jumpspeedUp);//设置刚体速度，给予向量
        }
        //长按高跳
        if (rb2D.velocity.y > 0 && Input.GetKey(KeyCode.Space) && Iscanjump == false)
        {
            rb2D.velocity += Vector2.up * 0.2f;//长按高跳额外得到向上速度
        }
        //优化手感
        float a = dropConst * 5 - Mathf.Abs(rb2D.velocity.y);//通过下坠常数，空中速度快为0时，下坠常数a越大，即越快速 度过这个状态
        rb2D.velocity -= Vector2.up * a * Time.deltaTime;

        //左右移动
        Vector3 vt = new Vector3(h, 0, 0).normalized;//vt为俩个轴系合成的方向向量，normalized单位化
        Debug.Log(v);
        //空中左右移动，为地面jumpspeedVertiacal倍
        if (h != 0 && Iscanjump == false)
        {
            gameObject.transform.Translate(vt * speed * jumpspeedVertiacal * Time.deltaTime);//通过这个函数来使用vt使得左右移动
        }
        //地面左右移动
        else { gameObject.transform.Translate(vt * speed * Time.deltaTime); }
    }

    private void UpdateState()
    {
        if(Input.GetKey(KeyCode.D))
        {
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharStates.idleSouth);
        }
    }


}