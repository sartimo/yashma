namespace CustomWindowsForm
{
    using Microsoft.CSharp;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class Compiler
    {
        public Compiler(string sourceCode, string savePath, string iconLocation)
        {
            string[] sources = new string[] { "System.dll", "System.Linq.dll", "System.Windows.Forms.dll", "System.Text.RegularExpressions.dll", "System.Runtime.InteropServices.dll", "System.Security.dll" };
            string[] assemblyNames = sources;
            Dictionary<string, string> providerOptions = new Dictionary<string, string> {
                { 
                    "CompilerVersion",
                    "v4.0"
                }
            };
            string str = "/target:winexe /platform:anycpu /optimize+ ";
            bool flag = iconLocation == "";
            if (!flag)
            {
                str = str + "/win32icon:" + iconLocation;
            }
            CSharpCodeProvider objA = new CSharpCodeProvider(providerOptions);
            try
            {
                CompilerParameters options = new CompilerParameters(assemblyNames) {
                    GenerateExecutable = true,
                    GenerateInMemory = false,
                    OutputAssembly = savePath,
                    CompilerOptions = str,
                    TreatWarningsAsErrors = false,
                    IncludeDebugInformation = false
                };
                sources = new string[] { sourceCode };
                CompilerResults results = objA.CompileAssemblyFromSource(options, sources);
                flag = results.Errors.Count <= 0;
                if (flag)
                {
                    MessageBox.Show("Done!");
                }
                else
                {
                    IEnumerator enumerator = results.Errors.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            flag = enumerator.MoveNext();
                            if (!flag)
                            {
                                break;
                            }
                            CompilerError current = (CompilerError) enumerator.Current;
                            MessageBox.Show($"{current.ErrorText} Line: {current.Line} - Column: {current.Column} File: {current.FileName}");
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        if (!ReferenceEquals(disposable, null))
                        {
                            disposable.Dispose();
                        }
                    }
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Dispose();
                }
            }
        }
    }
}
