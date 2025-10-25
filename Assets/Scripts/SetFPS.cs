using UnityEngine;

public class SetFPS : MonoBehaviour
{
    public int fps = 60;
    void Start()
    {
      Application.targetFrameRate = fps;
    }

    
}
