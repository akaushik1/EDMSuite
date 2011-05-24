﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MOTMaster
{
    public partial class ControllerWindow : Form
    {
        public Controller controller = new Controller();

        public ControllerWindow()
        {
            InitializeComponent();
        }

        public void WriteToConsole(string str)
        {
            setTextBox(resultsTextBox, str);
        }


        #region wrappers

        private void setTextBox(TextBox box, string text)
        {
            box.Invoke(new SetTextDelegate(setTextHelper), new object[] { box, text });
        }
        private delegate void SetTextDelegate(TextBox box, string text);
        private void setTextHelper(TextBox box, string text)
        {
            box.Text = text;
        }
        private string readComboBox(ComboBox box)
        {
            return (string)box.Invoke(new ReadComboDelegate(readComboHelper), new object[] { box });
        }
        private delegate string ReadComboDelegate(ComboBox box);
        private string readComboHelper(ComboBox box)
        {
            return box.Text;
        }

        #endregion

        public void FillScriptComboBox(string[] s)
        {
            scriptListComboBox.Items.Clear();
            scriptListComboBox.Items.AddRange(s);
            scriptListComboBox.Text = s[0];
        }

        private void lookupScriptsButton_Click(object sender, EventArgs e)
        {
            controller.ScriptLookupAndDisplay();
        }

        private void compileAndInitializeButton_Click(object sender, EventArgs e)
        {
            controller.CompileAndRun();
        }

        public string GetScriptPath()
        {
            return readComboBox(scriptListComboBox);
        }
    }
}