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
    [SerializeField] Transform body;//�ŧiTransform(�ഫ)
    Vector3 direction;//�ŧiVector3(XYZ�b)
    private bool isButtonClicked = false;
    List<Transform> bodies = new List<Transform>();//��Transform������O���x�s����
    private void Start()
    {
        Time.timeScale = speed;//���ɶ��y�u���ֺC
        Restart();
        audioSource = GetComponent<AudioSource>();
        again.onClick.AddListener(OnAgainButtonClicked);
    }
    void Update()
    {
        //WASD�����
        if (Input.GetKeyDown(KeyCode.W))//������U����çP�_�O�_�ŦXIF��������
        {
            direction = Vector3.down / 2;
            transform.rotation = Quaternion.Euler(0, 0, -90);//���y���µ۲��ʤ�V
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
    private void FixedUpdate()//�T�w�t�װ���
    {
        for (int i = bodies.Count - 1; i > 0; i--)
        {
            bodies[i].position = bodies[i - 1].position;//�������Y���Ϋe�@�`�����鲾��
        }
        transform.Translate(transform.TransformDirection(direction));//�z�Lxyz���ܨӲ���
    }
    private void OnTriggerEnter2D(Collider2D collision)//�I����Ĳ�o
    {
        if (collision.CompareTag("Popo"))//�ˬd�I�����O�_��Popo����
        {
            //�[���Xbody�b�Y������m�æs��List��
            bodies.Add(Instantiate(body, transform.position, Quaternion.identity));
            gameUI.AddScore();//�p��o��
        }
        if (collision.CompareTag("Obstacle"))//�ˬd�I�����O�_��Obstacle����
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
        transform.position = Vector3.zero;//���a�^����I
        direction = Vector3.zero;//���ʳt���k0
        for (int i = 1; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);//�M���Y���H�~������
        }
        bodies.Clear();//��}�C�M��
        bodies.Add(transform);//���Y�����s�[�^�}�C��1�Ӧ�m
        gameUI.ResetScore();//���s����
    }

    private void OnAgainButtonClicked()
    {
        isButtonClicked = true; 
    }
}
