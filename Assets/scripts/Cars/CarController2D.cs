// 文件名：CarController2D.cs
using UnityEngine;

public class CarController2D : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] waypoints; // 路径点数组
    private int currentWaypointIndex = 0;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        // 移动到当前路径点
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        // 检查是否到达路径点
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // 循环路径
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            gameManager.EndGame();
        }
    }
}