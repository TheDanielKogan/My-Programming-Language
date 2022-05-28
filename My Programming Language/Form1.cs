using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Programming_Language
{
   
    public partial class Form1 : Form
    {
        public Dictionary<string, string> uservariables = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            addtoconsole("Console online");
            
        }
        //anything = 0
        //getinput
        //anything = {input}
        //print(blah blah {input})
        //if {input} is (test) if not then 5
        // if __ is __ if not then __
        // if __ isn't __ if not then __
        public int codeline = 0;
        public string lastinput = "null";
        bool getinput = false;
        //print(write your name)
        //getinput
        //if {input} is bob if not then 6
        //print(your name is bob)
        //print(your name is not bob)


        public void readcode()
        {
            
            for (int i = codeline; i < textBox3.Lines.Length; i++)
            {
                if (textBox3.Lines[i].StartsWith("print("))
                {
                    string text = textBox3.Lines[i].Substring(6, textBox3.Lines[i].Length - 7);
                    foreach(var item in uservariables)
                    {
                        text = text.Replace("{input}", lastinput).Replace(item.Key, item.Value);
                        
                    }
                    addtoconsole(text);
                }
                if (textBox3.Lines[i] == "getinput")
                {
                    getinput = true;
                    codeline = i + 1;
                    break;
                }
                if (textBox3.Lines[i].Contains(" = "))
                {
                    string[] split = textBox3.Lines[i].Split(' ');
                    foreach (var item in uservariables)
                    {
                        split[2] = split[2].Replace("{input}", lastinput).Replace(item.Key, item.Value);
                        

                    }
                    
                    
                    
                    if (!uservariables.ContainsKey(split[0]))
                    {
                        uservariables.Add(split[0], split[2]);
                    }
                    else
                    {
                        uservariables[split[0]] = split[2];
                    }
                    
                }
                if (textBox3.Lines[i].StartsWith("if "))
                {
                    string[] split = textBox3.Lines[i].Split(' ');
                    foreach (var item in uservariables)
                    {
                        split[1] = split[1].Replace("{input}", lastinput).Replace(item.Key, item.Value);
                    }
                    foreach (var item in uservariables)
                    {
                        split[3] = split[3].Replace("{input}", lastinput).Replace(item.Key, item.Value);
                    }
                    if (split[2] == "is")
                    {
                        if (split[1] != split[3])
                        {
                            codeline = Convert.ToInt32(split[7]);
                            readcode();
                            break;

                        }
                    }
                    else if (split[2] == "isn't") 
                    {
                        if (split[1] == split[3])
                        {
                            codeline = Convert.ToInt32(split[7]);
                            readcode();
                            break;
                        }
                    }
                }
            }
        }
        
        public void addtoconsole(string text)
        {
            
            textBox1.Text = textBox1.Text + text + Environment.NewLine;
            
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                ConsoleCommands cs = new ConsoleCommands();
                if (getinput == true)
                {

                    lastinput = textBox2.Text;
                    getinput = false;
                    readcode();
                }
                if (textBox2.Text == cs.iscommand(textBox2.Text))
                {
                    if (cs.iscommand(textBox2.Text) != "run")
                    {
                        addtoconsole(cs.findcommandvalue(textBox2.Text));
                        
                    }
                    else
                    {
                        textBox1.Text = "";
                        codeline = 0;
                        uservariables.Clear();
                        uservariables.Add("1askdhikasdkjasd", "ds");
                        readcode();
                    }
                }
                textBox2.Text = "";

            }
        }
    }
}
