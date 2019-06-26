using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    /******Components define******/
    private Animator animator;
    private new Transform transform;

    /******flag fields******/
    private bool _isMove;//Whether the character is moving
    private bool _hasWeapon;//Whether the character hold a weapon

    public bool isMove { get {
            return _isMove;
        } set
        {
            _isMove = value;
            if(animator != null)
                animator.SetBool("isMove", value);
        } }
    public bool hasWeapon
    {
        get
        {
            return _hasWeapon;
        }
        set
        {
            _hasWeapon = value;
            if(animator != null)
                animator.SetBool("hasWeapon", value);
        }
    }
    /******public fields******/
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 5.0f;

    /******private fields******/
    private float hInput = 0.0f;
    private float vInput = 0.0f;

    private Vector3 dir; //charactor's direction

    /******Override methods******/

    // Start is called before the first frame update
    void Start()
    {
        //Init private fields
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();

        isMove = false;
        hasWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {
        /******character's move******/
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if (hInput != 0 || vInput != 0)
        {
            isMove = true;

            Vector3 moveDir = Vector3.forward * vInput + Vector3.right * hInput;
            transform.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.World);

            //float angle = Vector3.Angle(Vector3.back, moveDir.normalized);
            //Vector3 angle = Quaternion.FromToRotation(Vector3.back, moveDir.normalized).eulerAngles;
            //Debug.Log(angle);
            //transform.Rotate(angle - transform.rotation.eulerAngles);
        }
        else
        {
            isMove = false;
        }    
    }
    /******All public methods defined******/

    /******All private methods defined******/

}
