using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Fungus;
using TMPro;

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
    public float playerhealth = 10f;
    public GameObject Somethingtodestroy;
    public float heartamount = 0;
    public GameObject HealthPopup;
    public TextMeshProUGUI HealthPopupText;
    public bool fifteenhealth = false;
    public GameObject HideoutEntrance;
    



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

        if (Input.GetKeyDown("3"))
        {
            Restart();
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
            animator.Play("Base Layer.Occam_Hammer_Quick");

            CanMove = false;
            yield return new WaitForSecondsRealtime(1f);
            Camshakescrpt.ShakeEvent();
            HammerUsed();
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

    public void GetHeart()
    {
        heartamount++;

        if (heartamount == 1)
        {
            HealthPopup.SetActive(true);
            HealthPopupText.SetText("You got 1 heart out of 3. Collect all 3 for an increase in max health");
        }

        if (heartamount == 3)
        {
            HealthPopup.SetActive(true);
            HealthPopupText.SetText("Max health increased!");
            playerhealth = 15f;
            fifteenhealth = true;
        }
    }

    public void HammerUsed()
    {
        if(Somethingtodestroy != null)
        {
            Destroy(Somethingtodestroy.gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Destroyable")
        {
            Somethingtodestroy = collision.gameObject;
        }

        if(collision.gameObject.tag == "Heart")
        {
            GetHeart();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Destroyable")
        {
            Somethingtodestroy = null;
        }
    }

    public void Restart()
    {
        HideoutEntrance = GameObject.Find("ToHideOut");
        gameObject.transform.position = HideoutEntrance.transform.position;
        SceneManager.LoadScene("Jon Scene1");
        if(fifteenhealth == true)
        {
            playerhealth = 15f;
        }
        else
        {
            playerhealth = 10f;
        }
        
    }


}
