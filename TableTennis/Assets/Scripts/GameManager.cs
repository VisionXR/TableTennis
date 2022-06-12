using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isPlayer1, isPlayer2;
    public Transform P1Pos, P2Pos;
    public GameObject cam;
    public GameObject Bat1, Bat2;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if(NetworkManager.instance.isMaster())
        {
            isPlayer1 = true;
            isPlayer2 = false;
            cam.transform.position = P1Pos.position;
            cam.transform.rotation = P1Pos.rotation;
            Bat1.GetComponent<BatScript>().StartMovement();
        }
        else
        {
            isPlayer1 = false;
            isPlayer2 = true;
            cam.transform.position = P2Pos.position;
            cam.transform.rotation = P2Pos.rotation;
            Bat2.GetComponent<BatScript>().StartMovement();
        }
    }

    public void ReceivedBatPos(Vector3 Pos)
    {
        if(isPlayer1)
        {
            Bat2.transform.position = Pos;
        }
        else
        {
            Bat1.transform.position = Pos;
        }
    }
    void Update()
    {
        if(isPlayer1)
        {
            NetworkManager.instance.SendBatPos(Bat1.transform.position);
        }
        else
        {
            NetworkManager.instance.SendBatPos(Bat2.transform.position);
        }
    }
}
