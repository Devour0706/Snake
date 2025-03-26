using UnityEngine;

public class BeEaten : MonoBehaviour
{
    [SerializeField] Collider2D foodArea;//�ŧiCollider2D(�I����)
    [SerializeField] private AudioSource audioSource;//�ŧiAudioSource
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//����ݭn������
        RandomPosition();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)//�I����Ĳ�o
    {
        RandomPosition();
        audioSource.Play();//������������
    }

    private void RandomPosition()
    {
        float newX = Random.Range(foodArea.bounds.min.x, foodArea.bounds.max.x);//���Ĳ�o�Ϫ���t��
        float newY = Random.Range(foodArea.bounds.min.y, foodArea.bounds.max.y);
        transform.position = new Vector3(newX, newY, 0);//���m�ק�������d��
    }
}
