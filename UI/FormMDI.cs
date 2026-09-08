using EduTech;
using SERVICIOS;
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


namespace UI
{
    public partial class FormMDI : Form
    {
        //private UsuarioBE _usuario;
        private UsuarioBE _usuario;
        public FormMDI(/*UsuarioBE usuarioActivo*/UsuarioBE usuarioActivo)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;


            // _usuario = usuarioActivo;
             _usuario = usuarioActivo;

            AplicarPermisos();
        }

        private void FormMDI_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void AplicarPermisos()
        {
            // btnUsuarios.Visible = Permisos.TienePermiso(_usuario, "GESTIONAR_USUARIOS");
             
        }      

        private void AbrirFormEnPanel(object FormHijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)

                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = FormHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();

        }

        private void btnAbrirFamilias_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormABMFamilias());
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormMDI_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void PanelMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnminimizar.Visible = true;
            
        }

        private void PBven_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnminimizar.Visible = false;
            
        }

        private void PBmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormAdministracion());
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void PanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
