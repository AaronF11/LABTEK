using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace Historial_médico
{
    public partial class FrmMain : Form
    {
        //---------------------------------------------------------------------
        //Atributos.
        //---------------------------------------------------------------------
        string Path = "script.py";//Path del script.
        ScriptRuntime py = Python.CreateRuntime();//Método para ejecutar código Python.
        dynamic script;//Variable para ejecutar el script.

        //---------------------------------------------------------------------
        //Constructor.
        //---------------------------------------------------------------------
        public FrmMain()
        {
            InitializeComponent();//Inicializa componentes.
            script = py.UseFile(Path);//Variable para ejecutar el script.
            FirstConfig();//Inicializa configuraciones predeterminadas.
            Round();//Inicializa el redondeo de los componentes.
        }

        #region Configuración inicial.
        //---------------------------------------------------------------------
        //Método para comenzar la ejecución.
        //---------------------------------------------------------------------
        private void FirstConfig()
        {
            //PnlOne.Width = 0;
            //PnlTwo.Width = 0;
        }
        #endregion

        #region Método para redondear componentes.
        //---------------------------------------------------------------------
        //Crea un rectangulo para redondear el componente.
        //---------------------------------------------------------------------
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        //---------------------------------------------------------------------
        //Redondea los bordes de los componentes.
        //---------------------------------------------------------------------
        private void Round()
        {
            //Componentes a los que se le aplica el redondeo.
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            PnlMessage.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PnlMessage.Width, PnlMessage.Height, 25, 25));
            PnlList.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PnlList.Width, PnlList.Height, 25, 25));
            PnlExample1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PnlExample1.Width, PnlExample1.Height, 25, 25));
            PnlExample2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PnlExample2.Width, PnlExample2.Height, 25, 25));
            BtnPeople.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnPeople.Width, BtnPeople.Height, 25, 25));
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 25, 25));
            button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 25, 25));
        }
        #endregion

        #region Barra superior.
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Barra lateral izquierda.
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(script.Hola());
        }
    }
}
