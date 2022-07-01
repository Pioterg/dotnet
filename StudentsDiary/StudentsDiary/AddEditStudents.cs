using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class AddEditStudents : Form
    {
        //private string _filePath = Path.Combine(Environment.CurrentDirectory, "students.txt");

        private FileHelper<List<Student>> _fileHelper = new FileHelper<List<Student>>(Program.FilePath);

        private int _studentId;
        private Student _student;

        public AddEditStudents(int id = 0)
        {
            InitializeComponent();
            _studentId = id;
            GetStudentData();
            tbFirstName.Select();
        }

        private void GetStudentData()
        {
            if (_studentId != 0)
            {
                Text = "Edytowanie ucznia";

                var students = _fileHelper.DeserializeFromFile();
                _student = students.FirstOrDefault(x => x.Id == _studentId);

                if (_student == null)
                {
                    throw new Exception("Brak użytkownika o podanym Id.");
                }
                FillTextBoxes();
            }            
        }

        private void FillTextBoxes()
        {
            tbId.Text = _student.Id.ToString();
            tbFirstName.Text = _student.FirstName.ToString();
            tbLastName.Text = _student.LastName.ToString();
            tbMath.Text = _student.Math.ToString();
            tbPhysic.Text = _student.Physics.ToString();
            tbTechnology.Text = _student.Technology.ToString();
            tbPolishLang.Text = _student.PolishLang.ToString();
            tbForeignLang.Text = _student.ForeignLang.ToString();
            rtbComments.Text = _student.Comments.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var students = _fileHelper.DeserializeFromFile();

            if (_studentId != 0)
                students.RemoveAll(x => x.Id == _studentId);
            else
                AssignIdToNewStudent(students);

            AddNewUserToList(students);

            _fileHelper.SerializeToFile(students);
            Close();
        }

        private void AddNewUserToList(List<Student> students)
        {
            var student = new Student
            {
                Id = _studentId,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Comments = rtbComments.Text,
                Math = tbMath.Text,
                Physics = tbPhysic.Text,
                PolishLang = tbPolishLang.Text,
                ForeignLang = tbForeignLang.Text,
                Technology = tbTechnology.Text
            };

            students.Add(student);
        }

        private void AssignIdToNewStudent(List<Student> students)
        {
            var studentsWithtHighestId = students.OrderByDescending(x => x.Id).FirstOrDefault();

            _studentId = studentsWithtHighestId == null ? 1 : studentsWithtHighestId.Id + 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
