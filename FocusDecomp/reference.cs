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

//namespace FocusDecomp
//{
//    class reference
//    {
//        public AssemblyDefinition LoadedAssembly { get; set; }
//        public bool status = false;
//        private void LoadAsmOrigin()
//        {
//            try
//            {
//                LoadedAssembly = AssemblyDefinition.ReadAssembly(textBox1.Text);
//
//                richTextBox1.Clear();
//                richTextBox1.AppendText("[Name]::" + LoadedAssembly.MainModule.Name.ToString() + Environment.NewLine);
//                richTextBox1.AppendText("[CLR Runtime]::" + LoadedAssembly.MainModule.Runtime.ToString() + Environment.NewLine);
//                richTextBox1.AppendText("[Full Name]::" + LoadedAssembly.MainModule.FileName.ToString() + Environment.NewLine);
//                richTextBox1.AppendText("[Metadata Token]::" + LoadedAssembly.MainModule.MetadataToken.ToString() + Environment.NewLine);
//                richTextBox1.AppendText("[Architecture]::" + LoadedAssembly.MainModule.Architecture.ToString() + Environment.NewLine);
//                richTextBox1.AppendText("[EntryPoint]::" + LoadedAssembly.MainModule.EntryPoint.ToString() + Environment.NewLine);
//                richTextBox1.AppendText("[Mvid]::" + LoadedAssembly.MainModule.Mvid.ToString() + Environment.NewLine);
//            }
//            catch
//            {
//                ResetText();
//                MessageBox.Show("Unable to Read Assembly. It is Either Unmanaged or Obfuscated.");
//                status = true;
//                return;
//            }
//        }
//
//
//        private void LoadAsmContents()
//        {
//            LoadedAssembly = AssemblyDefinition.ReadAssembly(textBox1.Text);
//            TreeNode tn = null;
//            IEnumerator<TypeDefinition> enumerator1 = LoadedAssembly.MainModule.Types.GetEnumerator();
//            while (enumerator1.MoveNext())
//            {
//                TypeDefinition td = enumerator1.Current;
//                tn = this.treeView1.Nodes.Add(td.Name.ToString());
//                IEnumerator<MethodDefinition> enumerator2 = td.Methods.GetEnumerator();
//
//                while (enumerator2.MoveNext())
//                {
//                    MethodDefinition method_def = (MethodDefinition)enumerator2.Current;
//                    if (method_def.IsConstructor)
//                    {
//                        tn.Nodes.Add(method_def.Name.ToString());
//                    }
//                    tn.Nodes.Add(method_def.Name.ToString());
//
//                }
//
//            }
//
//        }
//    }
//}
