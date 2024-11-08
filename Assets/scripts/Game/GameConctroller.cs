using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ComplexRoadGenerator : MonoBehaviour
{
    public Button startButton;
    public GameObject[] roadPrefabs; // 道路片段预制体数组
    public GameObject carPrefab; // 汽车预制体
    public int numberOfRoads = 10; // 要生成的道路片段数量

    void Start()
    {
        startButton.onClick.AddListener(GenerateComplexRoads);
    }

    void GenerateComplexRoads()
    {
        Vector2 lastPosition = Vector2.zero; // 初始位置
        Quaternion lastRotation = Quaternion.identity; // 初始旋转
        List<Transform> allWaypoints = new List<Transform>();

        for (int i = 0; i < numberOfRoads; i++)
        {
            // 随机选择一个道路片段预制体
            GameObject roadPrefab = roadPrefabs[Random.Range(0, roadPrefabs.Length)];
            
            // 实例化道路片段
            GameObject roadSegment = Instantiate(roadPrefab, lastPosition, lastRotation);
            
            // 获取道路片段的出口位置和方向
            Transform exitPoint = roadSegment.transform.Find("ExitPoint");
            if (exitPoint != null)
            {
                lastPosition = exitPoint.position;
                lastRotation = exitPoint.rotation;
            }

            // 收集路径点
            foreach (Transform waypoint in roadSegment.GetComponentsInChildren<Transform>())
            {
                if (waypoint.CompareTag("Waypoint"))
                {
                    allWaypoints.Add(waypoint);
                }
            }
        }

        // 生成汽车并设置路径点
        if (allWaypoints.Count > 0)
        {
            GameObject car = Instantiate(carPrefab, allWaypoints[0].position, Quaternion.identity);
            CarController2D carController = car.GetComponent<CarController2D>();
            carController.waypoints = allWaypoints.ToArray();
        }
    }
    public class GameManager : MonoBehaviour
    {
        public void EndGame()
        {
            Debug.Log("Game Over");
            // 在这里添加游戏结束的逻辑，例如显示游戏结束界面
        }
    }
}