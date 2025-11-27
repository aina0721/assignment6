using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    public GameObject prefab3;

    public Transform spawnPoint; // 生成位置

    [SerializeField]
    Text MoneyText;
    float money = 0; // お金


    void Update()
    {
        money += Time.deltaTime;

        if (money > 1000)
        {
            money = 1000;
        }

        MoneyText.text = money.ToString("0G"); // 整数で表示
    }

    public void OnClick_red()
    {
        if (prefab != null && spawnPoint != null)
        {
            if (money >= 5)
            {
                money = money - 5;
                Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
        else
        {
            Debug.LogWarning("！");
        }
    }

    public void OnClick_blue()
    {
        if (prefab != null && spawnPoint != null)
        {
            if (money >= 10)
            {
                money = money - 10;
                Instantiate(prefab2, spawnPoint.position, spawnPoint.rotation);
            }
        }
        else
        {
            Debug.LogWarning("！");
        }
    }

    public void OnClick_yellow()
    {
        if (prefab != null && spawnPoint != null)
        {
            if (money >= 15)
            {
                money = money - 15;
                Instantiate(prefab3, spawnPoint.position, spawnPoint.rotation);
            }
        }
        else
        {
            Debug.LogWarning("！");
        }
    }
}
