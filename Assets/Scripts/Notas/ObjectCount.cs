using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCount : MonoBehaviour
{
    public const int MAX_QUANTITY = 14;
    [SerializeField] private TMP_Text noteText;
     public int quantity = 0;

    void Update()
    {
        noteText.text = string.Format("{0}/14", quantity);
    }
}
