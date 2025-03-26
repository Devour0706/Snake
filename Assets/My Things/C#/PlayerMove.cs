using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform body;//�ŧiTransform(�ഫ)
    Vector3 direction;//�ŧiVector3(XYZ�b)
    List<Transform> bodies = new List<Transform>();//��Transform������O���x�s����
    private void Start()
    {
        Time.timeScale = speed;//���ɶ��y�u���ֺC
        bodies.Add(transform);//�⪱�a�Y���x�s��List����1�Ӧ�m
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
        }
    }
}
