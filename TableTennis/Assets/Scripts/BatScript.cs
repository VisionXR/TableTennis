using UnityEngine;

public class BatScript : MonoBehaviour
{

    public float LL, RL, TL, BL;
    public float x, y, z;

    public void SetPosition(Vector3 Pos)
    {
        transform.position = Pos;
    }
    public void StartMovement()
    {
       InputManager.instance.MoveBat += MoveBat;        
    }
    public void StopMovement()
    {
        InputManager.instance.MoveBat -= MoveBat;
    }
    private void MoveBat(Vector2 MousePos)
    {
        transform.position = CalculateBatPos(MousePos);
    }
    private Vector3 CalculateBatPos(Vector2 MousePos)
    {
        y = TL - (0.001f * MousePos.y * (TL - BL));
        z = LL + (0.001f * 0.5f * MousePos.x * (RL - LL));
        return new Vector3(x, -y, z);
    }
}
