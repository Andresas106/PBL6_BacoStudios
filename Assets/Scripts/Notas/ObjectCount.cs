using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCount : MonoBehaviour
{
    public const int MAX_QUANTITY = 14;
    [SerializeField] private TMP_Text noteText;
    [SerializeField] private GameObject notesTextobj;
    [SerializeField] private GameObject notesobj;
    [SerializeField] private GameObject[] allNotes;
    public int quantity = 0;

    void Update()
    {
        noteText.text = string.Format("{0}/14", quantity);
    }

    public void NotesTextAppear()
    {
        quantity = 0;
        notesTextobj.SetActive(true);
    }

    public void NotesTextDisAppear()
    {
        notesTextobj.SetActive(false);
    }

    public void NotesAppear()
    {
        notesobj.SetActive(true);
        for(int i=0;i<allNotes.Length;i++) 
        {
            allNotes[i].SetActive(true);
        }

    }

    public void NotesDisappear()
    {
        notesobj.SetActive(false);
    }
}
