using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 保持在场景切换时不被销毁
        }
        else
        {
            Destroy(gameObject); // 如果已经存在实例，则销毁新的实例
        }
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
        // 在这里添加游戏结束的逻辑，例如显示游戏结束界面
    }
}