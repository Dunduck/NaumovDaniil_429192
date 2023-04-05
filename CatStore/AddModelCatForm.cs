using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatStore
{
    public partial class AddModelCatForm : MaterialForm
    {
        ConnectionCatStore myConnection = new ConnectionCatStore();

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        public AddModelCatForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Pink500, MaterialSkin.Primary.Pink700, MaterialSkin.Primary.Pink100, MaterialSkin.Accent.Pink200, MaterialSkin.TextShade.WHITE);
        }
    }
}
