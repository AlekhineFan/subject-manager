using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SQLite;
using System.ComponentModel;

namespace Felmérés_eredmények
{
    public class SQLiteManager
    {
        public SQLiteConnection connection;
        public SQLiteCommand command;

        public void Connect()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Sqlite"].ConnectionString;
                connection = new SQLiteConnection(connectionString);
                connection.Open();
                command = connection.CreateCommand();
            }
            catch (Exception ex)
            {
                throw new DbException("Unsuccessful database connection!", ex);
            }
        }
        public void CloseConnection()
        {
            try
            {
                connection.Close();
                command.Dispose();
            }
            catch (Exception ex)
            {
                throw new DbException("Closing the connection was unsuccessful!", ex);
            }
        }

        public void NewSubjectWithState(Subject subject, SubjectState subjState)
        {
            Connect();
            string query = "INSERT INTO Subject VALUES (@id, @FirstName, @LastName, @BirthDate); SELECT last_insert_rowid();";
            try
            {
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("id", null);
                command.Parameters.AddWithValue("@FirstName", subject.FirstName);
                command.Parameters.AddWithValue("@LastName", subject.LastName);
                command.Parameters.AddWithValue("@BirthDate", subject.BirthDate);

                subjState.SubjectId = (int)((long)command.ExecuteScalar());

                command.CommandText = "INSERT INTO SubjectState VALUES (@id, @lastVisit, @stnr, @atnr, @galant, @tlre, @tlrh, @mar, @szo, @mor, @left, @right, @niszt, @notes, @subjId, @ejto, @bab, @schi)";
                command.Parameters.AddWithValue("id", null);
                command.Parameters.AddWithValue("@lastVisit", subjState.LastVisit);
                command.Parameters.AddWithValue("@stnr", subjState.Stnr);
                command.Parameters.AddWithValue("@atnr", subjState.Atnr);
                command.Parameters.AddWithValue("@galant", subjState.Galant);
                command.Parameters.AddWithValue("@tlre", subjState.TlrE);
                command.Parameters.AddWithValue("tlrh", subjState.TlrH);
                command.Parameters.AddWithValue("@mar", subjState.Mar);
                command.Parameters.AddWithValue("@szo", subjState.Szo);
                command.Parameters.AddWithValue("@mor", subjState.Mor);
                command.Parameters.AddWithValue("@left", subjState.Left);
                command.Parameters.AddWithValue("@right", subjState.Right);
                command.Parameters.AddWithValue("@niszt", subjState.Niszt);
                command.Parameters.AddWithValue("@notes", subjState.Notes);
                command.Parameters.AddWithValue("@subjId", subjState.SubjectId);
                command.Parameters.AddWithValue("@ejto", subjState.Ejto);
                command.Parameters.AddWithValue("@bab", subjState.Babinski);
                command.Parameters.AddWithValue("@schi", subjState.Schilder);
                command.ExecuteNonQuery();
                CloseConnection();

            }
            catch (Exception ex)
            {

                throw new DbException("Inserting new subject was unsuccessful!", ex);
            }
        }
        public void NewSubjectState(SubjectState subjState)
        {
            Connect();
            try
            {
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO SubjectState VALUES(@id, @lastVisit, @stnr, @atnr, @galant, @tlre, @tlrh, @mar, @szo, @mor, @left, @right, @niszt, @notes, @subjId, @ejto, @bab, @schi)";
                command.Parameters.AddWithValue("@id", null);
                command.Parameters.AddWithValue("@lastVisit", subjState.LastVisit);
                command.Parameters.AddWithValue("@stnr", subjState.Stnr);
                command.Parameters.AddWithValue("@atnr", subjState.Atnr);
                command.Parameters.AddWithValue("@galant", subjState.Galant);
                command.Parameters.AddWithValue("@tlre", subjState.TlrE);
                command.Parameters.AddWithValue("tlrh", subjState.TlrH);
                command.Parameters.AddWithValue("@mar", subjState.Mar);
                command.Parameters.AddWithValue("@szo", subjState.Szo);
                command.Parameters.AddWithValue("@mor", subjState.Mor);
                command.Parameters.AddWithValue("@left", subjState.Left);
                command.Parameters.AddWithValue("@right", subjState.Right);
                command.Parameters.AddWithValue("@niszt", subjState.Niszt);
                command.Parameters.AddWithValue("@notes", subjState.Notes);
                command.Parameters.AddWithValue("@subjId", subjState.SubjectId);
                command.Parameters.AddWithValue("@ejto", subjState.Ejto);
                command.Parameters.AddWithValue("@bab", subjState.Babinski);
                command.Parameters.AddWithValue("@schi", subjState.Schilder);
                command.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw new DbException("Adding this parameter was not successful!", ex);
            }
        }
        public void UpdateNotes(Subject subject, string newNote)
        {
            Connect();
            try
            {
                command.Parameters.Clear();
                command.CommandText = $"UPDATE SubjectState SET " +
                    $"Note = '{newNote}' " +
                    $"WHERE SubjectId = {subject.Id}";
                command.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {

                throw new DbException("Saving new note was unsuccessful!", ex);
            }
        }
        public string SearchLastName(string current)
        {
            string result;
            try
            {
                Connect();
                command.Parameters.Clear();
                command.CommandText = $"SELECT LastName FROM Subject WHERE LastName LIKE '@current%'";
                command.Parameters.AddWithValue("@current", current);
                object numberOfResults = command.ExecuteNonQuery();

                if ((int)numberOfResults == -1)
                {
                    result = "";
                }
                else
                {
                    result = command.ExecuteNonQuery().ToString();
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new DbException("Searching for last name was unsuccessful!", ex);
            }
            return result;
        }
        public void DeleteSubject(Subject subj)
        {
            Connect();
            try
            {
                command.Parameters.Clear();
                command.CommandText = "DELETE FROM SubjectState WHERE SubjectId = @Id";
                command.Parameters.AddWithValue("@Id", subj.Id);
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM Subject WHERE Id = @Id";
                command.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw new DbException("Deleting unsuccessful!", ex);
            }
        }

        public void EditSubjectData(Subject subject)
        {
            Connect();
            try
            {
                command.Parameters.Clear();
                command.CommandText = "UPDATE Subject SET " +
                    "FirstName = @fname, " +
                    "LastName = @lname, " +
                    "BirthDate = @bdate " +
                    "WHERE Id = @sid";
                command.Parameters.AddWithValue("@fname", subject.FirstName);
                command.Parameters.AddWithValue("@lname", subject.LastName);
                command.Parameters.AddWithValue("@bdate", subject.BirthDate);
                command.Parameters.AddWithValue("@sid", subject.Id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Editing subject data was unsuccessful!" + ex.Message);
            }
            CloseConnection();
        }

        public List<SubjectState> GetResultsForSubject(Subject subject)
        {
            List<SubjectState> states = new List<SubjectState>();
            Connect();

            command.Parameters.Clear();
            string query = $"SELECT * FROM SubjectState WHERE SubjectId = {subject.Id}";
            command = new SQLiteCommand(query, connection);

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    /*int? sid = (int?)reader["SubjectId"];
                    string lv = reader["LastVisit"].ToString();
                    int st = (int)reader["Stnr"];
                    int at = (int)reader["Atnr"];
                    int gal = (int)reader["Galant"];
                    int te =  (int)reader["Tlre"];
                    int th = (int)reader["Tlrh"];
                    int mar =  (int)reader["Mar"];
                    int sz = (int)reader["Szo"];
                    int mo = (int)reader["Mor"];
                    int l = (int)reader["Left"];
                    int r = (int)reader["Right"];
                    int n = (int)reader["Niszt"];
                    string nt = reader["Note"].ToString();
                    int e = (int)reader["Ejto"];
                    int b = (int)reader["Babinski"];
                    int sch =  (int)reader["Schilder"];*/



                    states.Add(new SubjectState(
                       reader.GetInt32(14),
                       reader.GetString(1),
                       reader.GetInt32(2),
                       reader.GetInt32(3),
                       reader.GetInt32(4),
                       reader.GetInt32(5),
                       reader.GetInt32(6),
                       reader.GetInt32(7),
                       reader.GetInt32(8),
                       reader.GetInt32(9),
                       reader.GetInt32(10),
                       reader.GetInt32(11),
                       reader.GetInt32(12),
                       reader.GetString(13),
                       reader.GetInt32(15),
                       reader.GetInt32(16),
                       reader.GetInt32(17)
                       ));
                }
            }
            CloseConnection();
            return states;
        }

        public void DeleteSubjectState(Subject subject, SubjectState state)
        {
            Connect();
            try
            {
                command.Parameters.Clear();
                command.CommandText = "DELETE FROM SubjectState WHERE Id = (SELECT Id FROM SubjectState WHERE SubjectId = @Id AND LastVisit = @lv LIMIT 1)";
                command.Parameters.AddWithValue("@Id", subject.Id);
                command.Parameters.AddWithValue("@lv", state.LastVisit);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Deleting SubjectState was unsuccessful." + ex.Message);
            }
            CloseConnection();
        }
        public BindingList<Subject> GetAllSubjects()
        {
            BindingList<Subject> subjects = new BindingList<Subject>();
            try
            {
                Connect();
                string query = "SELECT * FROM Subject LEFT JOIN SubjectState ON Subject.Id = SubjectState.SubjectId";
                command = new SQLiteCommand(query, connection);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (subjects.Count == 0 || subjects.LastOrDefault().Id != reader.GetInt32(0))
                        {
                            subjects.Add(new Subject(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3)
                                ));


                            subjects.LastOrDefault().SubjectStates.Add(new SubjectState(
                                reader.GetInt32(18),
                                reader.GetString(5),
                                reader.GetInt32(6),
                                reader.GetInt32(7),
                                reader.GetInt32(8),
                                reader.GetInt32(9),
                                reader.GetInt32(10),
                                reader.GetInt32(11),
                                reader.GetInt32(12),
                                reader.GetInt32(13),
                                reader.GetInt32(14),
                                reader.GetInt32(15),
                                reader.GetInt32(16),
                                reader.GetString(17),
                                reader.GetInt32(19),
                                reader.GetInt32(20),
                                reader.GetInt32(21)
                                ));
                        }
                        else
                        {
                            subjects.LastOrDefault().SubjectStates.Add(new SubjectState(
                               reader.GetInt32(18),
                               reader.GetString(5),
                               reader.GetInt32(6),
                               reader.GetInt32(7),
                               reader.GetInt32(8),
                               reader.GetInt32(9),
                               reader.GetInt32(10),
                               reader.GetInt32(11),
                               reader.GetInt32(12),
                               reader.GetInt32(13),
                               reader.GetInt32(14),
                               reader.GetInt32(15),
                               reader.GetInt32(16),
                               reader.GetString(17),
                               reader.GetInt32(19),
                               reader.GetInt32(20),
                               reader.GetInt32(21)
                               ));
                        }
                    }
                    reader.Close();
                    CloseConnection();
                }
                return subjects;
            }
            catch (Exception ex)
            {
                throw new Exception("Database reading was not successful!" + ex.InnerException);
            }
        }
    }
}
