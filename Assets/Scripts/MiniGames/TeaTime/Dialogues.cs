using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public static class DialoguesWrapper
{
    public static List<List<String>> dialogues = new List<List<string>>();

    public static void InitDialogues()
    {
        List<String> text1 = new List<string>();
        text1.Add("I bet tomorrow will be raining...");
        text1.Add("Why?");
        text1.Add("Because pressure has changed");
        dialogues.Add(text1);
        
        List<String> text2 = new List<string>();
        text2.Add("Lovely weather out today, innit?");
        text2.Add("We’re deep underwater in a submarine.");
        text2.Add("Come on, play along!");
        dialogues.Add(text2);
        
        List<String> text3 = new List<string>();
        text3.Add("How old is the Queen again");
        text3.Add("… I beg your pardon?");
        text3.Add("Battering spades! For battering a person!?");
        dialogues.Add(text3);
        
        List<String> text4 = new List<string>();
        text4.Add("Do you do poison?");
        text4.Add("Why?");
        text4.Add("Because pressure has changed");
        dialogues.Add(text4);
        
        List<String> text6 = new List<string>();
        text6.Add("… So many various fish out in the vast ocean!");
        text6.Add("Are there any lobsters with guns?");
        text6.Add("What?");
        dialogues.Add(text6);
        
        List<String> text7 = new List<string>();
        text7.Add("Oi oi oi ya’ got a licence for that?");
        text7.Add("I got me a licence right ‘ere!");
        text7.Add("Well a licence is a licence!");
        dialogues.Add(text7);
        
        List<String> text8 = new List<string>();
        text8.Add("Captain should always go down with the ship!");
        text8.Add("Aye!");
        text8.Add("So which one of us is the Captain??");
        dialogues.Add(text8);
        
        List<String> text9 = new List<string>();
        text9.Add("Hello! I am Sylwester.");
        text9.Add("Kek!");
        text9.Add("Pressure to meet you");
        dialogues.Add(text9);
    }
    
}
