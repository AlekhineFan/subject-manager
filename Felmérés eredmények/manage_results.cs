using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Felmérés_eredmények
{
    public partial class Manage_results : Form
    {
        Subject Subject;
        SQLiteManager manager = new SQLiteManager();
        public Manage_results(Subject subject)
        {
            InitializeComponent();
            Subject = subject;

            textBoxLastName.Text = $"{Subject.LastName}";
            textBoxLastName.TextAlign = HorizontalAlignment.Center;

            textBoxFirstName.Text = $"{Subject.FirstName}";
            textBoxFirstName.TextAlign = HorizontalAlignment.Center;

            dateTimePickerBirthdate.Value = DateTime.Parse(Subject.BirthDate);
            dateTimePickerBirthdate.Enabled = false;

            textBoxFirstName.Enabled = false;
            textBoxLastName.Enabled = false;
            dateTimePickerBirthdate.Enabled = false;
            buttonSave.Enabled = false;
            buttonCancel.Enabled = false;

            listBoxVisits.DataSource = manager.GetResultsForSubject(Subject).OrderBy(s => s.LastVisit).ToList();
        }

        private void DeleteResult_Click(object sender, EventArgs e)
        {
            if (listBoxVisits.Items.Count < 2)
            {
                MessageBox.Show("Minden alanyhoz legalább egy bejegyzés kell, hogy tartozzon! Az eredmény törlése nem lehetséges. (Fontolja meg az alany törlését és újrafelvételét, vagy új eredmény felvételét a jelenlegi törlése előtt)", "Hiba - törlés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Biztosan törli a kijelölt eredményt?", "Törlés?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    SubjectState stateToDelete = (SubjectState)listBoxVisits.SelectedItem;
                    manager.DeleteSubjectState(Subject, stateToDelete);

                    listBoxVisits.DataSource = manager.GetResultsForSubject(Subject);
                }
            }
        }

        private void ListBoxVisits_DoubleClick(object sender, EventArgs e)
        {
            SubjectState selected = (SubjectState)listBoxVisits.SelectedItem;

            if (selected == null)
                return;

            MessageBox.Show($" STNR: {selected.Stnr}\n " +
                $"ATNR: {selected.Atnr}\n " +
                $"Galant: {selected.Galant}\n " +
                $"TLRH: {selected.TlrH}\n " +
                $"ejtőernyős: {selected.Ejto}\n " +
                $"TLRE: {selected.TlrE}\n " +
                $"Schilder: {selected.Schilder}\n " +
                $"Babinski: {selected.Babinski}\n " +
                $"Markoló: {selected.Mar}\n " +
                $"Szopó: {selected.Szo}\n " +
                $"Moro: {selected.Mor}\n " +
                $"Nystagmus: {selected.Niszt}\n " +
                $"bal agyfélteke: {selected.Left}\n " +
                $"jobb agyfélteke: {selected.Right}"
                , "Részletes eredmény", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CheckBoxEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEdit.Checked)
            {
                textBoxFirstName.Enabled = true;
                textBoxLastName.Enabled = true;
                dateTimePickerBirthdate.Enabled = true;
                buttonSave.Enabled = true;
                buttonCancel.Enabled = true;
            }
            else if (!checkBoxEdit.Checked)
            {
                textBoxFirstName.Enabled = false;
                textBoxLastName.Enabled = false;
                dateTimePickerBirthdate.Enabled = false;
                buttonSave.Enabled = false;
                buttonCancel.Enabled = false;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            bool tbLastNameFilled = !String.IsNullOrEmpty(textBoxLastName.Text);
            bool tbLastFirstFilled = !String.IsNullOrEmpty(textBoxFirstName.Text);
            DateTime birthday = dateTimePickerBirthdate.Value;
            int dateValidation = DateTime.Compare(DateTime.Now, birthday);

            if (!tbLastFirstFilled || !tbLastNameFilled)
            {
                MessageBox.Show("Az alanyhoz vezetéknévnek és keresztnévnek is kell tartoznia!", "Kitöltés - hiba", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dateValidation < 0)
            {
                MessageBox.Show("A születési dátum nem lehet későbbi az aktuális dátumnál!", "Kitöltés - hiba", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Subject.LastName = textBoxLastName.Text;
                Subject.FirstName = textBoxFirstName.Text;
                Subject.BirthDate = dateTimePickerBirthdate.Value.ToString("yyyy-MM-dd HH:mm");

                try
                {
                    manager.EditSubjectData(Subject);
                    DialogResult result = MessageBox.Show("Új adatok mentése sikeres!", "Sikeres mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                        this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Mentés - hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
