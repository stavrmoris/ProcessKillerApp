using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;

namespace ProcessKillerApp
{
    public partial class MainForm : Form
    {
        // Путь к файлу, в котором будет храниться имя сохраненного процесса
        private const string SavedProcessFileName = "saved_process.txt";

        public MainForm()
        {
            InitializeComponent();

            // Устанавливаем обработчики событий для кнопок и значка в трее
            this.btnKillProcess.Click += new System.EventHandler(this.btnKillProcess_Click);
            this.btnSaveProcess.Click += new System.EventHandler(this.btnSaveProcess_Click);
            this.notifyIcon1.Icon = SystemIcons.Application;
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);

            // Создаем контекстное меню для значка в трее и добавляем пункт "Выход"
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem menuItemExit = new ToolStripMenuItem("Выход");
            menuItemExit.Click += menuItemExit_Click;
            contextMenuStrip.Items.Add(menuItemExit);
            notifyIcon1.ContextMenuStrip = contextMenuStrip;

            // Проверяем наличие сохраненного процесса и добавляем его в контекстное меню
            if (File.Exists(SavedProcessFileName))
            {
                string savedProcessName = File.ReadAllText(SavedProcessFileName);
                AddSavedProcessMenuItem(savedProcessName);
            }

            // Устанавливаем минимальные и максимальные размеры формы
            this.MinimumSize = new Size(200, 100);
            this.MaximumSize = new Size(800, 400);
        }

        // Обработчик нажатия кнопки "Удалить процесс"
        private void btnKillProcess_Click([NotNull] object sender, EventArgs e)
        {
            string processName = txtProcessName.Text.Trim();

            if (!string.IsNullOrEmpty(processName))
            {
                try
                {
                    Process[] processes = Process.GetProcessesByName(processName);

                    if (processes.Length > 0)
                    {
                        foreach (Process process in processes)
                        {
                            process.Kill();
                        }

                        MessageBox.Show("Процесс успешно завершен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Процесс с указанным именем не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при завершении процесса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите имя процесса.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик нажатия кнопки "Сохранить процесс"
        private void btnSaveProcess_Click(object sender, EventArgs e)
        {
            string processName = txtProcessName.Text.Trim();

            if (!string.IsNullOrEmpty(processName))
            {
                try
                {
                    File.WriteAllText(SavedProcessFileName, processName);
                    MessageBox.Show("Процесс успешно сохранен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AddSavedProcessMenuItem(processName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении процесса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите имя процесса.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Добавление сохраненного процесса в контекстное меню значка в трее
        private void AddSavedProcessMenuItem(string processName)
        {
            ToolStripMenuItem menuItemSavedProcess = new ToolStripMenuItem(processName);
            menuItemSavedProcess.Click += (sender, e) => KillSavedProcess(processName);
            notifyIcon1.ContextMenuStrip.Items.Insert(0, menuItemSavedProcess);
        }

        // Завершение сохраненного процесса
        private void KillSavedProcess(string processName)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(processName);

                foreach (Process process in processes)
                {
                    process.Kill();
                }

                MessageBox.Show("Процесс успешно завершен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при завершении процесса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик закрытия формы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Отменить закрытие формы
                this.WindowState = FormWindowState.Minimized; // Сворачиваем форму в трей
                this.ShowInTaskbar = false; // Скрываем значок приложения из панели задач
                notifyIcon1.Visible = true; // Отображаем значок в трее
            }
        }

        // Обработчик изменения размера формы
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        // Обработчик двойного щелчка мыши по значку в трее
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        // Обработчик нажатия кнопки "Выход" в контекстном меню значка в трее
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Закрываем приложение
        }
    }
}
