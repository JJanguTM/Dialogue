using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DatabaseManager : MonoBehaviour
{
    [SerializeField] private string csvFileName;
    private Dialogue[] dialogues;
   
    private int DialogueCount;

    private void Start()
    {
        dialogues = ParseCSV(csvFileName); 
    }

    private Dialogue[] ParseCSV(string csvFileName)
    {
        TextAsset csvData = Resources.Load<TextAsset>(csvFileName);
        if (csvData == null)
        {
            Debug.LogError($"CSV 파일이 없습니다: {csvFileName}");
            return Array.Empty<Dialogue>();
        }

        string[] rows = csvData.text.Split('\n');
        int dialogueCount = 0;

        for (int i = 1; i < rows.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(rows[i].Split(',')[0]))
                dialogueCount++;
        }

        Dialogue[] dialogues = new Dialogue[dialogueCount];
        int index = 0;

        for (int i = 1; i < rows.Length;)
        {
            string[] row = rows[i].Split(',');
            if (row.Length < 3 || string.IsNullOrWhiteSpace(row[0]))
            {
                i++;
                continue;
            }

            string name = row[1].Trim();

            List<string> contexts = new();

            do
            {
                if (row.Length > 2 && !string.IsNullOrWhiteSpace(row[2]))
                {
                    contexts.Add(row[2].Trim());
                }
                i++;
                if (i < rows.Length)
                {
                    row = rows[i].Split(',');
                }
                else
                {
                    break;
                }
            } while (string.IsNullOrWhiteSpace(row[0]));

            dialogues[index++] = new Dialogue(name, contexts.ToArray());
        }

        return dialogues;
    }

    public Dialogue[] GetAllDialogues()
    { 
        return dialogues;
    }
}