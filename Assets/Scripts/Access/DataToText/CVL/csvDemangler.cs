using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVDemangler {
    /**
     * Utility for DTT_CSVDefinedLanguage
     * To save from reloading csv after each trim
     * or ugly loading code in dtt file
     * Warning:
     *     Yucky forcing that commas are always breaks
    **/

    List<string[]> data = new List<string[]>();
    char[] quoters = "'\"".ToCharArray();

    public CSVDemangler(string csv) {
        string[] lines = csv.Split('\n');
        foreach(string line in lines) {
            string[] parts = line.Split(',');
            for(int i = 0; i < parts.Length; i++) {
                parts[i] = trimString(parts[i]);
            }
            data.Add(parts);
        }
    }


    private string trimString(string inp) {
        char chosen = (char)0;
        int start = 0;
        int stop = 0;

        //The lack of braces here is evil
        //but I couldn't help myself
        //I miss python
        for(int i = 0; i < inp.Length; i++) 
            foreach(char quoter in quoters)
                if(inp[i] == quoter)
                    if(chosen == 0) {
                        chosen = quoter;
                        start = i + 1;
                    } else {
                        stop = i;
                        break;
                    }
        
        return inp.Substring(start, stop-start);
    }


    public List<string[]> getData() {
        return data;
    }
}
