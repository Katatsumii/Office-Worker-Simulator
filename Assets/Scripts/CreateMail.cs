using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMail : MonoBehaviour
{
    public GameObject mailPrefab;
    public void createMail()
    {
        Instantiate(mailPrefab, transform);
    }

}
