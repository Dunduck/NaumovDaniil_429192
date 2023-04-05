using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatStore
{
    public partial class RegForm : MaterialForm
    {
        ConnectionCatStore myConnection = new ConnectionCatStore();
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public RegForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Pink500, MaterialSkin.Primary.Pink700, MaterialSkin.Primary.Pink100, MaterialSkin.Accent.Pink200, MaterialSkin.TextShade.WHITE);
            
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            LogForm logForm = new LogForm();
            this.Close();
            logForm.Show();
        }

        //Проверка на то, что оператор не создает уже существующего пользователя
        private Boolean checkUser()
        {
            var loginUser = logTB.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select id_user, login_user from Login where login_user = '{loginUser}'";

            SqlCommand command = new SqlCommand(queryString, myConnection.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            var loginUser = logTB.Text;
            var passUser = passTB.Text;

            //По умолчанию можно создать лишь обычного пользователя (id роли обычного польхователя = 2). Только админ может создать другого админа
            var roleUser = 2;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            if (checkUser() == false)
            {
                string queryString = $"insert into Login(login_user, password_user, user_role) values('{loginUser}', '{passUser}', '{roleUser}')";

                SqlCommand command = new SqlCommand(queryString, myConnection.GetConnection());

                myConnection.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт успешно создан!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogForm logForm = new LogForm();
                    this.Hide();
                    logForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Аккаунт не создан!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                myConnection.closeConnection();
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
