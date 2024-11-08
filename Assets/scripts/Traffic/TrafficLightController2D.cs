// 文件名：TrafficLightController2D.cs
using UnityEngine;

public class TrafficLightController2D : MonoBehaviour
{
    public SpriteRenderer redLight;
    public SpriteRenderer greenLight;
    public float switchTime = 5f; // 切换时间

    private float timer;

    void Start()
    {
        timer = switchTime;
        SetLights(true, false); // 初始状态：红灯亮
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SwitchLights();
            timer = switchTime;
        }
    }

    void SwitchLights()
    {
        bool isRedLightOn = redLight.enabled;
        SetLights(!isRedLightOn, isRedLightOn);
    }

    void SetLights(bool red, bool green)
    {
        redLight.enabled = red;
        greenLight.enabled = green;
    }
}