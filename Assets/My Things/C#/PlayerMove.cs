using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameUI gameUI;
    [SerializeField] TimeTest time;
    [SerializeField] Button again;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] float speed;
    [SerializeField] Transform body;//宣告Transform(轉換)
    Vector3 direction;//宣告Vector3(XYZ軸)
    private bool isButtonClicked = false;
    List<Transform> bodies = new List<Transform>();//用Transform資料類別來儲存身體
    private void Start()
    {
        Time.timeScale = speed;//更改時間流逝的快慢
        Restart();
        audioSource = GetComponent<AudioSource>();
        again.onClick.AddListener(OnAgainButtonClicked);
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
        if (isButtonClicked)
        {
            RestartScene();
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
            gameUI.AddScore();//計算得分
        }
        if (collision.CompareTag("Obstacle"))//檢查碰撞物是否有Obstacle標籤
        {
            audioSource.Play();
            time.ResetCount();
            Restart();
            gameUI.FinalScore();
            time.FinalTime();
            PauseGame();
            again.gameObject.SetActive(true);
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }


    private void RestartScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }

    void Restart()
    {
        transform.position = Vector3.zero;//玩家回到原點
        direction = Vector3.zero;//移動速度歸0
        for (int i = 1; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);//清除頭部以外的身體
        }
        bodies.Clear();//把陣列清空
        bodies.Add(transform);//把頭部重新加回陣列第1個位置
        gameUI.ResetScore();//重製分數
    }

    private void OnAgainButtonClicked()
    {
        isButtonClicked = true; 
    }
}
