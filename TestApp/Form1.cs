﻿using Components.Extension.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string key = "SuperSecret!";

            string demoStringEncrypted = "Hello World".XorB64Encrypt(key);
            string demoStringDecrypted = demoStringEncrypted.XorB64Decrypt(key);


        
        }
    }
}
