using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{

    void Start()
    {
        GetComponent<TMP_Text>().text += StaticScoreAndHealth.score;
    }
}
