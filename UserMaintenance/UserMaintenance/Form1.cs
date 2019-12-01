using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();

            lblLastName.Text = Resource1.FullName; // label1
            btnAdd.Text = Resource1.Add; // button1
            Write.Text = Resource1.Write; // button2
            Delete.Text = Resource1.Delete; // button2

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = fullname.Text
            };
            users.Add(u);
        }

        private void Write_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Fájl mentése";
            saveFileDialog1.Filter = "Text Files (*.csv)|*.csv";
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (var item in listUsers.Items)
                    {
                        var u = (User) item;
                        sw.Write(u.ID.ToString());
                        sw.Write(';');
                        sw.Write(u.FullName.ToString());
                        sw.WriteLine();
                    }
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            users.Clear();
        }
    }
}
