using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Importing Open Source API
using Mono;
using Mono.Cecil;
using Mono.Collections.Generic;
using Mono.Cecil.Cil;
using ICSharpCode.Decompiler;
using ICSharpCode.NRefactory;

// Importing .NET API
using System.Reflection;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FocusDecomp
{
    public partial class Form1 : Form
    {
        public bool status = false;
        public Form1()
        {
            InitializeComponent();
        }
        // create instance of ReadPEHeader
        

        // Function to open up target EXE
        private void OpenUpAssembly()
        {
            OpenFileDialog openAsm = new OpenFileDialog();
            openAsm.Filter = "Executable | *.exe";

            if (openAsm.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openAsm.FileName;
                ReadPEHeader reader = new ReadPEHeader(textBox1.Text);
                if (reader.Is32BitHeader)
                {
                    ReadPEHeader.IMAGE_OPTIONAL_HEADER32 hEADER32 = reader.OptionalHeader32;
                    richTextBox1.AppendText("[Magic]::" + hEADER32.Magic.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Major Linker Version]::" + hEADER32.MajorLinkerVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Minor Linker Version]::" + hEADER32.MinorLinkerVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Code]::" + hEADER32.SizeOfCode.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Initialized Data]::" + hEADER32.SizeOfInitializedData.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Uninitialized Data]::" + hEADER32.SizeOfUninitializedData.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Address Of Entry Point]::" + hEADER32.AddressOfEntryPoint.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Base Of Code]::" + hEADER32.MajorLinkerVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Image Base]::" + hEADER32.ImageBase.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Section Alignment]::" + hEADER32.SectionAlignment.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[File Alignment]::" + hEADER32.FileAlignment.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Major Operating System Version]::" + hEADER32.MajorOperatingSystemVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Minor Operating System Version]::" + hEADER32.MinorOperatingSystemVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Major Image Version]::" + hEADER32.MajorImageVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Minor Image Version]::" + hEADER32.MinorImageVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Major Subsystem Version]::" + hEADER32.MajorSubsystemVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Minor Subsystem Version]::" + hEADER32.MinorSubsystemVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Win32 Version Value]::" + hEADER32.Win32VersionValue.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Image]::" + hEADER32.SizeOfImage.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Headers]::" + hEADER32.SizeOfHeaders.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[CheckSum]::" + hEADER32.CheckSum.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Subsystem]::" + hEADER32.Subsystem.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Dll Characteristics]::" + hEADER32.DllCharacteristics.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Stack Reserve]::" + hEADER32.SizeOfStackReserve.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Stack Commit]::" + hEADER32.SizeOfStackCommit.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Heap Reserve]::" + hEADER32.SizeOfHeapReserve.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Heap Commit]::" + hEADER32.SizeOfHeapCommit.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Loader Flags]::" + hEADER32.LoaderFlags.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Number Of Rva and Sizes]::" + hEADER32.NumberOfRvaAndSizes.ToString() + Environment.NewLine);
                }
                else
                {
                    ReadPEHeader.IMAGE_OPTIONAL_HEADER64 hEADER64 = reader.OptionalHeader64;
                    richTextBox1.AppendText("[Magic]::" + hEADER64.Magic.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Major Linker Version]::" + hEADER64.MajorLinkerVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Minor Linker Version]::" + hEADER64.MinorLinkerVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Code]::" + hEADER64.SizeOfCode.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Initialized Data]::" + hEADER64.SizeOfInitializedData.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Uninitialized Data]::" + hEADER64.SizeOfUninitializedData.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Address Of Entry Point]::" + hEADER64.AddressOfEntryPoint.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Base Of Code]::" + hEADER64.MajorLinkerVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Image Base]::" + hEADER64.ImageBase.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Section Alignment]::" + hEADER64.SectionAlignment.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[File Alignment]::" + hEADER64.FileAlignment.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Major Operating System Version]::" + hEADER64.MajorOperatingSystemVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Minor Operating System Version]::" + hEADER64.MinorOperatingSystemVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Major Image Version]::" + hEADER64.MajorImageVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Minor Image Version]::" + hEADER64.MinorImageVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Major Subsystem Version]::" + hEADER64.MajorSubsystemVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Minor Subsystem Version]::" + hEADER64.MinorSubsystemVersion.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Win32 Version Value]::" + hEADER64.Win32VersionValue.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Image]::" + hEADER64.SizeOfImage.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Headers]::" + hEADER64.SizeOfHeaders.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[CheckSum]::" + hEADER64.CheckSum.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Subsystem]::" + hEADER64.Subsystem.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Dll Characteristics]::" + hEADER64.DllCharacteristics.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Stack Reserve]::" + hEADER64.SizeOfStackReserve.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Stack Commit]::" + hEADER64.SizeOfStackCommit.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Heap Reserve]::" + hEADER64.SizeOfHeapReserve.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Size Of Heap Commit]::" + hEADER64.SizeOfHeapCommit.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Loader Flags]::" + hEADER64.LoaderFlags.ToString() + Environment.NewLine);
                    richTextBox1.AppendText("[Number Of Rva and Sizes]::" + hEADER64.NumberOfRvaAndSizes.ToString() + Environment.NewLine);
  
                }
                ReadPEHeader.IMAGE_FILE_HEADER fILE_HEADER = reader.FileHeader;
                
                richTextBox1.AppendText("[Machine]::" + fILE_HEADER.Machine.ToString() + Environment.NewLine);
                richTextBox1.AppendText("[Number of Sections]::" + fILE_HEADER.NumberOfSections.ToString() + Environment.NewLine);
                richTextBox1.AppendText("[TimeDateStamp]::" + fILE_HEADER.TimeDateStamp.ToString() + Environment.NewLine);
                richTextBox1.AppendText("[Pointer to Symbol Table]::" + fILE_HEADER.PointerToSymbolTable.ToString() + Environment.NewLine);
                richTextBox1.AppendText("[Number of Symbols]::" + fILE_HEADER.NumberOfSymbols.ToString() + Environment.NewLine);
                richTextBox1.AppendText("[Size of Optional Header]::" + fILE_HEADER.SizeOfOptionalHeader.ToString() + Environment.NewLine);
                richTextBox1.AppendText("[Characteristics]::" + fILE_HEADER.Characteristics.ToString() + Environment.NewLine);
            }
        }


        private void ReadAssemblyAsHex()
        {
            OpenUpAssembly();       //Implements 'File Open' dialog box
            FileStream hexStream = new FileStream(textBox1.Text, FileMode.Open);
            int hexIN;
            string hex;
            for (int i = 1; (hexIN = hexStream.ReadByte()) != -1; i++)
            {
                hex = string.Format("{0:X2}", hexIN);
                richTextBox2.AppendText(hex + "  ");

                if (i % 25 == 0)
                {
                    richTextBox2.AppendText(System.Environment.NewLine);
                }
            }
        }

        // Displays an assembly origin related method. 
        // This means that all methods that communicate with this assembly will be 
        // displayed.


        // Generates button event
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        { 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            status = false;
            ResetText();            //cleans Text values

            ReadAssemblyAsHex();
        }
    }

}
