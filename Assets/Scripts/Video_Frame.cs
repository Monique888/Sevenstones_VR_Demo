using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video_Frame : MonoBehaviour
{

    float GetFrameTime(int fps, int frame)
    {
        float periot = 200.0f / fps;
        return periot * frame;
    }

}
