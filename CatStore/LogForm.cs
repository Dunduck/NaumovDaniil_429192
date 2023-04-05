using MaterialSkin.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CatStore
{
    public partial class LogForm : MaterialForm
    {
        ConnectionCatStore myConnection = new ConnectionCatStore();

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public LogForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents=true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Pink500, MaterialSkin.Primary.Pink700, MaterialSkin.Primary.Pink100, MaterialSkin.Accent.Pink200, MaterialSkin.TextShade.WHITE);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegForm regForm = new RegForm();
            this.Hide();
            regForm.ShowDialog();
           
        }

        private void LogBtn_Click(object sender, EventArgs e)
        {
            var loginUser = logTB.Text;
            var passUser = passTB.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select id_user, login_user, password_user, user_role from Login where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(queryString, myConnection.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                var user = new UserRoleCheck(Convert.ToInt32(table.Rows[0].ItemArray[0]), table.Rows[0].ItemArray[1].ToString(), Convert.ToInt32(table.Rows[0].ItemArray[3]));

                AdminForm admForm = new AdminForm(user);
                admForm.ShowDialog();
            }
            else
                MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            passTB.PasswordChar = '•';
        }
    }
}
