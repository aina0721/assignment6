using UnityEngine;

public class HP : MonoBehaviour
{
    public int hp;  // HP

    // ダメージを受ける処理
    public void Damage(int damage)
    {
        hp -= damage; // ダメージを受ける
        if (hp <= 0)  // HPが0以下になったらオブジェクトを破壊
        {
            Destroy(gameObject);
        }
    }
}
