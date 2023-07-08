using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTwo : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Waypoint waypoint;
    [SerializeField] private float healthinit = 20;
    [SerializeField] private float nowHealth = 20;
    public Slider slider;
    public Animator animator;
    public bool onMouseEnter;
    public bool onMouseExit;
    private int _currentWaypointIndex;
    public Vector3 CurrentPointPosition => waypoint.GetWaypointPosition(_currentWaypointIndex);
    private void Start()
    {
        animator = GetComponent<Animator>();
        healthinit = 20f;
        nowHealth = 20f;
        _currentWaypointIndex = 0;
        slider = GetComponentInChildren<Slider>();
    }
    private void Update()
    {
        Move();
        if (CurrentPointPositionReached())
        {
            UpdateCurrentIndex();
        }
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, moveSpeed * Time.deltaTime);
    }
    private bool CurrentPointPositionReached()
    {
        float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;
        if (distanceToNextPointPosition < 0.1f)
        {
            return true;
        }
        return false;
    }
    private void UpdateCurrentIndex()
    {
        int lastWaypointIndex = waypoint.Points.Length - 1;
        if (_currentWaypointIndex <= lastWaypointIndex)
        {
            _currentWaypointIndex++;
        }
        else
        {
            animator.SetTrigger("DIE");
            CursorManager.Instance.AddCoins(30);
            //ûд
            Invoke("DestroyWhole", 0.4f);
        }
    }
    public void DestroyWhole()
    {
        gameObject.SetActive(false);
    }
}
