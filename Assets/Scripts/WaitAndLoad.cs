using System.Collections;
using UnityEngine;

public class WaitAndLoad : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<Level>().LoadLevel2();
    }

}
