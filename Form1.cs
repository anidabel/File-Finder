using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Security.AccessControl;

namespace lab01
{
    public partial class Form1 : Form
    {
        static EventWaitHandle autoEvent = new AutoResetEvent(false);
        static EventWaitHandle manualEvent = new ManualResetEvent(false);
        static DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\");
        static List<FileInfo> fileInfoList;
        Thread AuxiliaryThread;

        static string subString = null;
        static string template = null;
        static string directory = null;
        static bool templateBool = false;
        static bool substringBool = false;
        static bool directoryBool = false;

        public Form1()
        {
            InitializeComponent();
            templateText.Enabled = false;
            substringText.Enabled = false;
            directoryText.Enabled = false;
            pauseButton.Enabled = false;
            stopButton.Enabled = false;
            resumeButton.Enabled = false;
            fileInfoList = new List<FileInfo>();
            //listBox.Items.Add(AppDomain.GetCurrentThreadId().ToString());
        }

        //SELECT THE "TEMPLATE" OPTION 
        private void templateBox_CheckedChanged(object sender, EventArgs e)
        {
            templateText.Enabled = templateBox.Checked;
            templateText.Clear();
            if (templateBox.Checked == true)
                MessageBox.Show("Мы не несем ответственность за правильность \n" +
                    "введенного Вами шаблона", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (templateBox.Checked == false)
                templateBool = false;
        }
        private void templateText_TextChanged(object sender, EventArgs e)
        {
            if (templateText.Text.Length == 0)
                MessageBox.Show("С пустым шаблоном не работаем", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //SELECT THE "WITH SUBSTRING" OPTION
        private void substringBox_CheckedChanged(object sender, EventArgs e)
        {
            substringText.Enabled = substringBox.Checked;
            substringText.Clear();
            if (substringBox.Checked == false)
                substringBool = false;
        }
        private void substringText_TextChanged(object sender, EventArgs e)
        {
            if (substringText.Text.Length == 0)
            {
                MessageBox.Show("С пустой подстрокой не работаем", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                substringText.Clear();
            }
            String errorCharacter = "\"|/*:?<\\>";
            for (int i = 0; i < errorCharacter.Length; i++)
            {
                if (substringText.Text.IndexOf(errorCharacter[i]) != -1)
                {
                    MessageBox.Show("Введенная строка содержит запрещенный символ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    substringText.Clear();
                }
            }

            if (substringText.Text.Length > 100)
            {
                MessageBox.Show("Слишком длинная строчка", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                substringText.Clear();
            }

            substringBool = true;
        }

        //SELECT THE OPTION "FROM A SPECIFIC DIRECTORY"
        private void directoryBox_CheckedChanged(object sender, EventArgs e)
        {
            directoryText.Enabled = directoryBox.Checked;
            if (directoryBox.Checked == true)
                MessageBox.Show("По умолчанию задан диск D:\\ ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            directoryText.Clear();
            if (directoryBox.Checked == false)
                directoryBool = false;
        }
        private void directoryText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                directoryInfo = new DirectoryInfo(directoryText.Text);
            }
            catch (Exception EE)
            {
                MessageBox.Show(EE.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                directoryText.Clear();
            }

        }

        private void aboutTheAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Belkina Daria, 9 group", "About the Author", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            fileInfoList.Clear();
            listBox.Items.Clear();

            pauseButton.Enabled = true;
            stopButton.Enabled = true;


            if (templateBox.Checked == true && substringBox.Checked == false && templateText.Text.Length > 0)
            {
                template = templateText.Text;
                directory = directoryText.Text;
                if (directory.Length != 0)
                    directoryInfo = (new DirectoryInfo(directory));
                AuxiliaryThread = new Thread(Form1.SearchFileWithTemplate);

                if (directoryInfo != null)
                {
                    AuxiliaryThread.Start();
                    //Thread.Sleep(5000);
                }
                else
                    MessageBox.Show("Не выбран каталог", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                autoEvent.WaitOne();
                if (fileInfoList.Count > 0)
                    lock (fileInfoList)
                        foreach (FileInfo f in fileInfoList)
                            listBox.Items.Add(f.FullName);
            }
            else if (templateBox.Checked == true && substringBox.Checked == false)
                MessageBox.Show("Не выбран шаблон", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (substringBox.Checked == true && templateBox.Checked == false && substringText.Text.Length > 0)
            {
                subString = substringText.Text;
                directory = directoryText.Text;
                if (directory.Length != 0)
                    directoryInfo = (new DirectoryInfo(directory));

                AuxiliaryThread = new Thread(Form1.SearchFileWithSubstring);
                if (directoryInfo != null)
                    AuxiliaryThread.Start();
                else
                    MessageBox.Show("Не выбран каталог", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                autoEvent.WaitOne();
                if (fileInfoList.Count > 0)
                    lock (fileInfoList)
                        foreach (FileInfo f in fileInfoList)
                            listBox.Items.Add(f.FullName);
            }
            else if (substringBox.Checked == true && templateBox.Checked == false)
                MessageBox.Show("Не выбрана подстрока", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (substringBox.Checked == true && templateBox.Checked == true && substringText.Text.Length > 0 && templateText.Text.Length > 0)
            {
                template = templateText.Text;
                subString = substringText.Text;
                directory = directoryText.Text;
                if (directory.Length != 0)
                    directoryInfo = (new DirectoryInfo(directory));

                AuxiliaryThread = new Thread(Form1.SearchFileWithTemplateAndSubstring);
                if (directoryInfo != null)
                    AuxiliaryThread.Start();
                else
                    MessageBox.Show("Не выбран каталог", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                autoEvent.WaitOne();
                if (fileInfoList.Count > 0)
                    lock (fileInfoList)
                        foreach (FileInfo f in fileInfoList)
                            listBox.Items.Add(f.FullName);
            }
            else if (substringBox.Checked == true && templateBox.Checked == true)
                MessageBox.Show("Не выбрана подстрока или шаблон", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выбираете необходимый пункт, напротив него разблокируется поле для ввода соответствующей информации\n" +
                "После ввода всей необходимой информации нажмите на кнопку START", "Supporting Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (AuxiliaryThread.IsAlive)
            {
                AuxiliaryThread.Suspend();
                startButton.Enabled = false;

                resumeButton.Enabled = true;
                stopButton.Enabled = true;

                directoryBox.Enabled = false;
                directoryText.Enabled = false;
                templateBox.Enabled = false;
                templateText.Enabled = false;
                substringBox.Enabled = false;
                substringText.Enabled = false;
                MessageBox.Show("Поток приостановлен", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Поток закончил работу, приостанавливать нечего", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            resumeButton.Enabled = true;
            stopButton.Enabled = true;
            if (directoryText.Text.Length > 0)
            {
                directoryBox.Enabled = true;
                directoryText.Enabled = true;
            }
            if (templateText.Text.Length > 0)
            {
                templateBox.Enabled = true;
                templateText.Enabled = true;
            }
            if (substringText.Text.Length > 0)
            {
                substringBox.Enabled = true;
                substringText.Enabled = true;
            }
            AuxiliaryThread.Resume();
            MessageBox.Show("Поток восстановил работу", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (AuxiliaryThread.IsAlive)
            {
                startButton.Enabled = false;

                resumeButton.Enabled = false;
                stopButton.Enabled = true;

                directoryBox.Enabled = false;
                directoryText.Enabled = false;
                templateBox.Enabled = false;
                templateText.Enabled = false;
                substringBox.Enabled = false;
                substringText.Enabled = false;
                try
                {
                    AuxiliaryThread.Abort();
                }
                catch (Exception EE)
                {
                    MessageBox.Show(EE.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                MessageBox.Show("Поток остановлен", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Поток закончил работу, останавливать нечего", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        ///////////////////////////////////////////////

        private static void SearchFileWithTemplate()
        {
            FileInfo[] allFiles = null;
            try
            {
                allFiles = directoryInfo.GetFiles(template, SearchOption.TopDirectoryOnly);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (allFiles != null)
                foreach (FileInfo f in allFiles)
                {
                    try
                    {
                        lock (fileInfoList)
                            fileInfoList.Add(f);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            DirectoryInfo[] allDirectories = null;
            try
            {
                allDirectories = directoryInfo.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (allDirectories != null)
                foreach (DirectoryInfo dI in allDirectories)
                {
                    try
                    {
                        HelpSearchFileWithTemplate(new HelpThread(dI));
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            autoEvent.Set();
        }

        private static void HelpSearchFileWithTemplate(HelpThread hT)
        {
            manualEvent.Reset();
            HelpThread helpT = (HelpThread)hT;
            FileInfo[] allFiles = null;
            try
            {
                allFiles = helpT.dirInfo.GetFiles(template, SearchOption.TopDirectoryOnly);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (allFiles != null)
                foreach (FileInfo f in allFiles)
                {
                    try
                    {
                        lock (fileInfoList)
                            fileInfoList.Add(f);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            DirectoryInfo[] allDirectories = null;
            try
            {
                allDirectories = helpT.dirInfo.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (allDirectories != null)
                foreach (DirectoryInfo dI in allDirectories)
                {
                    try
                    {
                        HelpSearchFileWithTemplate(new HelpThread(dI));
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private static void SearchFileWithSubstring()
        {
            FileInfo[] allFiles = null;
            try
            {
                allFiles = directoryInfo.GetFiles();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (allFiles != null)
                foreach (FileInfo f in allFiles)
                {
                    try
                    {
                        if (f.Name.Contains(subString))
                            lock (fileInfoList)
                                fileInfoList.Add(f);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            DirectoryInfo[] allDirectories = null;
            try
            {
                allDirectories = directoryInfo.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (allDirectories != null)
                foreach (DirectoryInfo dI in allDirectories)
                {
                    try
                    {
                        HelpSearchFileWithSubstring(new HelpThread(dI));
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            autoEvent.Set();
        }

        private static void HelpSearchFileWithSubstring(HelpThread hT)
        {
            manualEvent.Reset();
            HelpThread helpT = (HelpThread)hT;
            FileInfo[] allFiles = null;
            try
            {
                allFiles = helpT.dirInfo.GetFiles();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (allFiles != null)
                foreach (FileInfo f in allFiles)
                {
                    try
                    {
                        if (f.Name.Contains(subString))
                            lock (fileInfoList)
                                fileInfoList.Add(f);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            DirectoryInfo[] allDirectories = null;
            try
            {
                allDirectories = helpT.dirInfo.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (allDirectories != null)
                foreach (DirectoryInfo dI in allDirectories)
                {
                    try
                    {
                        HelpSearchFileWithSubstring(new HelpThread(dI));
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private static void SearchFileWithTemplateAndSubstring()
        {
            FileInfo[] allFiles = null;
            try
            {
                allFiles = directoryInfo.GetFiles(template, SearchOption.TopDirectoryOnly);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (allFiles != null)
                foreach (FileInfo f in allFiles)
                {
                    try
                    {
                        if (f.Name.Contains(subString))
                            lock (fileInfoList)
                                fileInfoList.Add(f);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            DirectoryInfo[] allDirectories = null;
            try
            {
                allDirectories = directoryInfo.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (allDirectories != null)
                foreach (DirectoryInfo dI in allDirectories)
                {
                    try
                    {
                        HelpSearchFileWithTemplateAndSubstring(new HelpThread(dI));
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            autoEvent.Set();
        }

        private static void HelpSearchFileWithTemplateAndSubstring(HelpThread hT)
        {
            manualEvent.Reset();
            HelpThread helpT = (HelpThread)hT;
            FileInfo[] allFiles = null;
            try
            {
                allFiles = helpT.dirInfo.GetFiles(template, SearchOption.TopDirectoryOnly);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (allFiles != null)
                foreach (FileInfo f in allFiles)
                {
                    try
                    {
                        if (f.Name.Contains(subString))
                            lock (fileInfoList)
                                fileInfoList.Add(f);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            DirectoryInfo[] allDirectories = null;
            try
            {
                allDirectories = helpT.dirInfo.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (allDirectories != null)
                foreach (DirectoryInfo dI in allDirectories)
                {
                    try
                    {
                        HelpSearchFileWithTemplateAndSubstring(new HelpThread(dI));
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }
    }

    class HelpThread
    {
        public DirectoryInfo dirInfo;
        public HelpThread(DirectoryInfo dI)
        {
            dirInfo = dI;
        }
    }
}