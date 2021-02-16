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

    private List<string[]> data = new List<string[]>();
    private static char[] quoters = "'\"".ToCharArray();

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

        for(int i = 0; i < inp.Length; i++) {
            if(chosen == 0) {
                foreach(char quoter in quoters) {
                    if(inp[i] == quoter) {
                        chosen = quoter;
                        start = i + 1;
                    }
                }
            } else {
                if(inp[i] == chosen) {
                    return inp.Substring(start, i - start);
                }
            }
        }

        return inp;
    }


    public List<string[]> getData() {
        return data;
    }


    public Dictionary<string, string[]> getDataAsDict(int keyIndex) {
        Dictionary<string, string[]> outp = new Dictionary<string, string[]>();
        foreach(string[] d in data) {
            List<string> v = new List<string>();
            for(int i = 0; i < d.Length; i++) {
                if(i != keyIndex) {
                    v.Add(d[i]);
                }
            }
            outp.Add(d[keyIndex], v.ToArray());
        }
        return outp;
    }
}
