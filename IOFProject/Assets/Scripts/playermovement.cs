using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Fungus;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Animator animator;
    public RuntimeAnimatorController SportTunic;
    public RuntimeAnimatorController NormalAnimController;
    public CameraShakeScript Camshakescrpt;
    public bool HasHammer;
    public GameObject FireObject;
    public GameObject FireSpawnRight;
    public GameObject FireSpawnLeft;
    public bool facingRight;
    public bool HasLamp;
    public ShedScript Shedcrpt;
    public bool ShedUsed = false;
    public bool HasTunic = false;


    public Image black;
    public bool CanMove = true;
    public Flowchart Flwchrt;
    public GameObject blackscreenobject;
    
    

    private void Awake()
    {
   
    }

   private void Start()
    {

        CanMove = true;
        facingRight = true;
        ShedUsed = false;
        HasTunic = false;
        
    }
  
    
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        return;
        // input 

        if (CanMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (movement != Vector2.zero)
            {
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
            }
            animator.SetFloat("speed", movement.sqrMagnitude);

            float ScaleValue = 1 - (gameObject.transform.position.y / 10);
            gameObject.transform.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);
        }

        if(movement.x == 1)
        {
            facingRight = true;
        }else if (movement.x == -1)
        {
            facingRight = false;
        }
       

        if(Input.GetKeyDown("v"))
        {
            if(HasTunic)
            {
                ChangeTunic();
            }
            
        }

        if (Input.GetKeyDown("b"))
        {
            NormalTunic();
        }

        if (Input.GetKeyDown("1"))
        {
            StartCoroutine(Usehammer());
        }

        if (Input.GetKeyDown("2"))
        {
            UseFire();
        }
    }

    
    public void ToggleMove()
    {
        if(CanMove)
        {
            CanMove = false;
        }
        else
        {
            CanMove = true;
        }
    }

    public void ToggleBlackscreen()
    {
        if (blackscreenobject.gameObject.activeInHierarchy)
        {
            blackscreenobject.gameObject.SetActive(false);
        }
        else
        {
            blackscreenobject.gameObject.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        // movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void ChangeTunic()
    {
        animator.runtimeAnimatorController = SportTunic;
    }

    public void NormalTunic()
    {
        animator.runtimeAnimatorController = NormalAnimController;
    }

    public void GetLamp()
    {
        HasLamp = true;
    }

    public void UseFire()
    {
        if (HasLamp)
        {
            if (facingRight)
            {
                Instantiate(FireObject, FireSpawnRight.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(FireObject, FireSpawnLeft.transform.position, Quaternion.identity);
            }
        }
        
       
    }
    

    IEnumerator Usehammer()
    {
        if(movement == Vector2.zero && HasHammer)
        {
            CanMove = false;
            Camshakescrpt.ShakeEvent();

            yield return new WaitForSecondsRealtime(1f);
            CanMove = true;
            if(ShedUsed == false)
            {
                Shedcrpt.UsedHammer();
                ShedUsed = true;
                Flwchrt.SetBooleanVariable("ShedDone", true);
            }
        }
        
    }

}
