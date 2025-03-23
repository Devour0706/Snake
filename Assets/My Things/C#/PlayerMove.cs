using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float sPEED;
    Vector3 dIRECTION;
    private void Start()
    {
        Time.timeScale = sPEED;
    }
    void Update()
    {
        //WASD±±¨î²¾°Ê
        if (Input.GetKeyDown(KeyCode.W))
        {
            dIRECTION = Vector3.up / 2;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            dIRECTION = Vector3.left / 2;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            dIRECTION = Vector3.down / 2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dIRECTION = Vector3.right / 2;
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(dIRECTION);
    }
}
