namespace CustomWindowsForm
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
    	    DialogResult dr = MessageBox.Show("WARNING! READ THIS MESSAGE FIRST", "You are running the Yashma/Chaos v5 Ransomware builder. Do you want to continue? By clicking on yes, you accept that you are liable and you will be legally responsible for any outcomes of this malware!", MessageBoxButtons.YesNo);
    	    switch(dr)
    	    {
                case DialogResult.Yes:
    		        Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new BlackForm());
            	break;
       	      case DialogResult.No:
          		break;
    	    }
        }
    }
}
