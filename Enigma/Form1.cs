﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Enigma
{
    public partial class Form1 : Form
    {
        // Rotor arrays
        string[] rotorSmall;
        string[] rotorMed;
        string[] rotorLarge;

        StreamReader reader;
        StreamWriter writer;


        public Form1()
        {
            InitializeComponent();

            
        }

        /// <summary>
        /// Loads the rotors into arrays
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadRotors_Click(object sender, EventArgs e)
        {
            string line;

            openFileDialogOpen.Filter = "Rotor Files|*.csv|All Files|*.*";
            
            if (openFileDialogOpen.ShowDialog() == DialogResult.OK)
            {
                reader = File.OpenText(openFileDialogOpen.FileName);

                // Read each line the split into the rotor arrays
                line = reader.ReadLine();
                rotorLarge = line.Split(',');
                line = reader.ReadLine();
                rotorMed = line.Split(',');
                line = reader.ReadLine();
                rotorSmall = line.Split(',');

                // Provide feedback
                Console.WriteLine("Rotors loaded");
                Console.WriteLine();

            }


        }

        /// <summary>
        /// Decodes the file, as the button name suggests
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDecodeFile_Click(object sender, EventArgs e)
        {
            string line;
            string charac;

            // Filters for the dialogues
            openFileDialogOpen.Filter = "Text Files|*.txt|All Files|*.*";
            saveFileDialogSave.Filter = "Text Files|*.txt|All Files|*.*";
           
            // if the two thing pick a file
            if (openFileDialogOpen.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialogSave.ShowDialog() == DialogResult.OK)
                {
                    // Set everything up, then read the line
                    reader = File.OpenText(openFileDialogOpen.FileName);
                    writer = File.CreateText(saveFileDialogSave.FileName);

                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();

                        // For every character in the file
                        for (int i = 0; i < line.Length; i++)
                        {
                            charac = line.Substring(i, 1);
                            writer.Write(DecodeLetter(charac));
                            ShuffleRotors();
                        }

                        writer.WriteLine();
                    }

                    reader.Close();
                    writer.Close();

                    // Do it, or else you get garbled text. Again.
                    Console.WriteLine("Remember to reload the rotors");
                }
            }

            
        }

        /// <summary>
        /// Decode a single letter. This is done multiple times.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private string DecodeLetter(string c)
        {
            string temp = "";
            string final = "";

            /* Check through large rotor to find the same letter
             * Find letter on the medium rotor at the same position as above
             * 
             * Check through large rotor to find the letter on the medium wheel
             * Return letter on small rotor at same position.
             * */
            for (int i = 0; i < rotorLarge.Length; i++)
            {
                if (c == rotorLarge[i])
                {
                    temp = rotorMed[i];

                    for (int j = 0; j < rotorLarge.Length; j++)
                    {
                        if (temp == rotorLarge[j])
                        {
                            final = rotorSmall[j];
                            break;
                        }
                    }
                }
            }
            
            return final;
        }

        /// <summary>
        /// Change the decoding.
        /// 
        /// This was the reason that the enigma machines were, well, an enigma.
        /// </summary>
        private void ShuffleRotors()
        {
            string temp;

            // Change the large rotor, but only if the medium has done a full cycle
            if (rotorMed[rotorMed.Length - 1] == " ")
            {
                temp = rotorLarge[rotorLarge.Length - 1];
                for (int i = rotorLarge.Length - 1; i > 0; i--)
                {
                    rotorLarge[i] = rotorLarge[i - 1];
                }
                rotorLarge[0] = temp;
            }

            // Change the medium rotor, but only if the small has done a full cycle
            if (rotorSmall[rotorSmall.Length - 1] == " ")
            {
                temp = rotorMed[rotorMed.Length - 1];
                for (int i = rotorMed.Length - 1; i > 0; i--)
                {
                    rotorMed[i] = rotorMed[i - 1];
                }
                rotorMed[0] = temp;
            }

            // Change the small rotor
            temp = rotorSmall[rotorSmall.Length - 1];
            for (int i = rotorSmall.Length - 1; i > 0; i--)
            {
                rotorSmall[i] = rotorSmall[i - 1];
            }
            rotorSmall[0] = temp;
        }


        /// <summary>
        /// Encypts a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEncryptFile_Click(object sender, EventArgs e)
        {
            string line;
            string charac;

            // Set the filters
            openFileDialogOpen.Filter = "Text Files|*.txt|All Files|*.*";
            saveFileDialogSave.Filter = "Text Files|*.txt|All Files|*.*";

            // If both dialoues pick a file
            if (openFileDialogOpen.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialogSave.ShowDialog() == DialogResult.OK)
                {
                    reader = File.OpenText(openFileDialogOpen.FileName);
                    writer = File.CreateText(saveFileDialogSave.FileName);

                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();

                        // For every character in the file
                        for (int i = 0; i < line.Length; i++)
                        {
                            charac = line.Substring(i, 1);
                            writer.Write(EncryptLetter(charac));
                            ShuffleRotors();
                        }
                        writer.WriteLine();
                    }

                    reader.Close();
                    writer.Close();

                    // Do it, or else you get garbled text. Again.
                    Console.WriteLine("Remember to reload the rotors");
                }
            }
        }

        /// <summary>
        /// Encode a single letter. This is done multiple times.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private string EncryptLetter(string c)
        {
            string temp = "";
            string final = "";

            /* Check through large rotor to find the same letter
             * Find letter on the medium rotor at the same position as above
             * 
             * Check through large rotor to find the letter on the medium wheel
             * Return letter on small rotor at same position.
             * */
            for (int i = 0; i < rotorSmall.Length; i++)
            {
                if (c == rotorSmall[i])
                {
                    temp = rotorLarge[i];

                    for (int j = 0; j < rotorMed.Length; j++)
                    {
                        if (temp == rotorMed[j])
                        {
                            final = rotorLarge[j];
                            break;
                        }
                    }
                }
            }

            return final;
        }
    }
}
