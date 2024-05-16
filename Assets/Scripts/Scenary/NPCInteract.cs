using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteract : MonoBehaviour
{

    [TextArea]
    [SerializeField] string dialogue;

    public void NPCDialogue(TMP_Text textBox)
    {

        textBox.text = dialogue;

    }
    
}
