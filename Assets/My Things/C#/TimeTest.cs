using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class TimeTest : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] Button start;
    public float countTime = 0;
    public float finalTime = 0;
    private bool isCounting = false;
    void Start()
    {
        start.onClick.AddListener(StartCount);
    }

    void Update()
    {
        if (isCounting)
        {
            countTime += Time.deltaTime;
            finalTime = countTime;
            timeText.text = Mathf.Floor(countTime).ToString();
        }
    }

    public void StartCount()
    {
        isCounting = true;
    }

    public void ResetCount()
    {
        countTime = 0f;
        timeText.text = countTime.ToString();
        isCounting = false;
    }

    public void FinalTime()
    {
        timeText.text = finalTime.ToString();
    }
}
