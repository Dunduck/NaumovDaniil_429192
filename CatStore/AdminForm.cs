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
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class AdminForm : MaterialForm
    {
        private readonly UserRoleCheck _user;

        ConnectionCatStore myConnection = new ConnectionCatStore();
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        int selectedRow;

        public AdminForm(UserRoleCheck user)
        {
            _user = user;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Pink500, MaterialSkin.Primary.Pink700, MaterialSkin.Primary.Pink100, MaterialSkin.Accent.Pink200, MaterialSkin.TextShade.WHITE);
            _user = user;
        }

        private void Role()
        {
            if(_user.Role == 1)
            {
                buyBtn.Enabled = false;
                userOperationLabel.Visible = false;
            }
            else if (_user.Role == 2)
            {
                buyBtn.Enabled = true;

                eraseBtn.Enabled = false;

                addBtn.Enabled = false;                
                delBtn.Enabled = false;
                updBtn.Enabled = false;
                saveBtn.Enabled = false;

                idModelCatTB.Enabled = false;
                breedTB.Enabled = false;
                genderTB.Enabled = false;
                colourTB.Enabled = false;
                ageTB.Enabled = false;

                clearBtn2.Enabled = false;
                costTB.Enabled = false;
                idModelCatCatTB.Enabled = false;





                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage5);
            }
        }

        //Событие загрузки формы. Создание полей в dgw и их заполнение
        private void AdminForm_Load(object sender, EventArgs e)
        {
            userStatusLabel.Text = $"{_user.Login}: {_user.Status}";
            Role();
            CreateColumns();
            RefreshDataGrid1(catModelDGV);
            RefreshDataGrid2(catDGV);
            RefreshDataGrid3(operationDGV);
            RefreshDataGrid4(loginDGV);
            RefreshDataGrid5(roleDGV);
        }

        //Создание полей в dgw
        private void CreateColumns()
        {
            var roleUser = _user.Role;                       

            if(roleUser == 2)
            {
                catModelDGV.Columns.Add("id_modelcat", "id");
                catModelDGV.Columns.Add("breed_modelcat", "Порода кошки");
                catModelDGV.Columns.Add("gender_modelcat", "Пол кошки");
                catModelDGV.Columns.Add("сolour_modelcat", "Цвет кошки");
                catModelDGV.Columns.Add("age_modelcat", "Возраст кошки");

                catDGV.Columns.Add("id_cat", "id");
                catDGV.Columns.Add("add_date_cat", "Дата добавления");
                catDGV.Columns.Add("upd_date_cat", "Дата последнего изменения");
                catDGV.Columns.Add("cost_cat", "Цена");
                catDGV.Columns.Add("id_modelcat", "id модели кошки");
                catDGV.Columns.Add("IsNew", String.Empty);

                operationDGV.Columns.Add("id_cat", "id");
                operationDGV.Columns.Add("add_date_cat", "Дата добавления");
                operationDGV.Columns.Add("upd_date_cat", "Дата последнего изменения");
                operationDGV.Columns.Add("cost_cat", "Цена");
                operationDGV.Columns.Add("id_modelcat", "id модели кошки");
                operationDGV.Columns.Add("purchasedate", "Дата продажи");
                operationDGV.Columns.Add("id_user", "id покупателя");
            }
            else
            {
                catModelDGV.Columns.Add("id_modelcat", "id");
                catModelDGV.Columns.Add("breed_modelcat", "Порода кошки");
                catModelDGV.Columns.Add("gender_modelcat", "Пол кошки");
                catModelDGV.Columns.Add("сolour_modelcat", "Цвет кошки");
                catModelDGV.Columns.Add("age_modelcat", "Возраст кошки");
                catModelDGV.Columns.Add("IsNew", String.Empty);

                catDGV.Columns.Add("id_cat", "id");
                catDGV.Columns.Add("add_date_cat", "Дата добавления");
                catDGV.Columns.Add("upd_date_cat", "Дата последнего изменения");
                catDGV.Columns.Add("cost_cat", "Цена");
                catDGV.Columns.Add("id_modelcat", "id модели кошки");
                catDGV.Columns.Add("IsNew", String.Empty);

                operationDGV.Columns.Add("id_cat", "id");
                operationDGV.Columns.Add("add_date_cat", "Дата добавления");
                operationDGV.Columns.Add("upd_date_cat", "Дата последнего изменения");
                operationDGV.Columns.Add("cost_cat", "Цена");
                operationDGV.Columns.Add("id_modelcat", "id модели кошки");
                operationDGV.Columns.Add("purchasedate", "Дата продажи");
                operationDGV.Columns.Add("id_user", "id покупателя");
            }
                

            
            loginDGV.Columns.Add("id_user", "id");
            loginDGV.Columns.Add("login_user", "Логин");
            loginDGV.Columns.Add("password_user", "Пароль");
            loginDGV.Columns.Add("user_role", "Роль");
            loginDGV.Columns.Add("IsNew", String.Empty);

            roleDGV.Columns.Add("id_role", "id");
            roleDGV.Columns.Add("name_role", "Роль");
            roleDGV.Columns.Add("IsNew", String.Empty);
        }


        

        ////////////////////////////////////////////////////////////////////////////////////////////////
        //Методы Model Cat
        //Метод для заполнения catModelDGV
        private void ReadSingleRow1(DataGridView dgw, IDataRecord record)
        {
            var roleUser = _user.Role;
            if (roleUser == 2)
            {
                dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4));
            }
            else
            {
                dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4), RowState.ModifiedNew);
            }
        }

        //Метод для обновления catModelDGV
        private void RefreshDataGrid1(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"Select * from CatModel";
            
            SqlCommand command = new SqlCommand(queryString, myConnection.GetConnection());

            myConnection.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }
            reader.Close();
        }

        
        //Метод для кнопки "Изменить"
        private void Change1()
        {
            var selectedRowIndex = catModelDGV.CurrentCell.RowIndex;

            var id = idModelCatTB.Text;
            var breed = breedTB.Text;
            char gender = Convert.ToChar(genderTB.Text);
            var colour = colourTB.Text;
            int age = Convert.ToInt32(ageTB.Text);

            if (catModelDGV.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(ageTB.Text, out age))
                {
                    catModelDGV.Rows[selectedRowIndex].SetValues(id, breed, gender, colour, age);
                    catModelDGV.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Возраст должен быть целым числом от 1 по 15", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        //Метод для строки поиска записей в catModelDGV
        private void Search1(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from CatModel where concat (id_modelcat, breed_modelcat, gender_modelcat, сolour_modelcat, age_modelcat) like '%" + searchTB.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, myConnection.GetConnection());

            myConnection.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow1(dgw, read);
            }

            read.Close();
        }

        //Метод, который помечает выделенную строку на удаление и скрывает эту строку из catModelDGV
        private void deleteRow1()
        {
            int index = catModelDGV.CurrentCell.RowIndex;

            catModelDGV.Rows[index].Visible = false;

            if (catModelDGV.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                catModelDGV.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }

            catModelDGV.Rows[index].Cells[5].Value = RowState.Deleted;

        }

        /*Метод, который взаимодействует с помеченными строками и 
        используется для сохранения данных, измененных в catModelDGV, в бд

         RowState.Existed - ничего не делает со строкой
         RowState.Deleted - удаляет помеченную строку в бд
         RowState.Modified - изменяет помеченную строку с нужным индексом в бд
        */
        private void Update1()
        {
            myConnection.openConnection();

            for (int index = 0; index < catModelDGV.Rows.Count; index++)
            {
                var rowState = (RowState)catModelDGV.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(catModelDGV.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from CatModel where id_modelcat = {id}";

                    var command = new SqlCommand(deleteQuery, myConnection.GetConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = catModelDGV.Rows[index].Cells[0].Value.ToString();
                    var breed = catModelDGV.Rows[index].Cells[1].Value.ToString();
                    var gender = catModelDGV.Rows[index].Cells[2].Value.ToString();
                    var colour = catModelDGV.Rows[index].Cells[3].Value.ToString();
                    var age = catModelDGV.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"update CatModel set breed_modelcat = '{breed}', gender_modelcat = '{gender}',сolour_modelcat = '{colour}',age_modelcat = '{age}' where id_modelcat = '{id}'";

                    var command = new SqlCommand(changeQuery, myConnection.GetConnection());
                    command.ExecuteNonQuery();
                }
            }

            myConnection.closeConnection();
        }

        //Метод, который очищает textBox'ы заполнения данных о записи catModelDGV
        private void ClearField1()
        {
            idModelCatTB.Text = string.Empty;
            breedTB.Text = string.Empty;
            genderTB.Text = string.Empty;
            colourTB.Text = string.Empty;
            ageTB.Text = string.Empty;
        }

        //------------------------------------------------------------------------------------
        //События Model Cat
        //Событие с заполнением textBox'ов данными из строки в catModelDGV 
        private void catModelDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow= e.RowIndex;

            if(e.RowIndex >=0)
            {
                DataGridViewRow row = catModelDGV.Rows[selectedRow];

                idModelCatTB.Text = row.Cells[0].Value.ToString();
                breedTB.Text = row.Cells[1].Value.ToString();
                genderTB.Text = row.Cells[2].Value.ToString();
                colourTB.Text = row.Cells[3].Value.ToString();
                ageTB.Text = row.Cells[4].Value.ToString();
            }
        }

        //Кнопка обновления catModelDGV
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshDataGrid1(catModelDGV);
        }

        //Кнопка очищения полей ввода данных записи catModelDGV
        private void eraseBtn_Click(object sender, EventArgs e)
        {
            ClearField1();
        }

        //Событие строки поиска. При вводе текста ищутся строки, в которых есть вводимый текст catModelDGV
        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            Search1(catModelDGV);
        }

        //Кнопка добавления записи в бд catModelDGV
        private void addBtn_Click(object sender, EventArgs e)
        {
            myConnection.openConnection();

            var breed = breedTB.Text;
            char gender = Convert.ToChar(genderTB.Text);
            var colour = colourTB.Text;
            int age = Convert.ToInt32(ageTB.Text);

            if ((String.Equals(gender, 'Ж') || String.Equals(gender, 'М')) & age >= 1 & age <= 15)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();


                string queryString = $"insert into  CatModel(breed_modelcat, gender_modelcat, сolour_modelcat, age_modelcat) values('{breed}', '{gender}', '{colour}', '{age}')";

                SqlCommand command = new SqlCommand(queryString, myConnection.GetConnection());
                myConnection.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                }
                else
                {
                    MessageBox.Show("Произошла непредвиденная ошибка!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                myConnection.closeConnection();
            }
            else
            {
                MessageBox.Show("Пол кошки должен записываться как 'М' или 'Ж'! Возраст кошки должен быть от 1 года до 15 лет!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshDataGrid1(catModelDGV);
        }

        //Кнопка удаления записи catModelDGV
        private void delBtn_Click(object sender, EventArgs e)
        {
            deleteRow1();
        }

        //Кнопка изменения записи catModelDGV
        private void updBtn_Click(object sender, EventArgs e)
        {
            Change1();
            ClearField1();
        }

        //Кнопка сохранения записи в бд catModelDGV
        private void saveBtn_Click(object sender, EventArgs e)
        {
            Update1();
        }

        

        ////////////////////////////////////////////////////////////////////////////////////////////////
        //Методы Сat
        //Метод для заполнения catDGV
        private void ReadSingleRow2(DataGridView dgw, IDataRecord record)
        {
                dgw.Rows.Add(record.GetInt32(0), record.GetDateTime(1), record.GetDateTime(2), record.GetInt32(3), record.GetInt32(4), RowState.ModifiedNew);
        }

        //Метод для обновления catDGV
        private void RefreshDataGrid2(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"Select * from Cat";


            SqlCommand command = new SqlCommand(queryString, myConnection.GetConnection());

            myConnection.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow2(dgw, reader);
            }
            reader.Close();
        }


        //Метод для кнопки "Изменить" catDGV
        private void Change2()
        {
            var selectedRowIndex = catDGV.CurrentCell.RowIndex;

            var idCat = idCatTB.Text;
            var addDate = Convert.ToDateTime(addDateTB.Text);
            var updDate = DateTime.Now;
            int cost = Convert.ToInt32(costTB.Text);
            int idModelCat = Convert.ToInt32(idModelCatCatTB.Text);

            if (catDGV.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(costTB.Text, out cost))
                {
                    catDGV.Rows[selectedRowIndex].SetValues(idCat, addDate, updDate, cost, idModelCat);
                    catDGV.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Стоимость не должна быть меньше 0", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        //Метод для строки поиска записей в catDGV
        private void Search2(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Cat where concat (id_cat, add_date_cat, upd_date_cat, cost_cat, id_modelcat) like '%" + searchTB2.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, myConnection.GetConnection());

            myConnection.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow2(dgw, read);
            }

            read.Close();
        }

        //Метод, который помечает выделенную строку на удаление и скрывает эту строку из catDGV
        private void deleteRow2()
        {
            int index = catDGV.CurrentCell.RowIndex;


            catDGV.Rows[index].Visible = false;

            if (catDGV.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                catDGV.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }

            catDGV.Rows[index].Cells[5].Value = RowState.Deleted;


        }

        /*Метод, который взаимодействует с помеченными строками и 
        используется для сохранения данных, измененных в catDGV, в бд

         RowState.Existed - ничего не делает со строкой
         RowState.Deleted - удаляет помеченную строку в бд
         RowState.Modified - изменяет помеченную строку с нужным индексом в бд
        */
        private void Update2()
        {
            myConnection.openConnection();

            for (int index = 0; index < catDGV.Rows.Count; index++)
            {
                var rowState = (RowState)catDGV.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(catDGV.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Cat where id_cat = {id}";

                    var command = new SqlCommand(deleteQuery, myConnection.GetConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var idСat = catDGV.Rows[index].Cells[0].Value.ToString();
                    var updDate = DateTime.Now;
                    var cost = catDGV.Rows[index].Cells[3].Value.ToString();
                    var idModelСat = catDGV.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"update Cat set upd_date_cat = '{updDate}', cost_cat = '{cost}', id_modelcat = '{idModelСat}' where id_cat = '{idСat}'";

                    var command = new SqlCommand(changeQuery, myConnection.GetConnection());
                    command.ExecuteNonQuery();
                }
            }

            myConnection.closeConnection();
        }

        //Метод для вставки данных из таблицы Cat в таблицу Operation (логирование)
        private void CopyPaste()
        {
            myConnection.openConnection();

            int idCat = Convert.ToInt32(idCatTB.Text);
            var addDate = Convert.ToDateTime(addDateTB.Text);
            var updDate = Convert.ToDateTime(updDateTB.Text);
            int cost = Convert.ToInt32(costTB.Text);
            int idModelCat = Convert.ToInt32(idModelCatCatTB.Text);
            var purchaseDate = DateTime.Now;
            int idUser = _user.Id;
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string queryString = $"insert into Operation(id_cat, add_date_cat, upd_date_cat, cost_cat, id_modelcat, purchasedate, id_user) values('{idCat}', '{addDate}', '{updDate}', '{cost}', '{idModelCat}', '{purchaseDate}', '{idUser}')";
            
            SqlCommand command = new SqlCommand(queryString, myConnection.GetConnection());
            myConnection.openConnection();
            if (command.ExecuteNonQuery() == 1) { }
            else
            {
                MessageBox.Show("Произошла непредвиденная ошибка!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myConnection.closeConnection();
            
            RefreshDataGrid3(operationDGV);
        }

        //Метод, который очищает textBox'ы заполнения данных о записи catDGV
        private void ClearField2()
        {
            idCatTB.Text = string.Empty;
            addDateTB.Text = string.Empty;
            updDateTB.Text = string.Empty;
            costTB.Text = string.Empty;
            idModelCatCatTB.Text = string.Empty;
        }

        //------------------------------------------------------------------------------------
        //События Cat
        //Событие с заполнением textBox'ов данными из строки в catDGV 

        private void buyBtn_Click(object sender, EventArgs e)
        {
            deleteRow2();
            CopyPaste();
            Update2();
        }

        private void catDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = catDGV.Rows[selectedRow];

                idCatTB.Text = row.Cells[0].Value.ToString();
                addDateTB.Text = row.Cells[1].Value.ToString();
                updDateTB.Text = row.Cells[2].Value.ToString();
                costTB.Text = row.Cells[3].Value.ToString();
                idModelCatCatTB.Text = row.Cells[4].Value.ToString();
            }
        }

        private void refreshBtn2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid2(catDGV);
        }

        private void clearBtn2_Click(object sender, EventArgs e)
        {
            ClearField2();
        }

        private void searchTB2_TextChanged(object sender, EventArgs e)
        {
            Search2(catDGV);
        }

        private void addCatTB_Click(object sender, EventArgs e)
        {
            myConnection.openConnection();

            var addDate = DateTime.Now;
            var updDate = DateTime.Now;
            int cost = Convert.ToInt32(costTB.Text);
            int idModelCat = Convert.ToInt32(idModelCatCatTB.Text);

            if (cost >= 0)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();


                string queryString = $"insert into  Cat(add_date_cat, upd_date_cat, cost_cat, id_modelcat) values('{addDate}', '{updDate}', '{cost}', '{idModelCat}')";

                SqlCommand command = new SqlCommand(queryString, myConnection.GetConnection());
                myConnection.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                }
                else
                {
                    MessageBox.Show("Произошла непредвиденная ошибка!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                myConnection.closeConnection();
            }
            else
            {
                MessageBox.Show("Цена не должна быть меньше 0", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshDataGrid1(catModelDGV);
        }

        private void delCatTB_Click(object sender, EventArgs e)
        {
            deleteRow2();
        }

        private void updCatTB_Click(object sender, EventArgs e)
        {
            Change2();
        }

        private void saveCatTB_Click(object sender, EventArgs e)
        {
            Update2();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        //Методы Operation
        //Метод для заполнения operationDGV
        
        private void ReadSingleRow3(DataGridView dgw, IDataRecord record)
        {
                dgw.Rows.Add(record.GetInt32(0), record.GetDateTime(1), record.GetDateTime(2), record.GetInt32(3), record.GetInt32(4), record.GetDateTime(5), record.GetInt32(6));

        }

        //Метод для обновления operationDGV
        private void RefreshDataGrid3(DataGridView dgw)
        {
            dgw.Rows.Clear();

            int roleUser = _user.Role;
            int idUser = _user.Id;

            string queryString = $"Select * from Operation";
            
            SqlCommand command = new SqlCommand(queryString, myConnection.GetConnection());

            myConnection.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow3(dgw, reader);
            }
            reader.Close();
        }

        //Метод для строки поиска записей в operationDGV
        private void Search3(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Operation where concat (id_cat, add_date_cat, upd_date_cat, cost_cat, id_modelcat, purchasedate, id_user) like '%" + searchTB3.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, myConnection.GetConnection());

            myConnection.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow3(dgw, read);
            }

            read.Close();
        }

        //------------------------------------------------------------------------------------
        //События Operation
        //Событие с заполнением textBox'ов данными из строки в catModelDGV 

        private void searchTB3_TextChanged(object sender, EventArgs e)
        {
            Search3(operationDGV);
        }

        private void refreshBtn3_Click(object sender, EventArgs e)
        {
            RefreshDataGrid3(operationDGV);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        //Методы Login
        //Метод для заполнения loginDGV
        private void ReadSingleRow4(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), RowState.ModifiedNew);
        }


        //Метод для обновления loginDGV
        private void RefreshDataGrid4(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"Select * from Login";

            SqlCommand command = new SqlCommand(queryString, myConnection.GetConnection());

            myConnection.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow4(dgw, reader);
            }
            reader.Close();
        }


        //Метод для кнопки "Изменить" loginDGV
        private void Change4()
        {
            var selectedRowIndex = loginDGV.CurrentCell.RowIndex;

            int idUser = Convert.ToInt32(idUserTB.Text);
            var login = loginUserTB.Text;
            var password = passwordUserTB.Text;
            int role = Convert.ToInt32(roleUserTB.Text);

            if (loginDGV.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty & (role == 1 || role == 2))
            {
                loginDGV.Rows[selectedRowIndex].SetValues(idUser, login, password, role);
                loginDGV.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
            }
            else
            {
                MessageBox.Show("Роль должна быть значением 1 (Админ) или 2 (Пользователь)", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Метод для строки поиска записей в loginDGV
        private void Search4(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Login where concat (id_user, login_user, password_user, user_role) like '%" + searchTB4.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, myConnection.GetConnection());

            myConnection.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow4(dgw, read);
            }

            read.Close();
        }

        //Метод, который помечает выделенную строку на удаление и скрывает эту строку из loginDGV
        private void deleteRow4()
        {
            int index = loginDGV.CurrentCell.RowIndex;

            loginDGV.Rows[index].Visible = false;

            if (loginDGV.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                loginDGV.Rows[index].Cells[4].Value = RowState.Deleted;
                return;
            }

            loginDGV.Rows[index].Cells[4].Value = RowState.Deleted;

        }

        /*Метод, который взаимодействует с помеченными строками и 
        используется для сохранения данных, измененных в loginDGV, в бд

         RowState.Existed - ничего не делает со строкой
         RowState.Deleted - удаляет помеченную строку в бд
         RowState.Modified - изменяет помеченную строку с нужным индексом в бд
        */
        private void Update4()
        {
            myConnection.openConnection();

            for (int index = 0; index < loginDGV.Rows.Count; index++)
            {
                var rowState = (RowState)loginDGV.Rows[index].Cells[4].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(loginDGV.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Login where id_user = {id}";

                    var command = new SqlCommand(deleteQuery, myConnection.GetConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var idUser = loginDGV.Rows[index].Cells[0].Value.ToString();

                    var login = loginDGV.Rows[index].Cells[1].Value.ToString();
                    var password = loginDGV.Rows[index].Cells[2].Value.ToString();
                    var role = loginDGV.Rows[index].Cells[3].Value.ToString();

                    var changeQuery = $"update Login set login_user = '{login}', password_user = '{password}',user_role = '{role}' where id_user = '{idUser}'";

                    var command = new SqlCommand(changeQuery, myConnection.GetConnection());
                    command.ExecuteNonQuery();
                }
            }

            myConnection.closeConnection();
        }

        //Метод, который очищает textBox'ы заполнения данных о записи loginDGV
        private void ClearField4()
        {
            idUserTB.Text = string.Empty;
            loginUserTB.Text = string.Empty;
            passwordUserTB.Text = string.Empty;
            roleUserTB.Text = string.Empty;
        }

        //------------------------------------------------------------------------------------
        //События Login
        private void loginDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = loginDGV.Rows[selectedRow];

                idUserTB.Text = row.Cells[0].Value.ToString();
                loginUserTB.Text = row.Cells[1].Value.ToString();
                passwordUserTB.Text = row.Cells[2].Value.ToString();
                roleUserTB.Text = row.Cells[3].Value.ToString();
            }
        }

        private void refreshBtn4_Click(object sender, EventArgs e)
        {
            RefreshDataGrid4(loginDGV);
        }

        private void clearBtn4_Click(object sender, EventArgs e)
        {
            ClearField4();
        }

        private void searchTB4_TextChanged(object sender, EventArgs e)
        {
            Search4(loginDGV);
        }

        //loginDGV
        private void addUserBtn_Click(object sender, EventArgs e)
        {
            myConnection.openConnection();

            int idUser = Convert.ToInt32(idUserTB.Text);

            var login = loginUserTB.Text;
            var password = passwordUserTB.Text;
            int role = Convert.ToInt32(roleUserTB.Text);

            if (role == 1 || role == 2)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();


                string queryString = $"insert into  Login(login_user, password_user, user_role) values('{login}', '{password}', '{role}')";

                SqlCommand command = new SqlCommand(queryString, myConnection.GetConnection());
                myConnection.openConnection();
                if (command.ExecuteNonQuery() == 1){ }
                else
                {
                    MessageBox.Show("Произошла непредвиденная ошибка!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                myConnection.closeConnection();
            }
            else
            {
                MessageBox.Show("Роль должна быть значением 1 (Админ) или 2 (Пользователь)", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshDataGrid4(loginDGV);
        }

        private void delUserBtn_Click(object sender, EventArgs e)
        {
            deleteRow4();
        }

        private void updUserBtn_Click(object sender, EventArgs e)
        {
            Change4();
        }

        private void saveUserBtn_Click(object sender, EventArgs e)
        {
            Update4();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        //Методы Role
        //Метод для заполнения roleDGV
        private void ReadSingleRow5(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }

        //Метод для обновления roleDGV
        private void RefreshDataGrid5(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"Select * from Role";

            SqlCommand command = new SqlCommand(queryString, myConnection.GetConnection());

            myConnection.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow5(dgw, reader);
            }
            reader.Close();
        }

        //Метод для строки поиска записей в roleDGV
        private void Search5(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Role where concat (id_role, name_role) like '%" + searchTB6.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, myConnection.GetConnection());

            myConnection.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow5(dgw, read);
            }

            read.Close();
        }


        //------------------------------------------------------------------------------------
        //События Role

        private void searchTB6_TextChanged(object sender, EventArgs e)
        {
            Search5(roleDGV);
        }

        private void refreshBtn6_Click(object sender, EventArgs e)
        {
            RefreshDataGrid5(roleDGV);
        }

        
    }
}
