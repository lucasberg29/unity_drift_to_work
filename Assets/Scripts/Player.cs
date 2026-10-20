using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{ 

    private bool carMoving = false;
    private bool hasFaultedStart = false;
    private float singleMovement = 15.0f;
    private Vector3 startPosition;

    [Header("Player Info")]
    public const int maxCarHealth = 1000;
    public int carHealth = 1000;
    public float carSpeed = 25.0f;
    public float minimunSpeedForDrift = 1.0f;
    public Collider playerCollider;
    public Rigidbody playerRigidbody;
    public Animator animator;
    public GameObject leftSnowTrail;
    public GameObject rightSnowTrail;
    public Slider healthBarSlider;

    [Header("Enemy Info")]
    public Collider[] enemyCollider;

    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
        
        startPosition = transform.position;
    }

    void Update()
    {
        //Movement of the player car left and right
        if (Input.touchCount > 0)
        {
            if(animator.GetBool("FinishedFaking") ==  true)
            {
                hasFaultedStart = true;
            }
            else if(animator.GetBool("IsMoving") == false)
            {
                animator.SetBool("FakeStart", true);
            }

            if(!carMoving && hasFaultedStart)
            {
                StartCar();
            }

            Touch touch = Input.GetTouch(0);

            if (startPosition == null)
            {
                startPosition = touch.position;
            }

            if (Input.touches[0].position.x > startPosition.x || Input.touchCount > 1)
            {
                MoveLeft();
            }
            else if (Input.touches[0].position.x < startPosition.x || Input.touchCount > 1)
            {
                MoveRight();
            }

            startPosition = touch.position;
        }

        Vector3 playerCurrentSpeed = playerRigidbody.linearVelocity;
        if (playerCurrentSpeed.x > minimunSpeedForDrift)
        {
            animator.SetBool("IsTurningLeft", false);
            animator.SetBool("IsTurningRight", true);
        }
        else if(playerCurrentSpeed.x < (- minimunSpeedForDrift))
        {
            animator.SetBool("IsTurningLeft", true);
            animator.SetBool("IsTurningRight", false);
        }
    }

    void FakeStart()
    {
        hasFaultedStart = true;
        animator.SetBool("IsMoving", true);
    }

    void StartCar()
    {
        playerRigidbody.AddForce(new 
            Vector3(transform.position.x, transform.position.y, carSpeed), ForceMode.Impulse);

        carMoving = true;
        animator.SetBool("IsMoving", carMoving);

        leftSnowTrail.SetActive(true);
        rightSnowTrail.SetActive(true);

        StartCoroutine(Ui.instance.FadeText());
    }

    void MoveLeft()
    {
        playerRigidbody.AddForce(new Vector3(singleMovement, 0, 0));
    }

    void MoveRight()
    {
        playerRigidbody.AddForce(new Vector3(-singleMovement, 0, 0));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;

        if (GetDragDirection(dragVectorDirection) == DraggedDirection.Left)
        {
            MoveLeft();
        }
        else if (GetDragDirection(dragVectorDirection) == DraggedDirection.Right)
        {
            MoveRight();
        }
    }

    private enum DraggedDirection
    {
        Up,
        Down,
        Right,
        Left
    }

    private DraggedDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);

        DraggedDirection draggedDir;
        if (positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
        }
        else
        {
            draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
        }
        return draggedDir;
    }

    #region Collisions

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Curb")
        {
            DamagePlayer(1);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Curb")
        {
            DamagePlayer(1);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Curb")
        {
            playerRigidbody.AddForce(new Vector3(0, 0, carSpeed - playerRigidbody.linearVelocity.z), ForceMode.Impulse);
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        switch(tag)
        {
            case "Enemy":
                animator.SetBool("IsHit", true);
                DamagePlayer(100);
                break;

            case "Finish":
                Debug.Log("You win!");
                
                break;

            case "HP":
                HealPlayer(100);
                break;

            default:
                Debug.Log("Untagged collider");
                break;
        }
    }

    #endregion

    public void DamagePlayer(int hitpoints)
    {
        if (hitpoints < this.carHealth)
        {
            this.carHealth = carHealth - hitpoints;
        }
        else
        {
            this.carHealth = 0;

            GameManager.Defeat();
        }

        carHealth = carHealth - hitpoints;

        healthBarSlider.value = (float)carHealth / maxCarHealth;

    }

    public void HealPlayer(int hitpoints)
    {
        //if (hitpoints < this.carHealth)
        //{
        //    this.carHealth = carHealth - hitpoints;
        //}
        //else
        //{
        //    this.carHealth = 0;

        //    GameManager.Defeat();
        //}

        if (carHealth + hitpoints > maxCarHealth)
        {
            carHealth = maxCarHealth;
        }
        else
        {
            carHealth = carHealth + hitpoints;
        }

        healthBarSlider.value = (float)carHealth / maxCarHealth;
    }
}
