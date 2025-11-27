using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Text Text;
    float player_home = 20; 
    float Counter = 0; 

    Vector3 pos;

    // 移動フラグ（trueのとき移動する）
    bool isMove = true;
    bool isAttack;

    void Start()
    {
        pos = new Vector3(-1, 0, 0);
    }

    void Update()
    {
        // isMove が true の場合のみ移動する
        if (isMove)
        {
            transform.position += pos * Time.deltaTime;
        }

        if (isAttack)
        {
            Counter += Time.deltaTime;

            if (Counter >= 1.0f)
            {
                player_home -= 1;
                Counter = 0;
            }

            Text.text = player_home.ToString("F0"); // 整数で表示

            if (player_home == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    IEnumerator AttackAction(HP hitPoint)
    {
        while (hitPoint.hp > 0) // HPが0になるまで攻撃し続ける
        {
            yield return new WaitForSeconds(1); // 1秒ごとに攻撃
            hitPoint.Damage(1); // 1ダメージを与える
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したら戦闘開始
        if (collision.gameObject.tag == "Player")
        {
            isMove = false; // 移動を停止

            // 相手のHPスクリプトを取得
            HP hitPoint = collision.GetComponent<HP>();

            // ダメージ処理をコルーチンで開始
            StartCoroutine(AttackAction(hitPoint));
        }
        if (collision.gameObject.tag == "Player_home") 
        {
            isMove = false; // 移動を停止
            isAttack = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // 相手とぶつからなくなったら歩き出す
        isMove = true;
    }

}
