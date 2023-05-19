using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private Animator myAnimator;
    [SerializeField] private CapsuleCollider2D myCollider;
    [SerializeField] private Tilemap map;
    [SerializeField] private GameObject dashPunchCollider;

    private Vector2 movementInput;
    private bool isSprinting = false;
    private bool isDashPunching = false;
    private bool isDashPunchCharging = false;
    [SerializeField] private float movementSpeed = 4;
    [SerializeField] private float sprintSpeed = 5f;
    [SerializeField] private Vector2 lastAimedDirectionNormalized = Vector2.zero;

    [Space(20f)]

    private bool isClicking;
    [Header("Dash")]
    [SerializeField] private float dashPunchTime;
    [SerializeField] private float minDashPunchTime, dashCooldownTime,
        dashPunchChargeTime, dashSpeed;
    private float dashPunchTimeCounter, dashCooldownTimeCounter, dashChargePercentage, dashPunchChargeTimeCounter;

    private void FixedUpdate()
    {
        //Aim();
        RotateCharacterFacingDirectionSprite();
        if (isSprinting && !isDashPunchCharging && !isDashPunching)
        {
            SprintMovement();
        }
        else
        {
            Movement();
        }
        DashPunchCharging();
        DashPunching();
        MovementAnimation();
    }

    private void Movement()
    {
        myRigidbody.velocity = new Vector2(
            movementInput.x * movementSpeed * (isDashPunchCharging ? 0.4f : 1f),
            movementInput.y * movementSpeed * (isDashPunchCharging ? 0.4f : 1f));
    }

    private void SprintMovement()
    {
        myRigidbody.velocity = new Vector2(movementInput.x * (movementSpeed + sprintSpeed),
            movementInput.y * (movementSpeed + sprintSpeed));
    }

    private void MovementAnimation()
    {
        myAnimator.SetFloat("HorizontalMovement", myRigidbody.velocity.x);
        myAnimator.SetFloat("VerticalMovement", myRigidbody.velocity.y);
    }

    private void RotateCharacterFacingDirectionSprite()
    {
        if (!isDashPunching)
        {
            Vector2 mousePosOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastAimedDirectionNormalized = (mousePosOnScreen - new Vector2(
                gameObject.transform.position.x,
                gameObject.transform.position.y)).normalized;
            IdleAnimation(lastAimedDirectionNormalized);
        }
    }

    private void IdleAnimation(Vector2 aimDirection)
    {
        myAnimator.SetFloat("HorizontalMousePosition", aimDirection.x);
        myAnimator.SetFloat("VerticalMousePosition", aimDirection.y);
    }


    private void Aim()
    {
        Vector2 mousePosOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lastAimedDirectionNormalized = (mousePosOnScreen - new Vector2(
            gameObject.transform.position.x,
            gameObject.transform.position.y)).normalized;
        //float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = rotation;
    }

    private void DoDashPunch()
    {

        if (Time.time >= dashCooldownTimeCounter)
        {
            dashPunchTimeCounter = Time.time + Mathf.Clamp((dashPunchTime * dashChargePercentage), minDashPunchTime, dashPunchTime);
            isClicking = false;
            Aim();
            print("DoDash");
            isDashPunching = true;

            dashPunchingColliderRotationAndOffset();
        }
    }

    private void dashPunchingColliderRotationAndOffset()
    {
        float angle = Mathf.Atan2(lastAimedDirectionNormalized.y, lastAimedDirectionNormalized.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        dashPunchCollider.transform.rotation = rotation;

        dashPunchCollider.transform.localPosition = lastAimedDirectionNormalized * (dashPunchCollider.transform.localScale.y + 0.15f);
    }

    private void DashPunching()
    {
        if (Time.time <=  dashPunchTimeCounter)
        {
            myRigidbody.velocity = lastAimedDirectionNormalized * dashSpeed;
            dashCooldownTimeCounter = Time.time + dashCooldownTime;
        }
        else
        {
            isDashPunching = false;
        }

    }

    private void DashPunchCharging()
    {
        if (isClicking && !isDashPunching && !isDashPunchCharging && Time.time >= dashCooldownTimeCounter)
        {   
            isDashPunchCharging = true;
            dashPunchChargeTimeCounter = Time.time + dashPunchChargeTime;
        }
        else if (!isClicking && isDashPunchCharging)
        {
            isDashPunchCharging = false;
            dashChargePercentageModifier();
            DoDashPunch();
        }
    }

    private void dashChargePercentageModifier()
    {
        float timeLeftToCharge = dashPunchChargeTimeCounter - Time.time - dashPunchChargeTime;
        dashChargePercentage = Math.Clamp(Math.Abs(
                1 / dashPunchChargeTime * timeLeftToCharge), 0f, 1f);
    }

    public void StopDashPunch()
    {
        dashPunchTimeCounter = 0f;

        // Change a few variables to stop the process of dash punching
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

   
    private void OnSprint(InputValue value)
    {
        float val = value.Get<float>();
        if (val > 0.5f)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    private void OnFire(InputValue value)
    {
        float clickValue = value.Get<float>();
        isClicking = clickValue == 1 ? true : false;
    }

    private void OnRMB(InputValue value)
    {
        Vector2 mousePosOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosOnScreen);
        print(gridPosition);
        gameObject.transform.position = map.CellToWorld(gridPosition);
    }
}

