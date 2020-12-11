using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Felmérés_eredmények
{
    public partial class Form1 : Form
    {
        SQLiteManager manager = new SQLiteManager();
        SQLiteDataAdapter adapter;
        public static BindingList<Subject> subjects = new BindingList<Subject>();

        private void GetSubjectsInAlphabeticOrder()
        {
            subjects = manager.GetAllSubjects();
            listBoxSubjects.DataSource = subjects.OrderBy(s => s.LastName.ToLower()).ThenBy(s => s.FirstName.ToLower()).ToList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //manager = new SQLiteManager();
            GetSubjectsInAlphabeticOrder();
            dataGridView1.Visible = true;
            labelNumberOfSubjects.Text += $": {subjects.Count()}";
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonOrder_Click(object sender, EventArgs e)
        {
            GetSubjectsInAlphabeticOrder();
        }

        private void ButtonOrderByDate_Click(object sender, EventArgs e)
        {
            listBoxSubjects.DataSource = subjects.OrderByDescending(s => s.SubjectStates.LastOrDefault().LastVisit).ToList();
        }

        private void ToolStripMenuItem_ClickNewSubject(object sender, EventArgs e)
        {
            Alanyok_kezelese subjectForm = new Alanyok_kezelese();
            subjectForm.ShowDialog();

            DialogResult result = subjectForm.DialogResult;
            if (result == DialogResult.OK)
            {
                //manager = new SQLiteManager();
                GetSubjectsInAlphabeticOrder();
                listBoxSubjects.SelectedItem = subjectForm.Subject;
                dataGridView1.Visible = true;
                labelNumberOfSubjects.Text = $"alanyok: {subjects.Count()}";
            }
        }

        private void DeleteSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subject selected = (Subject)listBoxSubjects.SelectedItem;

            if (selected == null)
            {
                return;
            }
            DialogResult = (MessageBox.Show("Biztosan törli a kijelölt alanyt?", "Törlés?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning));

            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                //manager = new SQLiteManager();

                if (listBoxSubjects.SelectedIndex != -1)
                {
                    manager.DeleteSubject(selected);
                    manager.CloseConnection();
                    subjects.Remove(selected);
                    GetSubjectsInAlphabeticOrder();
                    labelNumberOfSubjects.Text = $"alanyok: {subjects.Count()}";

                    if (subjects.Count == 0)
                        dataGridView1.Visible = false;
                    textBoxNotes.Clear();
                }
            }
        }

        private void NewSubjectStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxSubjects.SelectedItem == null)
            {
                return;
            }
            Subject selected = (Subject)listBoxSubjects.SelectedItem;
            dataGridView1.Visible = true;

            Alanyok_kezelese subjectfrm = new Alanyok_kezelese(selected);
            subjectfrm.ShowDialog();

            GetSubjectsInAlphabeticOrder();
            listBoxSubjects.SelectedItem = subjectfrm.Subject;
            labelNumberOfSubjects.Text = $"alanyok: {subjects.Count()}";
        }

        private void ListBoxSubjects_SelectedValueChanged(object sender, EventArgs e)
        {
            Subject selected = (Subject)listBoxSubjects.SelectedItem;

            if (selected == null)
                return;
            textBoxNotes.Text = selected.SubjectStates[selected.SubjectStates.Count - 1].Notes;

            SQLiteManager manager = new SQLiteManager();
            manager.Connect();

            using (manager.connection)
            {
                adapter = new SQLiteDataAdapter($"SELECT [LastVisit] AS [időpont], [Stnr] AS [STNR], [Atnr] AS [ATNR], [Galant], [TlRH] AS [TLRH], [Ejto] AS [Ejtőe.], [Tlre] AS [TLRE], [Schilder] AS [Schild.], [Babinski] AS [Bab.], [Mar] AS [markoló], [Szo] AS [szopó], [Mor] AS [Moro], [Niszt] AS [Nyst.], [Left] AS [bal], [Right] AS [jobb] FROM [SubjectState] WHERE [SubjectId] = {selected.Id} ORDER BY [SubjectState].[LastVisit]", manager.connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                int totalRowHeight = dataGridView1.ColumnHeadersHeight;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    totalRowHeight += row.Height;
                }
                dataGridView1.Height = totalRowHeight;
            }
        }

        private void ListBoxSubjects_DoubleClick(object sender, EventArgs e)
        {
            Subject selected = (Subject)listBoxSubjects.SelectedItem;
            if (selected == null)
                return;

            if (selected.SubjectStates.Count < 2)
            {
                return;
            }
            else
            {
                SubjectState state = Evaluate.Difference(selected);
                double ratioDiff = Evaluate.PercentageDiff(selected);

                MessageBox.Show(
                    $" Stnr: {state.Stnr}\n " +
                    $"Atnr: {state.Atnr}\n " +
                    $"Galant: {state.Galant}\n " +
                    $"TLRH: {state.TlrH}\n " +
                    $"ejtőernyős: {state.Ejto}\n " + 
                    $"TLRE: {state.TlrE}\n " +
                    $"Schilder: {state.Schilder}\n " +
                    $"Babinski: {state.Babinski}\n " +
                    $"markoló: {state.Mar}\n " +
                    $"szopó: {state.Szo}\n " +
                    $"Moro: {state.Mor}\n " +
                    $"Nyst: {state.Niszt}\n " +
                    $"bal agyfélteke: {state.Left}\n " +
                    $"jobb agyfélteke: {state.Right}\n " +
                    $"százalékos változás a reflexekben: {ratioDiff}%",  "Utolsó két mérés különbsége", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ManageRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subject selected = (Subject)listBoxSubjects.SelectedItem;
            if (selected == null)
            {
                MessageBox.Show("Válasszon ki egy alanyt!", "Nincs kiválasztott alany!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Manage_results manageRes = new Manage_results(selected);
            manageRes.ShowDialog();

            GetSubjectsInAlphabeticOrder();
        }

        private void ButtonDbBackup_Click(object sender, EventArgs e)
        {
            string targetPath = "";
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    targetPath = dialog.SelectedPath;
                }
            }

            if (targetPath == String.Empty || targetPath == "")
                return;

            string pathCompatibleDate = new String(DateTime.Now.ToString().ToCharArray().Where(c => c != ':' && c != '/' && c != ' ').ToArray());

            string fileName = "subjects.db";
            string backupName = pathCompatibleDate + "_backup_subjects.db";
            string sourcePath = Directory.GetCurrentDirectory();
            string sourceFile = Path.Combine(sourcePath, fileName);
            string destinationFile = Path.Combine(targetPath, backupName);

            File.Copy(sourceFile, destinationFile, false);

            MessageBox.Show("Biztonsági másolat készítése a célmappában sikeres.", "Másolat kész", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
