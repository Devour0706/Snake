using UnityEngine;

public class BeEaten : MonoBehaviour
{
    [SerializeField] Collider2D foodArea;//宣告Collider2D(碰撞區)
    [SerializeField] private AudioSource audioSource;//宣告AudioSource
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//抓取需要的音效
        RandomPosition();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞後觸發
    {
        RandomPosition();
        audioSource.Play();//撥放抓取的音效
    }

    private void RandomPosition()
    {
        float newX = Random.Range(foodArea.bounds.min.x, foodArea.bounds.max.x);//抓取觸發區的邊緣值
        float newY = Random.Range(foodArea.bounds.min.y, foodArea.bounds.max.y);
        transform.position = new Vector3(newX, newY, 0);//把位置修改到抓取的範圍內
    }
}
