using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Felmérés_eredmények
{
    public partial class Alanyok_kezelese : Form
    {
        SQLiteManager manager = new SQLiteManager();
        public Subject Subject { get; set; }
        public SubjectState SubjectState { get; set; }
        public string Note { get; set; }
        public bool IsNoteOnly { get; set; }
        public string TextBoxCurrent { get; set; }
        public bool IsNewSubject { get; set; }
        public Alanyok_kezelese()
        {
            InitializeComponent();
            checkBoxNotesOnly.Enabled = false;
            listBoxSearchResults.Visible = false;
            IsNewSubject = true;
        }
        internal Alanyok_kezelese(Subject subject)
        {
            InitializeComponent();
            checkBoxNotesOnly.Enabled = false;
            listBoxSearchResults.Visible = false;

            Subject = subject;
            textBoxFirstName.Text = Subject.FirstName;
            textBoxLastName.Text = Subject.LastName;
            dateTimePickerBirthDay.Value = DateTime.Parse(Subject.BirthDate);
            textBoxNotes.Text = Subject.SubjectStates[subject.SubjectStates.Count - 1].Notes;

            textBoxFirstName.Enabled = false;
            textBoxLastName.Enabled = false;
            dateTimePickerBirthDay.Enabled = false;
            checkBoxNotesOnly.Enabled = true;

            IsNewSubject = false;

            listBoxSearchResults.Dispose();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            //manager = new SQLiteManager();
            IsNoteOnly = checkBoxNotesOnly.Checked;

            SubjectState = new SubjectState(
                   dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"),
                   (int)numericUpDownStnr.Value,
                   (int)numericUpDownAtnr.Value,
                   (int)numericUpDownGalant.Value,
                   (int)numericUpDownTlre.Value,
                   (int)numericUpDownTlrh.Value,
                   (int)numericUpDownMarkolo.Value,
                   (int)numericUpDownSzopo.Value,
                   (int)numericUpDownMoro.Value,
                   (int)numericUpDownBal.Value,
                   (int)numericUpDownJobb.Value,
                   (int)numericUpDownNyrt.Value,
                   textBoxNotes.Text,
                   (int)numericUpDownEjto.Value,
                   (int)numericUpDownBabinski.Value,
                   (int)numericUpDownSchilder.Value
                )
                ;

            if (IsNoteOnly)
            {
                manager.UpdateNotes(Subject, Note);
            }
            else
            {
                if (IsNewSubject)
                {
                    Subject = new Subject(
                      textBoxFirstName.Text,
                      textBoxLastName.Text,
                      dateTimePickerBirthDay.Value.ToString("yyyy-MM-dd")
                      );

                    SubjectState.SubjectId = Subject.Id;
                    Subject.SubjectStates.Add(SubjectState);
                    manager.NewSubjectWithState(Subject, SubjectState);
                }
                else if(!IsNewSubject)
                {
                    SubjectState.SubjectId = Subject.Id;
                    SubjectState.Notes = textBoxNotes.Text;
                    Note = textBoxNotes.Text;
                    manager.NewSubjectState(SubjectState);
                }
            }
        }

        private void CheckBoxNotesOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNotesOnly.Checked)
            {
                foreach (Control control in Controls)
                {
                    if (control.Text == "megjegyzések" || control.Name == "buttonSave" || control.Name == "buttonCancel")
                    {
                        control.Enabled = true;
                    }
                    else
                    {
                        control.Enabled = false;
                    }
                }
                buttonSave.Focus();
            }
            else
            {
                foreach (Control control in Controls)
                {
                    control.Enabled = true;
                }
            }
            checkBoxNotesOnly.Enabled = true;
        }

        private void TextBoxNotes_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxNotes.Text))
                return;
            Note = textBoxNotes.Text;
        }

        private void TextBoxLastName_TextChanged(object sender, EventArgs e)
        {
            //manager = new SQLiteManager();

            string current = textBoxLastName.Text.ToLower();

            BindingList<Subject> subjects = manager.GetAllSubjects();
            List<Subject> results = new List<Subject>();

            foreach (Subject subj in subjects)
            {
                if (subj.LastName.ToLower().StartsWith(current))
                {
                    results.Add(subj);
                }
            }
            listBoxSearchResults.DataSource = results;
            if (results.Count < 1)
            {
                listBoxSearchResults.Hide();
            }
            else
            {
                listBoxSearchResults.Visible = true;
            }
        }

        private void ListBoxSearchResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Subject selected = (Subject)listBoxSearchResults.SelectedItem;
                if (selected == null)
                    return;
                Subject = selected;
                textBoxFirstName.Text = Subject.FirstName;
                textBoxLastName.Text = Subject.LastName;
                dateTimePickerBirthDay.Value = DateTime.Parse(Subject.BirthDate);
                textBoxNotes.Text = Subject.SubjectStates[Subject.SubjectStates.Count - 1].Notes;

                textBoxFirstName.Enabled = false;
                textBoxLastName.Enabled = false;
                dateTimePickerBirthDay.Enabled = false;
                checkBoxNotesOnly.Enabled = true;

                listBoxSearchResults.Dispose();

                IsNewSubject = false;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                listBoxSearchResults.Hide();
                textBoxLastName.Focus();
                IsNewSubject = true;
            }
        }

        private void TextBoxLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBoxSearchResults.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Subject selected = (Subject)listBoxSearchResults.SelectedItem;
                if (selected == null)
                    return;
                Subject = selected;
                textBoxFirstName.Text = Subject.FirstName;
                textBoxLastName.Text = Subject.LastName;
                dateTimePickerBirthDay.Value = DateTime.Parse(Subject.BirthDate);
                textBoxNotes.Text = Subject.SubjectStates[Subject.SubjectStates.Count - 1].Notes;

                textBoxFirstName.Enabled = false;
                textBoxLastName.Enabled = false;
                dateTimePickerBirthDay.Enabled = false;
                checkBoxNotesOnly.Enabled = true;

                listBoxSearchResults.Dispose();

                IsNewSubject = false;
            }
            else if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Tab)
            {
                listBoxSearchResults.Hide();
                IsNewSubject = true;
            }
        }

        private void ListBoxSearchResults_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxSearchResults.Items.Count == 0)
            {
                listBoxSearchResults.Hide();
            }
        }
    }
}
