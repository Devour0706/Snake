using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform body;//宣告Transform(轉換)
    Vector3 direction;//宣告Vector3(XYZ軸)
    List<Transform> bodies = new List<Transform>();//用Transform資料類別來儲存身體
    private void Start()
    {
        Time.timeScale = speed;//更改時間流逝的快慢
        bodies.Add(transform);//把玩家頭部儲存到List的第1個位置
    }
    void Update()
    {
        //WASD控制移動
        if (Input.GetKeyDown(KeyCode.W))//抓取按下的鍵並判斷是否符合IF中的限制
        {
            direction = Vector3.down / 2;
            transform.rotation = Quaternion.Euler(0, 0, -90);//讓臉部朝著移動方向
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector3.left / 2;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector3.up / 2;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector3.right / 2;
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }
    private void FixedUpdate()//固定速度執行
    {
        for (int i = bodies.Count - 1; i > 0; i--)
        {
            bodies[i].position = bodies[i - 1].position;//身體跟著頭部或前一節的身體移動
        }
        transform.Translate(transform.TransformDirection(direction));//透過xyz改變來移動
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞後觸發
    {
        if (collision.CompareTag("Popo"))//檢查碰撞物是否有Popo標籤
        {
            //加載出body在頭部的位置並存到List裡
            bodies.Add(Instantiate(body, transform.position, Quaternion.identity));
        }
    }
}
