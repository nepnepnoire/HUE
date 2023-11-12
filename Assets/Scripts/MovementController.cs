using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    private bool Iscanjump = true;//�Ƿ�����Ծ��Ĭ�ϲ���
    Rigidbody2D rb2D;
    public float dropConst;//��׹����
    public float speed;//�����ƶ��ٶ�
    public float jumpspeedUp;//�����ٶ�
    public float jumpspeedVertiacal;//���������ƶ��ٶ�
    
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
        //��Ծ
        if (Input.GetKey(KeyCode.Space) && Iscanjump == true)
        {
            rb2D.velocity = new Vector2(0, jumpspeedUp);//���ø����ٶȣ���������
        }
        //��������
        if (rb2D.velocity.y > 0 && Input.GetKey(KeyCode.Space) && Iscanjump == false)
        {
            rb2D.velocity += Vector2.up * 0.2f;//������������õ������ٶ�
        }
        //�Ż��ָ�
        float a = dropConst * 5 - Mathf.Abs(rb2D.velocity.y);//ͨ����׹�����������ٶȿ�Ϊ0ʱ����׹����aԽ�󣬼�Խ���� �ȹ����״̬
        rb2D.velocity -= Vector2.up * a * Time.deltaTime;

        //�����ƶ�
        Vector3 vt = new Vector3(h, 0, 0).normalized;//vtΪ������ϵ�ϳɵķ���������normalized��λ��
        Debug.Log(v);
        //���������ƶ���Ϊ����jumpspeedVertiacal��
        if (h != 0 && Iscanjump == false)
        {
            gameObject.transform.Translate(vt * speed * jumpspeedVertiacal * Time.deltaTime);//ͨ�����������ʹ��vtʹ�������ƶ�
        }
        //���������ƶ�
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