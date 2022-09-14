using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float verticalSpeed;

    [SerializeField]
    private float horizontalSpeed;

    private float verticalMoveSpeed;
    private float horizontalMoveSpeed;

    [Header("Movement Clamps")]
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minX;

    private float progress;

    [Header("References")]
    [SerializeField]
    private Rigidbody rigidbodyComponent;

    [SerializeField]
    private GameObject startLine;
    [SerializeField]
    private GameObject finishLine;

    private bool canMove;

    public static PlayerMovement playerMovement;

    public float VerticalSpeed { get => verticalSpeed; set => verticalSpeed = value; }
    public float HorizontalSpeed { get => horizontalSpeed; set => horizontalSpeed = value; }
    public float VerticalMoveSpeed { get => verticalMoveSpeed; set => verticalMoveSpeed = value; }
    public float HorizontalMoveSpeed { get => horizontalMoveSpeed; set => horizontalMoveSpeed = value; }

    private void Awake()
    {
        if (playerMovement == null)
        {
            playerMovement = this;
        }

        rigidbodyComponent = GetComponent<Rigidbody>();

        Vector3 startPosition = new Vector3(startLine.transform.position.x,
            transform.position.y, startLine.transform.position.z);
        transform.position = startPosition;
    }

    void Start()
    {
        horizontalMoveSpeed = horizontalSpeed;
        verticalMoveSpeed = verticalSpeed;
    }
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y, transform.position.z);

        progress = (transform.position.z - startLine.transform.position.z) /
            (finishLine.transform.position.z - startLine.transform.position.z);

        UserInterfaceManager.userInterfaceManager.ShowProgress(progress);
    }

    private void FixedUpdate()
    {
        float xMov = 0;

        if (IsPlayerCanMove())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    xMov = (raycastHit.point.x - transform.position.x) * 5;
                }
            }

            rigidbodyComponent.velocity = new Vector3(xMov * horizontalMoveSpeed,
                rigidbodyComponent.velocity.y, verticalMoveSpeed);
        }
        else
        {
            rigidbodyComponent.velocity = Vector3.zero;
        }
    }
    public void CantMove()
    {
        //Debug.Log("CantMove Player");
        canMove = false;
    }
    public void CanMove()
    {
        //Debug.Log("CanMove Player");
        canMove = true;
    }
    public bool IsPlayerCanMove()
    {
        return canMove;
    }
}
