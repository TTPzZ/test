using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedOfBackGround : MonoBehaviour
{
    public GameObject C, L, R;

    public void ramdomOffLed()
    {
        int ramdomm = Random.Range(0, 100);
        switch (ramdomm)
        {
            case 10:
                {
                    C.SetActive(false);
                    L.SetActive(true);
                    R.SetActive(true);
                }
                break;
            case 50:
                {
                    L.SetActive(false);
                    R.SetActive(true);
                    C.SetActive(true);
                }
                break;
            case 90:
                {
                    R.SetActive(false);
                    L.SetActive(true);
                    C.SetActive(true);

                }
                break;
            default:
                {
                    R.SetActive(true);
                    L.SetActive(true);
                    C.SetActive(true);
                }
                break;
        }
    }
    void Update()
    {
        ramdomOffLed();
    }
}
